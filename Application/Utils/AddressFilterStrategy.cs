using Application.Use_Cases.Queries.EstateQ;
using Domain.Entities;

public class AddressFilterStrategy : IFilterStrategy
{
    public IQueryable<Estate> ApplyFilter(IQueryable<Estate> query, GetEstatesPaginationByFilterQuery request)
    {
        if (!string.IsNullOrEmpty(request.Address))
        {
            query = query.Where(e => e.Address.Contains(request.Address));
        }
        return query;
    }
}