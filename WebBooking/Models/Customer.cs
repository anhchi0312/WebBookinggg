using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBooking.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Display(Name = "Tên khách hàng ")]
        public string CustomerName { get; set; }
        [Display(Name = "Địa khách hàng ")]
        public string Address { get; set; }
        [Display(Name = "Số điện thoại khách hàng ")]
        public string Tel { get; set; }
        [Display(Name = "Địa khách hàng ")]
        [Required, EmailAddress]
        public string email { get; set; }
        [Display(Name = "Mật khẩu ")]
        [Required]
        //[DataType(DataType.Password)]
        public string password { get; set; }
        [Display(Name = "Xác nhận lại mật khẩu ")]
        [NotMapped]
        [Required]
        //[DataType(DataType.Password)]
        //[System.ComponentModel.DataAnnotations.Compare("password")]
        public string confirm_password { get; set; }
        public ICollection<DatGoi> DatGois { get; set; }
    }
}