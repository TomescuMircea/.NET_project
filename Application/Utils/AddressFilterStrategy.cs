using Application.Use_Cases.Queries.EstateQ;
using Domain.Entities;
using System.Text;

public class AddressFilterStrategy : IFilterStrategy
{
    public void ApplyFilter(StringBuilder sqlQuery, GetEstatesPaginationByFilterQuery request)
    {
        if (!string.IsNullOrEmpty(request.Address))
        {
            sqlQuery.Append(" AND LOWER(\"Address\") LIKE LOWER('%").Append(request.Address).Append("%')");
        }
    }
}
