using FluentValidation;

namespace Application.Use_Cases.Commands.BusinessSpaceC
{
    public class CreateBusinessSpaceCommandValidator : AbstractValidator<CreateBusinessSpaceCommand>
    {
        public CreateBusinessSpaceCommandValidator()
        {
            RuleFor(x => x.EstateId).NotEmpty().Must(BeAValidGuid).WithMessage("'EstateId' must be a valid Guid");
            RuleFor(x => x.FloorNumber).GreaterThanOrEqualTo(0);
        }

        private bool BeAValidGuid(Guid guid)
        {
            return Guid.TryParse(guid.ToString(), out _);
        }
    }
}
