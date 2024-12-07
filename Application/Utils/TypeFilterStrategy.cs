using Application.Use_Cases.Queries.EstateQ;
using Domain.Entities;

public class TypeFilterStrategy : IFilterStrategy
{
    public IQueryable<Estate> ApplyFilter(IQueryable<Estate> query, GetEstatesPaginationByFilterQuery request)
    {
        if (!string.IsNullOrEmpty(request.Type))
        {
            query = query.Where(e => e.Type.Contains(request.Type));
        }
        return query;
    }
}