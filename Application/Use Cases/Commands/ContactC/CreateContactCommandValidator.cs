using FluentValidation;

namespace Application.Use_Cases.Commands.ContactC
{
    public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
    {
        public CreateContactCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().Must(BeAValidGuid).WithMessage("'UserId' must be a valid Guid");
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Phone).NotEmpty().MaximumLength(10);
        }
        private bool BeAValidGuid(System.Guid guid)
        {
            return System.Guid.TryParse(guid.ToString(), out _);
        }
    }
}
