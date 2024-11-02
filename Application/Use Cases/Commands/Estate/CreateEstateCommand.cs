using Domain.Common;
using MediatR;

namespace SmartRealEstateManagementSystem.Controllers
{
    public class CreateEstateCommand: IRequest<Result<Guid>>
    {
    }
}