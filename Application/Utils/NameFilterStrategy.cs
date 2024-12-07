using Application.Use_Cases.Queries.EstateQ;
using Domain.Entities;

public class NameFilterStrategy : IFilterStrategy
{
    public IQueryable<Estate> ApplyFilter(IQueryable<Estate> query, GetEstatesPaginationByFilterQuery request)
    {
        if (!string.IsNullOrEmpty(request.Name))
        {
            query = query.Where(e => e.Name.Contains(request.Name));
        }
        return query;
    }
}
