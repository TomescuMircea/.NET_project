using FluentValidation;

namespace Application.Use_Cases.Commands.ReportC
{
    public class CreateReportCommandValidator : AbstractValidator<CreateReportCommand>
    {
        public CreateReportCommandValidator()
        {
            RuleFor(x => x.BuyerId).NotEmpty().Must(BeAValidGuid).WithMessage("'BuyerId' must be a valid Guid");
            RuleFor(x => x.SellerId).NotEmpty().Must(BeAValidGuid).WithMessage("'SellerId' must be a valid Guid");
            RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
        }

        private bool BeAValidGuid(Guid guid)
        {
            return Guid.TryParse(guid.ToString(), out _);
        }
    }
}
