﻿using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<string>>
{
    private readonly IUserRepository userRepository;

    public LoginUserCommandHandler(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<Result<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Email = request.Email,
            Password = request.Password
        };
        var token = await userRepository.Login(user);
        return token;
    }
}
