using Application.Use_Cases.Commands.ContactC;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Use_Cases.CommandHandlers.ContactCH
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Result<Guid>>
    {
        private readonly IContactRepository repository;
        private readonly IMapper mapper;

        public CreateContactCommandHandler(IContactRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Result<Guid>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = mapper.Map<Contact>(request);
            return await repository.AddAsync(contact);
        }
    }
}
