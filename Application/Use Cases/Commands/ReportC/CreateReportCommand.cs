using Domain.Common;
using MediatR;

namespace Application.Use_Cases.Commands.ReportC
{
    public class CreateReportCommand : IRequest<Result<Guid>>
    {
        public Guid BuyerId { get; set; }
        public Guid SellerId { get; set; }
        public string Description { get; set; }
    }
}
