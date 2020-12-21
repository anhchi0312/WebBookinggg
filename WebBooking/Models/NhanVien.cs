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
        [Required, EmailAddress]
        public string emailNV { get; set; }

        [Required]
        //[DataType(DataType.Password)]
        public string passwordNV { get; set; }
        [NotMapped]
        [Required]
        //[DataType(DataType.Password)]
        //[System.ComponentModel.DataAnnotations.Compare("passwordNV")]
        public string confirm_password { get; set; }
    }
}