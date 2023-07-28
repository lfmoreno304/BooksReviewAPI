using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Review
    {
        [Key]
        public int Review_id { get; set; }
        public string Decription { get; set; }
        public int Rating { get; set; }
        public int Bookid { get; set; }
        public int Userid { get; set; }
    }
}
