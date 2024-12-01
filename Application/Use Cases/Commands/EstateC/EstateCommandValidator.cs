using Application.Utils;
using FluentValidation;

namespace Application.Use_Cases.Commands.EstateC
{
    public class EstateCommandValidator<T> : AbstractValidator<T> where T : CreateEstateCommand
    {
        public EstateCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().Must(GuidValidator.BeAValidGuid).WithMessage("'UserId' must be a valid Guid");
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.Address).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Size).GreaterThan(0);
            RuleFor(x => x.Type).NotEmpty().MaximumLength(1);
            RuleFor(x => x.Status).NotEmpty().MaximumLength(100);
            RuleFor(x => x.ListingData).NotEmpty();
        }
    }
}
