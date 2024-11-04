using Domain.Entities;
using MediatR;

namespace Application.Use_Cases.Queries.UserQ
{
    public class GetUsersQuery : IRequest<List<User>>
    {

    }
}
