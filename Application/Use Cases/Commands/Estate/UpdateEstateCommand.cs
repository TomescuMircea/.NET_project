using MediatR;

namespace SmartRealEstateManagementSystem.Controllers
{
    public class UpdateEstateCommand: CreateEstateCommand, IRequest
    {
        public Guid Id { get; set; }
    }
}