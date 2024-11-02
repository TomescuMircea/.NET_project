using Application.DTO;
using MediatR;

namespace SmartRealEstateManagementSystem.Controllers
{
    public class GetEstateByIdQuery : IRequest<EstateDto>
    {
        public Guid Id { get; set; }
    }
}