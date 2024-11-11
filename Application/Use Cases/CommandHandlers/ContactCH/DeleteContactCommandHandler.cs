using Application.Use_Cases.Commands.ContactC;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Use_Cases.CommandHandlers.ContactCH
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, Result<Guid>>
    {
        private readonly IGenericEntityRepository<Contact> repository;
        public DeleteContactCommandHandler(IGenericEntityRepository<Contact> repository) 
        {
            this.repository = repository;
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
