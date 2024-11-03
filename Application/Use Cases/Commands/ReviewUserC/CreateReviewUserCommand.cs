using Domain.Common;
using MediatR;

namespace Application.Use_Cases.Commands.ReviewUserC
{
    public class CreateReviewUserCommand : IRequest<Result<Guid>>
    {
        public Guid BuyerId { get; set; }
        public Guid SellerId { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
    }
}
