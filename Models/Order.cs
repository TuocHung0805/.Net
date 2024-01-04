using System;

namespace Store.Models
{
    public class Order : BaseEntity
    {
        public Guid MaDH { get; set;}
        public DateTime NgayDat { get; set; }
        public string HoVaTen { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
    }

}
