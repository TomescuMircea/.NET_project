using FluentValidation;

namespace Application.Use_Cases.Commands.ImageC
{
    public class CreateImageCommandValidator : AbstractValidator<CreateImageCommand>
    {
        public CreateImageCommandValidator()
        {
            RuleFor(x => x.EstateId).NotEmpty().Must(BeAValidGuid).WithMessage("'EstateId' must be a valid Guid");
            RuleFor(x => x.Extenstion).NotEmpty().MaximumLength(10);
        }

        private bool BeAValidGuid(Guid guid)
        {
            return Guid.TryParse(guid.ToString(), out _);
        }
    }
}
