using Application.Use_Cases.Commands.EstateC;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Use_Cases.CommandHandlers.EstateCH
{
    public class DeleteEstateCommandHandler : IRequestHandler<DeleteEstateCommand, Result<Guid>>
    {
        private readonly IGenericEntityRepository<Estate> repository;
        private readonly IMapper mapper;
        public DeleteEstateCommandHandler(IGenericEntityRepository<Estate> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(DeleteEstateCommand request, CancellationToken cancellationToken)
        {
            var result = await repository.DeleteAsync(request.Id);

            if (result.IsSuccess)
            {
                return Result<Guid>.Success(result.Data);
            }
            return Result<Guid>.Failure(result.ErrorMessage);
        }
    }
}
