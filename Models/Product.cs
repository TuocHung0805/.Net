﻿using System;

namespace Store.Models
{
    public class Product : BaseEntity
    {
        public Guid MaSP { get; set; }
        public string TenSP { get; set; }
        public string DungLuong { get; set; }
        public string MauSac { get; set; }
        public int Gia { get; set; }
    }

}
