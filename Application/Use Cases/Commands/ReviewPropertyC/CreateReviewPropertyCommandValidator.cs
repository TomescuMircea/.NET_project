using FluentValidation;

namespace Application.Use_Cases.Commands.ReviewPropertyC
{
    public class CreateReviewPropertyCommandValidator : AbstractValidator<CreateReviewPropertyCommand>
    {
        public CreateReviewPropertyCommandValidator()
        {
            RuleFor(x => x.EstateId).NotEmpty().Must(BeAValidGuid).WithMessage("'EstateId' must be a valid Guid");
            RuleFor(x => x.BuyerId).NotEmpty().Must(BeAValidGuid).WithMessage("'BuyerId' must be a valid Guid");
            RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
            RuleFor(x => x.Rating).InclusiveBetween(1, 10);
        }

        private bool BeAValidGuid(Guid guid)
        {
            return Guid.TryParse(guid.ToString(), out _);
        }
    }
}
