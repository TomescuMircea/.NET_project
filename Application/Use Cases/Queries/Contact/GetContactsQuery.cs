using Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Use_Cases.Queries.Contact
{
    public class GetContactsQuery : IRequest<List<ContactDto>>
    {
    }
}
