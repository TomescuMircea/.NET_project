

using Application.DTO;
using MediatR;

namespace Application.Use_Cases.Queries.Contact
{
    public class GetContactByIdQuery : IRequest<ContactDto>
    {
        public Guid Id { get; set; }
    }
}