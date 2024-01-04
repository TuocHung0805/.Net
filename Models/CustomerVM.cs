using FluentValidation;

namespace Store.Models
{
    public class CustomerVM
    {
        public string HoVaTen { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
    }
    public class CustomerVMValidator : AbstractValidator<CustomerVM>
    {
        public CustomerVMValidator()
        {
            RuleFor(CustomerVM => CustomerVM.HoVaTen).NotEmpty();
            RuleFor(CustomerVM => CustomerVM.HoVaTen).MinimumLength(8);
            RuleFor(CustomerVM => CustomerVM.SDT).NotEmpty();
            RuleFor(CustomerVM => CustomerVM.SDT).MaximumLength(11);
            RuleFor(CustomerVM => CustomerVM.DiaChi).NotEmpty();
        }

    }
}
