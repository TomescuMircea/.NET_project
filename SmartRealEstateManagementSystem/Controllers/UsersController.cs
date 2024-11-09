using Application.DTO;
using Application.Use_Cases.Commands.UserC;
using Application.Use_Cases.Queries.UserQ;
using Domain.Common;
using Domain.Entities;
using MediatR;
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
        public async Task<ActionResult<Result<Guid>>> UpdateUser(Guid id, UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("The id should be identical with command.Id");
            }
            var result = await mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }
            return StatusCode(StatusCodes.Status200OK, result.Data);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllAsync()
        {
            var result = await mediator.Send(new GetUsersQuery());
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserDto>> GetUserById(Guid id)
        {
            return await mediator.Send(new GetUserByIdQuery { Id = id });
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Result<Guid>>> DeleteUser(Guid id)
        {
            var result = await mediator.Send(new DeleteUserCommand(id));
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }
            return StatusCode(StatusCodes.Status200OK, result.Data);
        }

    }
}
