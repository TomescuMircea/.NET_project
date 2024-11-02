using MediatR;

namespace SmartRealEstateManagementSystem.Controllers
{
    public class DeleteEstateCommand(Guid id) : IRequest
    {
    }
}