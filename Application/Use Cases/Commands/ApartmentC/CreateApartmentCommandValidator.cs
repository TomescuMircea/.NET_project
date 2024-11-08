using Application.Utils;
using FluentValidation;

namespace Application.Use_Cases.Commands.ApartmentC
{
    public class CreateApartmentCommandValidator : AbstractValidator<CreateApartmentCommand>
    {
        public CreateApartmentCommandValidator()
        {
            RuleFor(x => x.EstateId).NotEmpty().Must(GuidValidator.BeAValidGuid).WithMessage("'EstateId' must be a valid Guid");
            RuleFor(x => (int)x.RoomNumber).GreaterThan(0);
            RuleFor(x => (int)x.FloorNumber).GreaterThanOrEqualTo(0);
            RuleFor(x => x.FullySeparated).NotNull();
        }
    }
}
