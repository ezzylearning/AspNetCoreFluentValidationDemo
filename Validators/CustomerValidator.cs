using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreFluentValidationDemo.Models;
using FluentValidation;

namespace AspNetCoreFluentValidationDemo.Validators
{
    public class CustomerValidator : AbstractValidator<CustomerModel>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required.");

            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress();

            RuleFor(x => x.Height).ScalePrecision(1, 3);

            RuleFor(x => x.Age).InclusiveBetween(18, 50);

            RuleFor(x => x.Phone).Must(phone =>
                !string.IsNullOrEmpty(phone) && phone.StartsWith("+")
            )
            .WithMessage("Phone must starts with + sign.");


            RuleFor(x => x.PrimaryAddress).InjectValidator();

            RuleFor(x => x.PrimaryAddress).SetValidator(new AddressValidator());

            RuleForEach(x => x.OtherAddresses).SetValidator(new AddressValidator());

        }
    }
}
