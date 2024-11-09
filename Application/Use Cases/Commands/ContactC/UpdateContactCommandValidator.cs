using Application.Utils;
using FluentValidation;


namespace Application.Use_Cases.Commands.ContactC
{
    public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
    {
        public UpdateContactCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().Must(GuidValidator.BeAValidGuid).WithMessage("'UserId' must be a valid Guid");
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Phone).NotEmpty().MaximumLength(10);
            RuleFor(x => x.Id).NotEmpty().Must(GuidValidator.BeAValidGuid).WithMessage("'Id' must be a valid Guid");
        }
    }
}
