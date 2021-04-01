using BicycleRent.Api.Resources;
using FluentValidation;

namespace BicycleRent.Api.Validators
{
    public class SaveBicycleResourceValidator : AbstractValidator<SaveBicycleResource>
    {

        public SaveBicycleResourceValidator()
        {
            RuleFor(b => b.BicycleSize)
                .IsInEnum();

            RuleFor(b => b.BicycleBrand)
                .IsInEnum();

        }
    }
}
