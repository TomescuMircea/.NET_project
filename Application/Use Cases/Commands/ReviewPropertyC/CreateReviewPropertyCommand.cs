using Domain.Common;
using MediatR;

namespace Application.Use_Cases.Commands.ReviewPropertyC
{
    public class CreateReviewPropertyCommand : IRequest<Result<Guid>>
    {
        public Guid EstateId { get; set; }
        public Guid BuyerId { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
    }
}
