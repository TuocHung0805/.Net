using System;

namespace Store.Models
{
    public class OrderDetail : BaseEntity
    {
        public Guid MaDH { get; set; }
        public Guid MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
        public int ThanhTien { get; set; }
    }
}
