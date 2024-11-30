using Application.DTO;
using Application.Use_Cases.Commands.EstateC;
using Application.Use_Cases.Queries.EstateQ;
using Application.Utils;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SmartRealEstateManagementSystem.Controllers
{
    [Route("api/estates")]
    [ApiController]
    public class EstatesController : ControllerBase
    {
        private readonly IMediator mediator;
        public EstatesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Result<Guid>>> CreateEstate(CreateEstateCommand command)
        {
            var result = await mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }
            return StatusCode(StatusCodes.Status201Created, result.Data);
        }

        [HttpGet]
        public async Task<ActionResult<List<EstateDto>>> GetEstates()
        {
            return await mediator.Send(new GetEstatesQuery());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EstateDto>> GetEstateById(Guid id)
        {
            var query = new GetEstateByIdQuery { Id = id };
            var result = await mediator.Send(query);
            if (result == null)
            {
                return BadRequest("Estate not found");
            }
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Result<Guid>>> UpdateEstate(Guid id, UpdateEstateCommand command)
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

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Result<Guid>>> DeleteEstate(Guid id)
        {
            var result = await mediator.Send(new DeleteEstateCommand(id));
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }
            return StatusCode(StatusCodes.Status200OK, result.Data);
        }

        [HttpGet("paginated")]
        public async Task<ActionResult<PagedResult<EstateDto>>> GetFilteredEstates([FromQuery] int page, [FromQuery] int pageSize)
        {
            var query = new GetFilteredEstatesQuery
            {
                Page = page,
                PageSize = pageSize
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}

