using Application.Use_Cases.Commands.ImageC;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SmartRealEstateManagementSystem.Controllers
{
    [Route("api/image")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IMediator mediator;
        public ImagesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Result<Guid>>> CreateImage(CreateImageCommand command)
        {
            var result = await mediator.Send(command) as Result<Guid>;
            return Ok(result);
        }
    }
}
