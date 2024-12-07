using Application.Use_Cases.Queries.EstateQ;
using System.Text;

public interface IFilterStrategy
{
    void ApplyFilter(StringBuilder sqlQuery, GetEstatesPaginationByFilterQuery request);
}
