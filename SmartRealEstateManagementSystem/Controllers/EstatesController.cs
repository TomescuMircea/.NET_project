﻿using Application.DTO;
using Application.Use_Cases.Commands.EstateC;
using Application.Use_Cases.Queries.EstateQ;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
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
            return await mediator.Send(query);
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
        public async Task<ActionResult<Result<Guid>>> DeleteEstate(Guid id)
        {
            var result = await mediator.Send(new DeleteEstateCommand(id));
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }
            return StatusCode(StatusCodes.Status200OK, result.Data);
        }
    }
}

