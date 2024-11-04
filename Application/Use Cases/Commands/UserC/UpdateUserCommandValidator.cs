using Application.Utils;
using FluentValidation;

namespace Application.Use_Cases.Commands.UserC
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Type).NotEmpty().MaximumLength(100);
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Status).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Id).NotEmpty().Must(GuidValidator.BeAValidGuid).WithMessage("'Id' must be a valid Guid");
        }
    }
}
