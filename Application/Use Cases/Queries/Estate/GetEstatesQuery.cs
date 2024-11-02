using Application.DTO;
using MediatR;

namespace SmartRealEstateManagementSystem.Controllers
{
    public class GetEstateQuery : IRequest<List<EstateDto>>
    {
    }
}