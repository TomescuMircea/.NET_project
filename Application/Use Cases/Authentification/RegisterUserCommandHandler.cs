using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Org.BouncyCastle.Crypto.Generators;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
{
    private readonly IUserRepository repository;

    public RegisterUserCommandHandler(IUserRepository repository) => this.repository = repository;

    public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = new Credential
        {
            Email = request.Email,
            UserName = request.Username,
            Password = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };

        await repository.Register(user, cancellationToken);
        return user.UserId;
    }
}
