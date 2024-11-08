using MediatR;

namespace Application.Use_Cases.Commands.UserC
{
    public class UpdateUserCommand : CreateUserCommand, IRequest
    {
        public Guid Id { get; set; }
    }
}
