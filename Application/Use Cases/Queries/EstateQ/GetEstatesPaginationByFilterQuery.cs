using Application.DTO;
using Application.Utils;
using Domain.Common;
using MediatR;

namespace Application.Use_Cases.Queries.EstateQ
{
    public class GetEstatesPaginationByFilterQuery : IRequest<Result<PagedResult<EstateDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public decimal Price { get; set; }
        public decimal Size { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Type { get; set; }
    }
}
