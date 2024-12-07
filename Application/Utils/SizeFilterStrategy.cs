using Application.Use_Cases.Queries.EstateQ;
using Domain.Entities;

public class SizeFilterStrategy : IFilterStrategy
{
    public IQueryable<Estate> ApplyFilter(IQueryable<Estate> query, GetEstatesPaginationByFilterQuery request)
    {
        if (request.Size > 0)
        {
            query = query.Where(e => e.Size == request.Size);
        }
        return query;
    }
}