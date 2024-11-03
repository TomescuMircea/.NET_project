using Domain.Common;
using MediatR;

namespace Application.Use_Cases.Commands.PayC
{
    public class CreatePayCommand : IRequest<Result<Guid>>
    {
        public Guid SellerGuid { get; set; }
        public Guid BuyerGuid { get; set; }
        public Guid EstateGuid { get; set; }
    }
}
