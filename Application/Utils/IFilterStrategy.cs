using Application.Use_Cases.Queries.EstateQ;
using Domain.Entities;

public interface IFilterStrategy
{
    IQueryable<Estate> ApplyFilter(IQueryable<Estate> query, GetEstatesPaginationByFilterQuery request);
}
