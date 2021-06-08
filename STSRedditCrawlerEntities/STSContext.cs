using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace STSRedditCrawlerEntities
{
    public class STSContext : DbContext
    {
        public STSContext()
            : base("name=STSConnection")
        {

        }

        public DbSet<RedditPost> RedditPosts { get; set; }
        public DbSet<DictionaryTerm> DictionaryTerms { get; set; }
        public DbSet<SubReddit> Subreddits { get; set; }
    }
}
