using Application.Use_Cases.Commands.ContactC;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using MediatR;


namespace Application.Use_Cases.CommandHandlers.ContactCH
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Result<Guid>>
    {
        private readonly IGenericEntityRepository<Contact> repository;
        private readonly IMapper mapper;

        public UpdateContactCommandHandler(IGenericEntityRepository<Contact> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Task<Result<Guid>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = mapper.Map<Contact>(request);
            return repository.UpdateAsync(contact);
        }
    }
}
