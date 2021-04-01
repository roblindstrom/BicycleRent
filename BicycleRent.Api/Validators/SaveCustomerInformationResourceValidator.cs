using BicycleRent.Api.Resources;
using FluentValidation;

namespace BicycleRent.Api.Validators
{
    public class SaveCustomerInformationResourceValidator : AbstractValidator<SaveCustomerInformationResource>
    {
        public SaveCustomerInformationResourceValidator()
        {


            RuleFor(ci => ci.Firstname)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(ci => ci.Lastname)
                .NotEmpty()
                .MaximumLength(50);


        }



    }
}
