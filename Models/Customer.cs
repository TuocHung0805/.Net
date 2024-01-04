using System;

namespace Store.Models
{
    public class Customer : BaseEntity
    {
        public Guid MaKH { get; set; }
        public string HoVaTen { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
    }
}
