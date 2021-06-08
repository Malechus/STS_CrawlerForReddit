using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace STSRedditCrawlerEntities
{
    public class RedditPost
    {
        [Key]
        public int ID { get; set; }
        [Column("POST_DATE")]
        public DateTime PostDate { get; set; }
        public string Keywords { get; set; }
        [Column("USER_NAME")]
        public string UserName { get; set; }
        public string Tags { get; set; }
        [Column("SECURITY_SYM")]
        public string SecuritySymbol { get; set; }
        public string Body { get; set; }
    }
}
