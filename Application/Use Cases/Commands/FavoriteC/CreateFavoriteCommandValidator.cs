using FluentValidation;

namespace Application.Use_Cases.Commands.FavoriteC
{
    public class CreateFavoriteCommandValidator : AbstractValidator<CreateFavoriteCommand>
    {
        public CreateFavoriteCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().Must(BeAValidGuid).WithMessage("'UserId' must be a valid Guid"); ;
            RuleFor(x => x.EstateId).NotEmpty().Must(BeAValidGuid).WithMessage("'EstateId' must be a valid Guid");
        }

        private bool BeAValidGuid(Guid guid)
        {
            return Guid.TryParse(guid.ToString(), out _);
        }

    }
}
