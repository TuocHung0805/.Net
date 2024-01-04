using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Data
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public Guid MaSP { get; set; }
        public string TenSP { get; set; }
        public string DungLuong { get; set; }
        public string MauSac { get; set; }
        public int Gia { get; set; }
    }
}
