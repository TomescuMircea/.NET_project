using Application.DTO;
using Application.Use_Cases.Queries.Contact;
using Application.Use_Cases.Queries.EstateQ;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Use_Cases.QueryHandlers.ContactQH
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, ContactDto>
    {
        private readonly IGenericEntityRepository<Contact> repository;
        private readonly IMapper mapper;

        public GetContactByIdQueryHandler(IGenericEntityRepository<Contact> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<ContactDto> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var contact = await repository.GetByIdAsync(request.Id);
            return mapper.Map<ContactDto>(contact);

        }

       
    }
}
