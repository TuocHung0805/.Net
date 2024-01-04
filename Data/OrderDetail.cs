using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Data
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        public Guid MaDH { get; set; }
        public Guid MaSP { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
        public int ThanhTien { get; set; }

        //relationship
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
