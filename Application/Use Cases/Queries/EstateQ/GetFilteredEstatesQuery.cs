using Application.DTO;
using Application.Utils;
using Domain.Common;
using MediatR;

namespace Application.Use_Cases.Queries.EstateQ
{
    public class GetFilteredEstatesQuery : IRequest<Result<PagedResult<EstateDto>>>
    {
        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
