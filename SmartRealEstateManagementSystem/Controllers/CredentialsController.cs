using Application.Use_Cases.Commands.CredentialC;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SmartRealEstateManagementSystem.Controllers
{
    [Route("api/credential")]
    [ApiController]
    public class CredentialsController : ControllerBase
    {
        private readonly IMediator mediator;
        public CredentialsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Result<Guid>>> CreateContact(CreateCredentialCommand command)
        {
            return await mediator.Send(command);
        }
    }
}
