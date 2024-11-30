using Application.DTO;
using MediatR;

namespace Application.Use_Cases.Queries.EstateQ
{
    public class GetEstateByFilterQuery : IRequest<List<EstateDto>>
    {
        public decimal Price { get; set; }
        public decimal Size { get; set; }
        public string? Address { get; set; }
        public string? Type { get; set; }
    }

}
