using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.Data
{
    public class Order
    {
        [Key]
        public Guid MaDH { get; set; }
        public Guid MaKH { get; set; }
        public DateTime NgayDat { get; set; }
        public string DiaChi { get; set; }

        //relationship
        public Customer Customer { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
