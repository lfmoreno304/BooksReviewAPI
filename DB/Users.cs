using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Users
    {
        [Key]
        public int User_id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string img { get; set; }
    }
}
