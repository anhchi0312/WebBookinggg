using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBooking.Models
{
    public class New
    {
        [Key]
        public int NewId { get; set; }
        public string Title { get; set; }
        public string imgUml { get; set; }
        public string Content { get; set; }
    }
}