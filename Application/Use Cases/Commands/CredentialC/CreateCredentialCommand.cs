using Domain.Common;
using MediatR;

namespace Application.Use_Cases.Commands.CredentialC
{
    public class CreateCredentialCommand : IRequest<Result<Guid>>
    {
        public Guid UserId { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

    }
}
