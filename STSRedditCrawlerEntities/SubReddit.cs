using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace STSRedditCrawlerEntities
{
    public class SubReddit
    {
        [Key]
        public int ID { get; set; }
        [Column("ADD_DATE")]
        public DateTime AddDate { get; set; }
        public string Name { get; set; }
    }
}
