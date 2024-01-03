using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        public Guid MaKH { get; set; }
        public string HoVaTen { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
