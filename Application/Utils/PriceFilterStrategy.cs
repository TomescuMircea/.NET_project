using Application.Use_Cases.Queries.EstateQ;
using Domain.Entities;
using System.Text;

public class PriceFilterStrategy : IFilterStrategy
{
    public void ApplyFilter(StringBuilder sqlQuery, GetEstatesPaginationByFilterQuery request)
    {
        if (request.Price > 0)
        {
            sqlQuery.Append(" AND \"Price\" = ").Append(request.Price);
        }
    }
}
