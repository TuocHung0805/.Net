using FluentValidation;
using System;

namespace Store.Models
{
    public class OrderVM
    {
        public DateTime NgayDat { get; set; }
        public string HoVaTen { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
    }

    public class OrderVMValidator : AbstractValidator<OrderVM>
    {
        public OrderVMValidator()
        {
            RuleFor(OrderVM => OrderVM.HoVaTen).NotEmpty();
            RuleFor(OrderVM => OrderVM.HoVaTen).MinimumLength(8);
            RuleFor(OrderVM => OrderVM.SDT).NotEmpty();
            RuleFor(OrderVM => OrderVM.SDT).MaximumLength(11);
            RuleFor(OrderVM => OrderVM.DiaChi).NotEmpty();
        }
    }
}
