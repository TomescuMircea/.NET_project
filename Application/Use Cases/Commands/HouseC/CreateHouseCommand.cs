using Domain.Common;
using MediatR;

namespace Application.Use_Cases.Commands.HouseC
{
    public class CreateHouseCommand : IRequest<Result<Guid>>
    {
        public Guid EstateId { get; set; }
        public decimal OutsideAreaSize { get; set; }
    }
}
