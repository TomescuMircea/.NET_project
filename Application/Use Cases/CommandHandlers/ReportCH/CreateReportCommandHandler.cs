﻿using Application.Use_Cases.Commands.ImageC;
using Application.Use_Cases.Commands.ReportC;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Use_Cases.CommandHandlers.ReportCH
{
    public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, Result<Guid>>
    {
        private readonly IReportRepository repository;
        private readonly IMapper mapper;

        public CreateReportCommandHandler(IReportRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Result<Guid>> Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            var report = mapper.Map<Report>(request);
            var result = await repository.AddAsync(report);
            return Result<Guid>.Success(result.Data);
        }
    }
}
