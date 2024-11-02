using Application.DTO;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SmartRealEstateManagementSystem.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EstateController : ControllerBase
    {
        private readonly IMediator mediator;
        public EstateController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<EstateDto>>> GetEstates()
        {
            var query = new GetEstateQuery();
            return await mediator.Send(query);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EstateDto>> GetEstateById(Guid id)
        {
            var query = new GetEstateByIdQuery { Id = id };
            return await mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<Result<Guid>>> CreateEstate(CreateEstateCommand command)
        {
            return await mediator.Send(command);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateEstate(Guid id, UpdateEstateCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("The id should be identical with command.Id");
            }
            await mediator.Send(command);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await mediator.Send(new DeleteEstateCommand(id));
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
