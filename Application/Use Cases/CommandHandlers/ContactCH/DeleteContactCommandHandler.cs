using Application.Use_Cases.Commands.ContactC;
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

namespace Application.Use_Cases.CommandHandlers.ContactCH
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, Result<Guid>>
    {
        private readonly IGenericEntityRepository<Contact> repository;
        private readonly IMapper mapper;
        public DeleteContactCommandHandler(IGenericEntityRepository<Contact> repository, IMapper mapper) {

            this.repository = repository;
            this.mapper = mapper;

        }
        public async Task<Result<Guid>> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var result= await repository.DeleteAsync(request.Id);
            if (result.IsSuccess)
            {
                return Result<Guid>.Success(result.Data);
            }
           return Result<Guid>.Failure(result.ErrorMessage);
        }
    }
}
