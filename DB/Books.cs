using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Books
    {
        [Key]
        
        public int Book_id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Category { get; set; }
        public string Img { get; set; }
        public string Author { get; set; }
    }
}
