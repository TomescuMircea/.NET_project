using Application.Use_Cases.CommandHandlers.EstateCH;
using Application.Use_Cases.Commands.EstateC;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using NSubstitute;

namespace SmartRealEstateManagementSystem.Application.UnitTests
{
    public class CreateEstateCommandHandlerTests
    {
        private readonly IGenericEntityRepository<Estate> _estateRepository;
        private readonly IGenericEntityRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly CreateEstateCommandHandler _handler;

        public CreateEstateCommandHandlerTests()
        {
            _estateRepository = Substitute.For<IGenericEntityRepository<Estate>>();
            _userRepository = Substitute.For<IGenericEntityRepository<User>>();
            _mapper = Substitute.For<IMapper>();
            _handler = new CreateEstateCommandHandler(_estateRepository, _mapper);
        }
        [Fact]
        public async Task Given_ValidCommand_When_HandleIsCalled_Then_ShouldReturnSuccessResult()
        {
            // Arrange
            var user = new User
            {
                Id = new Guid("fb0c0cbf-cf67-4cc8-babc-63d8b24862b7"),
                Type = "f",
                FirstName = "John",
                LastName = "Doe",
                Status = "Active"
            };

            var command = new CreateEstateCommand
            {
                UserId = user.Id,
                Name = "Estate Name",
                Description = "Estate Description",
                Address = "Estate Address",
                Price = 100000,
                Type = "1",
                Status = "Active"
            };
            var estate = new Estate
            {
                Id = new Guid("4fd3f7f1-fd01-4731-8c3d-e865306e0d91"),
                UserId = command.UserId,
                Name = command.Name,
                Description = command.Description,
                Address = command.Address,
                Price = command.Price,
                Size = 70,
                Type = "House",
                Status = "Active",
                ListingData = DateTime.Now,
            };
            _mapper.Map<Estate>(command).Returns(estate);
            _userRepository.AddAsync(user).Returns(Result<Guid>.Success(user.Id));
            _estateRepository.AddAsync(estate).Returns(Result<Guid>.Success(estate.Id));

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Data.Should().Be(estate.Id);
            result.ErrorMessage.Should().BeNull();
        }
        [Fact]
        public async Task Given_InvalidCommand_When_HandleIsCalled_Then_ShouldReturnFailureResult()
        {
            // Arrange
            var user = new User
            {
                Id = new Guid("fb0c0cbf-cf67-4cc8-babc-63d8b24862b7"),
                Type = "f",
                FirstName = "John",
                LastName = "Doe",
                Status = "Active"
            };

            var command = new CreateEstateCommand
            {
                UserId = user.Id,
                Name = "Estate Name",
                Description = "Estate Description",
                Address = "Estate Address",
                Price = 100000,
                Type = "1",
                Status = "Active"
            };
            var estate = new Estate
            {
                Id = new Guid("4fd3f7f1-fd01-4731-8c3d-e865306e0d91"),
                UserId = command.UserId,
                Name = command.Name,
                Description = command.Description,
                Address = command.Address,
                Price = command.Price,
                Size = 70,
                Type = "House",
                Status = "Active",
                ListingData = DateTime.Now,
            };
            _mapper.Map<Estate>(command).Returns(estate);
            _estateRepository.AddAsync(estate).Returns(Result<Guid>.Failure("Error"));

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Data.Should().Be(Guid.Empty);
            result.ErrorMessage.Should().Be("Error");
        }
    }
}