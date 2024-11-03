using Domain.Common;
using MediatR;

namespace Application.Use_Cases.Commands.ApartmentC
{
    public class CreateApartmentCommand : IRequest<Result<Guid>>
    {
        public Guid EstateId { get; set; }
        public short RoomNumber { get; set; }
        public short FloorNumber { get; set; }
        public bool FullySeparated { get; set; }
    }
}
