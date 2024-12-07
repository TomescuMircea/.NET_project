using Application.Use_Cases.Queries.EstateQ;
using Domain.Entities;
using System.Text;

public class TypeFilterStrategy : IFilterStrategy
{
    public void ApplyFilter(StringBuilder sqlQuery, GetEstatesPaginationByFilterQuery request)
    {
        if (!string.IsNullOrEmpty(request.Type))
        {
            sqlQuery.Append(" AND LOWER(\"Type\") LIKE LOWER('%").Append(request.Type).Append("%')");
        }
    }
}
