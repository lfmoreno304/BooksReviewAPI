﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ReviewDetail
    {
        [Key]
        public int Review_id { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public int Book_id { get; set; }
        public string User_email { get; set; }
    }
}
