using Application.DTO;
using Application.Use_Cases.Queries.UserQ;
using Application.Use_Cases.QueryHandlers.UserQH;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using NSubstitute;

namespace SmartRealEstateManagementSystem.Application.UnitTests
{
    public class GetUsersQueryHandlerTests
    {
        private readonly IGenericEntityRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly GetUsersQueryHandler _handler;

        public GetUsersQueryHandlerTests()
        {
            _userRepository = Substitute.For<IGenericEntityRepository<User>>();
            _mapper = Substitute.For<IMapper>();
            _handler = new GetUsersQueryHandler(_userRepository, _mapper);
        }

        [Fact]
        public void Given_GetUsersQueryHandler_When_HandleIsCalled_Then_AListOfUsersShouldBeReturned()
        {
            // Arrange
            List<User> users = GenerateUsers();
            _userRepository.GetAllAsync().Returns(users);
            var query = new GetUsersQuery();
            GenerateUsersDto(users);

            // Act
            var result = _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            Assert.Equal(2, result.Result.Count);
            Assert.Equal(users[0].Id, result.Result[0].Id);
            Assert.Equal(users[1].Id, result.Result[1].Id);
        }

        private void GenerateUsersDto(List<User> users)
        {
            _mapper.Map<List<UserDto>>(users).Returns(new List<UserDto>
            {
                new UserDto
                {
                    Id = users[0].Id,
                    Type = users[0].Type,
                    FirstName = users[0].FirstName,
                    LastName = users[0].LastName,
                    Status = users[0].Status
                },
                new UserDto
                {
                    Id = users[1].Id,
                    Type = users[1].Type,
                    FirstName = users[1].FirstName,
                    LastName = users[1].LastName,
                    Status = users[1].Status
                }
            });
        }

        private List<User> GenerateUsers()
        {
            return new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    Type = "Admin",
                    FirstName = "John",
                    LastName = "Doe",
                    Status = "Active"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Type = "User",
                    FirstName = "Jane",
                    LastName = "Smith",
                    Status = "Inactive"
                }
            };
        }
    }
}
