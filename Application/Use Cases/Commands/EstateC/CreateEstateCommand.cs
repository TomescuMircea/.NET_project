using Domain.Common;
using MediatR;

namespace Application.Use_Cases.Commands.EstateC
{
    public class CreateEstateCommand : IRequest<Result<Guid>>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Address { get; set; }
        public decimal Size { get; set; }

        public string Type { get; set; }
        public string Status { get; set; }
        public DateTime ListingData { get; set; }
    }
}