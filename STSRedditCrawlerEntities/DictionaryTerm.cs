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
    public class DictionaryTerm
    {
        [Key]
        public int ID { get; set; }
        public string Keyword { get; set; }
        [Column("SECURITY_NAME")]
        public string SecurityName { get; set; }
        [Column("SECURITY_SYM")]
        public string SecuritySymbol { get; set; }
        public string Note { get; set; }

    }
}
