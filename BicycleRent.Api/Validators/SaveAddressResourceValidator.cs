using BicycleRent.Api.Resources;
using FluentValidation;

namespace BicycleRent.Api.Validators
{
    public class SaveAddressResourceValidator : AbstractValidator<SaveAddressResource>
    {
        public SaveAddressResourceValidator()
        {
            //Sätt upp regler för Adress här
        }

    }
}
