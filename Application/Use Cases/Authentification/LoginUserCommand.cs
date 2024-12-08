using Domain.Common;
using MediatR;

public class LoginUserCommand : IRequest<Result<string>>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }
   
}
