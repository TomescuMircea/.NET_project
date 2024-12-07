using Application.Use_Cases.Queries.EstateQ;
using Domain.Entities;

public class PriceFilterStrategy : IFilterStrategy
{
    public IQueryable<Estate> ApplyFilter(IQueryable<Estate> query, GetEstatesPaginationByFilterQuery request)
    {
        if (request.Price > 0)
        {
            query = query.Where(e => e.Price == request.Price);
        }
        return query;
    }
}