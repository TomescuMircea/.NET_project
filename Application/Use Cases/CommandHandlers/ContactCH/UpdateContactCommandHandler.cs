using Application.Use_Cases.Commands.ContactC;
using Application.Use_Cases.Commands.EstateC;
using AutoMapper;
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
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
    {
        private readonly IGenericEntityRepository<Contact> repository;
        private readonly IMapper mapper;

        public UpdateContactCommandHandler(IGenericEntityRepository<Contact> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = mapper.Map<Contact>(request);
            return repository.UpdateAsync(contact);
        }
    }
}
