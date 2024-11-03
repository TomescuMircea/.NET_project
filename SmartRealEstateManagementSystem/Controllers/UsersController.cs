using Application.Use_Cases.Commands.EstateC;
using Application.Use_Cases.Commands.UserC;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SmartRealEstateManagementSystem.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;
        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Result<Guid>>> CreateUser(CreateUserCommand command)
        {
            return await mediator.Send(command);
        }
    }
}
