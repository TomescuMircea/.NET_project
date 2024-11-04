using Application.Use_Cases.Commands.EstateC;
using Application.Use_Cases.Commands.UserC;
using Application.Use_Cases.Queries.UserQ;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace SmartRealEstateManagementSystem.Controllers
{
    [Route("api/users")]
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
            var result = await mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }
            return StatusCode(StatusCodes.Status201Created, result.Data);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateBook(Guid id, UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("The id should be identical with command.Id");
            }
            await mediator.Send(command);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllAsync()
        {
            return await mediator.Send(new GetUsersQuery());
        }

    }
}
