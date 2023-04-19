using FluentValidation;
using FluentValidationApp.WebUI.Models;

namespace FluentValidationApp.WebUI.FluentValidations
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name alanı boş olamaz");
            
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email alanı boş olamaz")
                .EmailAddress().WithMessage("Email doğru formatta olmalıdır.");
            
            RuleFor(x => x.Age)
                .NotEmpty().WithMessage("Yaş alanı boş olamaz")
                .InclusiveBetween(18, 60).WithMessage("Yaş aralığını 18-60 arasında olmalıdır");

        }
    }
}
