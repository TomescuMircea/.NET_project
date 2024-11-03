using Application.Use_Cases.Commands.ContactC;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SmartRealEstateManagementSystem.Controllers
{
    [Route("api/contact")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator mediator;
        public ContactsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Result<Guid>>> CreateContact(CreateContactCommand command)
        {
            return await mediator.Send(command);
        }
    }
}
