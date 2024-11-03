using Domain.Common;
using MediatR;

namespace Application.Use_Cases.Commands.CredentialC
{
    public class CreateCredentialCommand : IRequest<Result<Guid>>
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
