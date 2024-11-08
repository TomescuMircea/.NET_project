using Application.Utils;
using FluentValidation;

namespace Application.Use_Cases.Commands.BusinessSpaceC
{
    public class CreateBusinessSpaceCommandValidator : AbstractValidator<CreateBusinessSpaceCommand>
    {
        public CreateBusinessSpaceCommandValidator()
        {
            RuleFor(x => x.EstateId).NotEmpty().Must(GuidValidator.BeAValidGuid).WithMessage("'EstateId' must be a valid Guid");
            RuleFor(x => x.FloorNumber).GreaterThanOrEqualTo(0);
        }
    }
}
