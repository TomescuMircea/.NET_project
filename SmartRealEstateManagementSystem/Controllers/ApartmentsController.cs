﻿using Application.Use_Cases.Commands.ApartmentC;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SmartRealEstateManagementSystem.Controllers
{
    [Route("api/apartment")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly IMediator mediator;
        public ApartmentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Result<Guid>>> CreateApartment(CreateApartmentCommand command)
        {
            return await mediator.Send(command);
        }
    }

    
}