using Application.Use_Cases.Queries.EstateQ;
using Domain.Entities;
using System.Text;

public class SizeFilterStrategy : IFilterStrategy
{
    public void ApplyFilter(StringBuilder sqlQuery, GetEstatesPaginationByFilterQuery request)
    {
        if (request.Size > 0)
        {
            sqlQuery.Append(" AND \"Size\" = ").Append(request.Size);
        }
    }
}
