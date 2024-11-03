using Domain.Common;
using MediatR;

namespace Application.Use_Cases.Commands.UserC
{
    public class CreateUserCommand : IRequest<Result<Guid>>
    {
        public string Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Status { get; set; }
    }
}
