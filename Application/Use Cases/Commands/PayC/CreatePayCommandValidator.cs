using FluentValidation;

namespace Application.Use_Cases.Commands.PayC
{
    public class CreatePayCommandValidator : AbstractValidator<CreatePayCommand>
    {
        public CreatePayCommandValidator()
        {
            RuleFor(x => x.SellerGuid).NotEmpty().Must(BeAValidGuid).WithMessage("'SellerGuid' must be a valid Guid"); ;
            RuleFor(x => x.BuyerGuid).NotEmpty().Must(BeAValidGuid).WithMessage("'BuyerGuid' must be a valid Guid");
            RuleFor(x => x.EstateGuid).NotEmpty().Must(BeAValidGuid).WithMessage("'EstateGuid' must be a valid Guid");
        }

        private bool BeAValidGuid(Guid guid)
        {
            return Guid.TryParse(guid.ToString(), out _);
        }
    }
}
