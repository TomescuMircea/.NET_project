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
    public class GetUserByIdQueryHandlerTests
    {
        private readonly IGenericEntityRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly GetUserByIdQueryHandler _handler;

        public GetUserByIdQueryHandlerTests()
        {
            _userRepository = Substitute.For<IGenericEntityRepository<User>>();
            _mapper = Substitute.For<IMapper>();
            _handler = new GetUserByIdQueryHandler(_userRepository, _mapper);
        }

        [Fact]
        public void Given_GetUserByIdQueryHandler_When_HandleIsCalled_Then_TheUserShouldBeReturned()
        {
            // Arrange
            var user = new User
            {
                Id = new Guid("d2aca8c8-ea05-4303-ad6f-83b41d71f97c"),
                Type = "Admin",
                FirstName = "John",
                LastName = "Doe",
                Status = "Active"
            };
            _userRepository.GetByIdAsync(user.Id).Returns(user);
            var query = new GetUserByIdQuery { Id = user.Id };
            var userDto = new UserDto
            {
                Id = user.Id,
                Type = user.Type,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Status = user.Status
            };
            _mapper.Map<UserDto>(user).Returns(userDto);

            // Act
            var result = _handler.Handle(query, CancellationToken.None).Result;

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(user.Id);
            result.Type.Should().Be(user.Type);
            result.FirstName.Should().Be(user.FirstName);
            result.LastName.Should().Be(user.LastName);
            result.Status.Should().Be(user.Status);
        }

        [Fact]
        public void Given_GetUserByIdQueryHandler_When_HandleIsCalledWithInexistentId_Then_ShouldReturnNull()
        {
            // Arrange
            var query = new GetUserByIdQuery { Id = new Guid("d2aca8c8-ea05-4303-ad6f-83b41d71f97c") };
            _userRepository.GetByIdAsync(query.Id).Returns((User)null);

            // Act
            var result = _handler.Handle(query, CancellationToken.None).Result;

            // Assert
            result.Should().BeNull();
        }
    }
}
