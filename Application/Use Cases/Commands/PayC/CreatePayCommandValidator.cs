using Application.Utils;
using FluentValidation;

namespace Application.Use_Cases.Commands.PayC
{
    public class CreatePayCommandValidator : AbstractValidator<CreatePayCommand>
    {
        public CreatePayCommandValidator()
        {
            RuleFor(x => x.SellerGuid).NotEmpty().Must(GuidValidator.BeAValidGuid).WithMessage("'SellerGuid' must be a valid Guid");
            RuleFor(x => x.BuyerGuid).NotEmpty().Must(GuidValidator.BeAValidGuid).WithMessage("'BuyerGuid' must be a valid Guid");
            RuleFor(x => x.EstateGuid).NotEmpty().Must(GuidValidator.BeAValidGuid).WithMessage("'EstateGuid' must be a valid Guid");
        }
    }
}
