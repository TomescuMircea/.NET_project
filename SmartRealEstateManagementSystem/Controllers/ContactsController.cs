using Application.DTO;
using Application.Use_Cases.Commands.ContactC;
using Application.Use_Cases.Queries.Contact;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SmartRealEstateManagementSystem.Controllers
{
    [Route("api/contacts")]
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
            var result = await mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }
            return StatusCode(StatusCodes.Status201Created, result.Data);
        }

       

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ContactDto>> GetContactById(Guid id)
        {
            var query = new GetContactByIdQuery { Id = id };
            return await mediator.Send(query);
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactDto>>> GetContacts()
        {
            return await mediator.Send(new GetContactsQuery());
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Result<Guid>>> UpdateContact(Guid id, UpdateContactCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("The id should be identical with command.Id");
            }
           var result=await mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }
            return StatusCode(StatusCodes.Status200OK, result.Data);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Result<Guid>>> DeleteContact(Guid id)
        {
            var result = await mediator.Send(new DeleteContactCommand(id));
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }
            return StatusCode(StatusCodes.Status200OK, result.Data);
        }
    }
}
