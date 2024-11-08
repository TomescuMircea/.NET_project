﻿using Application.Use_Cases.Commands.ReportC;
using Application.Use_Cases.Commands.ReviewPropertyC;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Use_Cases.CommandHandlers.ReviewPropertyCH
{
    public class CreateReviewPropertyCommandHandler : IRequestHandler<CreateReviewPropertyCommand, Result<Guid>>
    {
        private readonly IGenericEntityRepository<ReviewProperty> repository;
        private readonly IMapper mapper;

        public CreateReviewPropertyCommandHandler(IGenericEntityRepository<ReviewProperty> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Result<Guid>> Handle(CreateReviewPropertyCommand request, CancellationToken cancellationToken)
        {
            var review = mapper.Map<ReviewProperty>(request);
            var result = await repository.AddAsync(review);
            if (result.IsSuccess)
            {
                return Result<Guid>.Success(result.Data);
            }
            return Result<Guid>.Failure(result.ErrorMessage);
        }
    }
}
