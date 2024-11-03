using Application.Use_Cases.Commands.ReviewUserC;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SmartRealEstateManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsUsersController : ControllerBase
    {
        private readonly IMediator mediator;
        public ReviewsUsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Result<Guid>>> CreateReviewsUser(CreateReviewUserCommand command)
        {
            var result = await mediator.Send(command) as Result<Guid>;
            return Ok(result);
        }
    }
}
