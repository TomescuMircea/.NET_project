using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Application.Use_Cases.Commands.EstateC;

namespace Application.Use_Cases.CommandHandlers.EstateCH
{
    public class UpdateEstateCommandHandler : IRequestHandler<UpdateEstateCommand>
    {
        private readonly IEstateRepository repository;
        private readonly IMapper mapper;

        public UpdateEstateCommandHandler(IEstateRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task Handle(UpdateEstateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //var estate = mapper.Map<Estate>(request);
            //var result = await repository.UpdateAsync(estate);
            //if (result.IsSuccess)
            //{
            //    return Result<Guid>.Success(result.Data);
            //}
            //return Result<Guid>.Failure(result.ErrorMessage);
        }
    }
}
