using Application.Use_Cases.Commands.ReportC;
using Application.Use_Cases.Commands.ReviewPropertyC;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SmartRealEstateManagementSystem.Controllers
{
    [Route("api/review-properties")]
    [ApiController]
    public class ReviewsPropertiesController : ControllerBase
    {
        private readonly IMediator mediator;
        public ReviewsPropertiesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Result<Guid>>> CreateReviewsProperties(CreateReviewPropertyCommand command)
        {
            var result = await mediator.Send(command) as Result<Guid>;
            return Ok(result);
        }
    }
}
