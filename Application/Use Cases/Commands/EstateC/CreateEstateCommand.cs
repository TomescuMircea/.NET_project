using Domain.Common;
using MediatR;

namespace Application.Use_Cases.Commands.EstateC
{
    public class CreateEstateCommand : IRequest<Result<Guid>>
    {
        public Guid UserId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public required string Address { get; set; }
        public decimal Size { get; set; }

        public required string Type { get; set; }
        public required string Status { get; set; }
        public DateTime ListingData { get; set; }
    }
}