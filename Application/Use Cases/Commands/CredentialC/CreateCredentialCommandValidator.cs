using FluentValidation;

namespace Application.Use_Cases.Commands.CredentialC
{
    public class CreateCredentialCommandValidator : AbstractValidator<CreateCredentialCommand> 
    {
        public CreateCredentialCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().Must(BeAValidGuid).WithMessage("'UserId' must be a valid Guid");
            RuleFor(x => x.UserName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MaximumLength(100);
        }

        private bool BeAValidGuid(Guid guid)
        {
            return Guid.TryParse(guid.ToString(), out _);
        }
    }
}
