using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBooking.Models
{
    public class DatGoi
    {
        [Key]
        public int SoPhieu { get; set; }
        public int GoiId { get; set; }
        public string GoiName { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public string State { get; set; }

    }
}