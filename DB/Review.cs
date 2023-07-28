using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Review
    {
       
        public int Reviewid { get; set; }
        public string Decription { get; set; }
        public int Rating { get; set; }
        public int Bookid { get; set; }
        public int Userid { get; set; }
    }
}
