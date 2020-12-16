using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string emailNV { get; set; }
        [Required]
        public string passwordNV { get; set; }
        [NotMapped]
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("passwordNV")]
        public string confirm_password { get; set; }
    }
}