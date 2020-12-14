using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBooking.Models
{
    
    public class NhanVien
    {
        [Key]
        public int IDNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string SDT { get; set; }
    }
}