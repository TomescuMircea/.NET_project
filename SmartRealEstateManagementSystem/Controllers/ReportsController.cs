using Application.Use_Cases.Commands.ImageC;
using Application.Use_Cases.Commands.ReportC;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SmartRealEstateManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IMediator mediator;
        public ReportsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Result<Guid>>> CreateImage(CreateReportCommand command)
        {
            var result = await mediator.Send(command) as Result<Guid>;
            return Ok(result);
        }
    }
}
