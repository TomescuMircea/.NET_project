using Application.DTO;
using Application.Use_Cases.Queries.Contact;
using Application.Use_Cases.Queries.EstateQ;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;


namespace Application.Use_Cases.QueryHandlers.ContactQH
{
    public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, List<ContactDto>>
    {
        private readonly IGenericEntityRepository<Contact> repository;
        private readonly IMapper mapper;

        public GetContactsQueryHandler(IGenericEntityRepository<Contact> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<ContactDto>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = await repository.GetAllAsync();
            return mapper.Map<List<ContactDto>>(contacts);

        }
    }
}
