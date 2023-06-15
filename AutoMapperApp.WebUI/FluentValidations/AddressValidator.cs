using AutoMapperApp.WebUI.Models;
using FluentValidation;

namespace AutoMapperApp.WebUI.FluentValidations
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} alanı boş olamaz";
        public AddressValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Provience).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.PstCode).NotEmpty().WithMessage(NotEmptyMessage).
                MaximumLength(5).WithMessage("{PropertyName} alanı en çok {MaxLength} karakter olmalıdır.");


        }
    }
}
