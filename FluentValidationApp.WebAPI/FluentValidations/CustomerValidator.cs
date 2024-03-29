﻿using FluentValidation;
using FluentValidationApp.WebAPI.Models;

namespace FluentValidationApp.WebAPI.FluentValidations
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

            RuleFor(x => x.BirthDay).NotEmpty().WithMessage("Doğum Tarihi boş olamaz")
                .Must(x =>
                {
                    return DateTime.Now.AddYears(-18) >= x;

                }).WithMessage("Yaşınız 18'den büyük olmalıdır.");

            RuleForEach(x => x.Addresses).SetValidator(new AddressValidator());

            RuleFor(x => x.En_Gender).IsInEnum().WithMessage("Bayan 1 , Bay 2 değerini almalıdır");

        }
    }
}
