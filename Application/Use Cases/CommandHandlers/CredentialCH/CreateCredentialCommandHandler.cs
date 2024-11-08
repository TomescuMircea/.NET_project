using Application.Use_Cases.Commands.CredentialC;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Use_Cases.CommandHandlers.CredentialCH
{
    public class CreateCredentialCommandHandler : IRequestHandler<CreateCredentialCommand, Result<Guid>>
    {
        private readonly IGenericEntityRepository<Credential> repository;
        private readonly IMapper mapper;

        public CreateCredentialCommandHandler(IGenericEntityRepository<Credential> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Result<Guid>> Handle(CreateCredentialCommand request, CancellationToken cancellationToken)
        {
            var credential = mapper.Map<Credential>(request);
            var result = await repository.AddAsync(credential);
            if (result.IsSuccess)
            {
                return Result<Guid>.Success(result.Data);
            }
            return Result<Guid>.Failure(result.ErrorMessage);
        }
    }
}
