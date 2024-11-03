using Application.Use_Cases.Commands.HouseC;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SmartRealEstateManagementSystem.Controllers
{
    [Route("api/house")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly IMediator mediator;
        public HouseController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Result<Guid>>> CreateHouse(CreateHouseCommand command)
        {
            var result = await mediator.Send(command) as Result<Guid>;
            return Ok(result);
        }
    }
}
