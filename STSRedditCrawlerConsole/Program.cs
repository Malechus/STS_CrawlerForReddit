using System;
using STSRedditCrawlerEntities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using RedditSharp;
using RedditSharp.Things;
using System.Threading;

namespace STSRedditCrawlerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            STSContext _stsContext = new STSContext();

            List<DictionaryTerm> terms = new List<DictionaryTerm>();

            try
            {
                terms = _stsContext.DictionaryTerms.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was a problem connecting to the database.");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press Enter to exit.");
                Console.ReadLine();
                Environment.Exit(2);
            }
            List<RedditPost> redditPosts = new List<RedditPost>();

            string redditToken = Objects.GetToken();

            //Authenticate Reddit connection
            bool Auth = false;
            Reddit reddit = new Reddit(redditToken);
            reddit.InitOrUpdateUserAsync();
            Auth = reddit.User != null;
            if (!Auth)
            {
                //Wait for async init to complete
                Thread.Sleep(30000);
                if (reddit.User != null)
                {
                    Auth = true;
                }
                else
                {
                    throw new Exception("There was a problem authenticating with Reddit.");
                    Environment.Exit(1);
                    //TODO Error logging
                }
            }

            //Build a list of subreddits to track
            List<SubReddit> subRedditsFromDB = _stsContext.Subreddits.ToList();
            List<Subreddit> subreddits = new List<Subreddit>();

            foreach (SubReddit s in subRedditsFromDB)
            {
                Subreddit sub = reddit.GetSubredditAsync(s.Name).Result;
                subreddits.Add(sub);
            }

            foreach (Subreddit sub in subreddits)
            {
                List<Post> posts = sub.GetPosts(100).ToListAsync().Result;
                foreach (Post p in posts)
                {
                    foreach (DictionaryTerm dt in terms)
                    {
                        if (p.Title.Contains(dt.Keyword) || p.SelfText.Contains(dt.Keyword))
                        {
                            RedditPost rp = new RedditPost
                            {
                                PostDate = DateTime.Today,
                                Keywords = dt.Keyword,
                                UserName = p.AuthorName,
                                Tags = p.AuthorFlairText,
                                SecuritySymbol = dt.SecuritySymbol,
                                Body = p.Title + "..." + p.SelfText
                            };

                            redditPosts.Add(rp);
                        }
                    }
                }
            }

            //Write list of gathered posts to DB
            foreach (RedditPost rp in redditPosts)
            {
                _stsContext.RedditPosts.Add(rp);
            }
            _stsContext.SaveChanges();
            
        }
    }
}
