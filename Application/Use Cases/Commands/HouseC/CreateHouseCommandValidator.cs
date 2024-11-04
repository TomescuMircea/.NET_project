using Application.Utils;
using FluentValidation;

namespace Application.Use_Cases.Commands.HouseC
{
    public class CreateHouseCommandValidator : AbstractValidator<CreateHouseCommand>
    {
        public CreateHouseCommandValidator()
        {
            RuleFor(x => x.EstateId).NotEmpty().Must(GuidValidator.BeAValidGuid).WithMessage("'EstateId' must be a valid Guid");
            RuleFor(x => x.OutsideAreaSize).GreaterThan(0);
        }
    }
}
