using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace STSRedditCrawlerEntities
{
    public class Objects
    {
        public static string GetToken()
        {
            string Token = ConfigurationManager.AppSettings.Get("Token");

            return Token;
        }
    }
}
