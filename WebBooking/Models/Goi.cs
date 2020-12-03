using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBooking.Models
{
    public class Goi
    {
        [Key]
        public int GoiId { get; set; }
        public string GoiName { get; set; }
        public string Note { get; set; }
        public string Img { get; set; }
    }
}