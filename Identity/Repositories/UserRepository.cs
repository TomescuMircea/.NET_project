﻿using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersDbContext usersDbContext;
        private readonly IConfiguration configuration;
        private readonly IGenericEntityRepository<User> repository;

        public UserRepository(UsersDbContext usersDbContext, IConfiguration configuration, IGenericEntityRepository<User> repository)
        {
            this.usersDbContext = usersDbContext;
            this.configuration = configuration;
            this.repository = repository;
        }

        private bool VerifyPassword(string inputPassword, string storedPasswordHash)
        {
            return BCrypt.Net.BCrypt.Verify(inputPassword, storedPasswordHash);
        }

        public async Task<Result<string>> Login(User user)
        {
            var existingUser = await usersDbContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (existingUser == null || !VerifyPassword(user.Password, existingUser.Password))
            {
                return Result<string>.Failure("Invalid credentials");
            }
           
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, existingUser.Id.ToString()), // UserId
                new Claim(ClaimTypes.Name, existingUser.UserName), // Numele utilizatorului
                new Claim("email", existingUser.Email) // Email-ul utilizatorului (opțional)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Result<string>.Success($"{{\"token\": \"{tokenHandler.WriteToken(token)}\"}}");
        }
      
        public async Task<Guid> Register(User user, CancellationToken cancellationToken)
        {
            usersDbContext.Users.Add(user);
            await usersDbContext.SaveChangesAsync(cancellationToken);
            await repository.AddAsync(user);
            return user.Id;
        }
    }
}
