using Application.Use_Cases.Commands.BusinessSpaceC;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SmartRealEstateManagementSystem.Controllers
{
    [Route("api/business-space")]
    [ApiController]
    public class BusinessSpacesController : ControllerBase
    {
        private readonly IMediator mediator;
        public BusinessSpacesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Result<Guid>>> CreateBusinessSpace(CreateBusinessSpaceCommand command)
        {
            var result = await mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }
            return StatusCode(StatusCodes.Status201Created, result.Data);
        }
    }
}
