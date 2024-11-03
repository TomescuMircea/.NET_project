using FluentValidation;

namespace Application.Use_Cases.Commands.ReviewUserC
{
    public class CreateReviewUserCommandValidator : AbstractValidator<CreateReviewUserCommand>
    {
        public CreateReviewUserCommandValidator() 
        {
            RuleFor(x => x.BuyerId).NotEmpty().Must(BeAValidGuid).WithMessage("'UserId' must be a valid Guid");
            RuleFor(x => x.SellerId).NotEmpty().Must(BeAValidGuid).WithMessage("'ReviewId' must be a valid Guid");
            RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
            RuleFor(x => x.Rating).NotEmpty().InclusiveBetween(1, 10);
        }

        private bool BeAValidGuid(Guid guid)
        {
            return Guid.TryParse(guid.ToString(), out _);
        }
    }
}
