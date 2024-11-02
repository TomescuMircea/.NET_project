using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SmartRealEstateManagementSystem.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;
        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
