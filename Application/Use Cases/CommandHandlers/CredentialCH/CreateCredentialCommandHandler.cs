﻿using Application.Use_Cases.Commands.CredentialC;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Use_Cases.CommandHandlers.CredentialCH
{
    public class CreateCredentialCommandHandler : IRequestHandler<CreateCredentialCommand, Result<Guid>>
    {
        private readonly ICredentialRepository repository;
        private readonly IMapper mapper;

        public CreateCredentialCommandHandler(ICredentialRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Result<Guid>> Handle(CreateCredentialCommand request, CancellationToken cancellationToken)
        {
            var credential = mapper.Map<Credential>(request);
            return await repository.AddAsync(credential);
        }
    }
}