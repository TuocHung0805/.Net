using FluentValidation;
using System;

namespace Store.Models
{
    public class OrderDetailVM
    {
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
        public int ThanhTien { get; set; }
    }

    public class OrderDetailVMValidator : AbstractValidator<OrderDetailVM>
    {
        public OrderDetailVMValidator()
        {
            RuleFor(OrderDetailVM => OrderDetailVM.TenSP).NotEmpty();
            RuleFor(OrderDetailVM => OrderDetailVM.SoLuong).NotEmpty();
            RuleFor(OrderDetailVM => OrderDetailVM.DonGia).NotEmpty();
            RuleFor(OrderDetailVM => OrderDetailVM.ThanhTien).NotEmpty();
        }
    }

}
