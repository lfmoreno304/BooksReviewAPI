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
        public string Description { get; set; }
        public int Rating { get; set; }
        public int Book_id { get; set; }
        public int User_id { get; set; }
    }
}
