using FluentValidation;

namespace Store.Models
{
    public class ProductVM
    {
        public string TenSP { get; set; }
        public string DungLuong { get; set; }
        public string MauSac { get; set; }
        public int Gia { get; set; }
    }

    public class ProductVMValidator : AbstractValidator<ProductVM>
    {
        public ProductVMValidator()
        {
            RuleFor(ProductVM => ProductVM.TenSP).NotEmpty();
            RuleFor(ProductVM => ProductVM.DungLuong).NotEmpty();
            RuleFor(ProductVM => ProductVM.MauSac).NotEmpty();
            RuleFor(ProductVM => ProductVM.Gia).NotEmpty();
        }
    }
}
