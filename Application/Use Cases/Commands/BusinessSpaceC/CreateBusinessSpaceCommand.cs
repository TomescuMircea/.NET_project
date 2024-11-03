using Domain.Common;
using MediatR;

namespace Application.Use_Cases.Commands.BusinessSpaceC
{
    public class CreateBusinessSpaceCommand : IRequest<Result<Guid>>
    {
        public Guid EstateId { get; set; }
        public decimal FloorNumber { get; set; }
    }
}
