using Application.Use_Cases.Queries.EstateQ;
using Domain.Entities;
using System.Text;

public class NameFilterStrategy : IFilterStrategy
{
    public void ApplyFilter(StringBuilder sqlQuery, GetEstatesPaginationByFilterQuery request)
    {
        if (!string.IsNullOrEmpty(request.Name))
        {
            sqlQuery.Append(" AND LOWER(\"Name\") LIKE LOWER('%").Append(request.Name).Append("%')");
        }
    }
}
