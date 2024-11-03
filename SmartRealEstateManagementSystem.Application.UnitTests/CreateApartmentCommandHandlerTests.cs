using Application.Use_Cases.CommandHandlers.ApartmentCH;
using Application.Use_Cases.Commands.ApartmentC;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using NSubstitute;

namespace SmartRealEstateManagementSystem.Application.UnitTests
{
    public class CreateAppartmentCommandHandlerTests
    {
        private readonly IApartmentRepository _appartmentRepository;
        private readonly IEstateRepository _estateRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly CreateApartmentCommandHandler _handler;

        public CreateAppartmentCommandHandlerTests()
        {
            _appartmentRepository = Substitute.For<IApartmentRepository>();
            _estateRepository = Substitute.For<IEstateRepository>();
            _userRepository = Substitute.For<IUserRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new CreateApartmentCommandHandler(_appartmentRepository, _mapper);
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
            var estate = new Estate
            {
                Id = new Guid("fb0c0cbf-cf67-4cc8-babc-63d8b24862b7"),
                Name = "Appartment Name",
                Description = "Appartment Description",
                Address = "Appartment Address",
                Price = 100000,
                Size = 70,
                Type = "House",
                Status = "Active",
                ListingData = DateTime.Now,
            };

            var appartment = new Apartment
            {
                EstateId = estate.Id,
                RoomNumber = 3,
                FloorNumber = 2,
                FullySeparated = true,
            };
            var command = new CreateApartmentCommand
            {
                EstateId = estate.Id,
                RoomNumber = 3,
                FloorNumber = 2,
                FullySeparated = true,
            };

            _estateRepository.AddAsync(estate).Returns(Result<Guid>.Success(estate.Id));
            _userRepository.AddAsync(user).Returns(Result<Guid>.Success(user.Id));
            _mapper.Map<Apartment>(command).Returns(appartment);
            _appartmentRepository.AddAsync(appartment).Returns(Result<Guid>.Success(appartment.EstateId));

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Data.Should().Be(appartment.EstateId);
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
            var estate = new Estate
            {
                Id = new Guid("fb0c0cbf-cf67-4cc8-babc-63d8b24862b7"),
                Name = "Appartment Name",
                Description = "Appartment Description",
                Address = "Appartment Address",
                Price = 100000,
                Size = 70,
                Type = "House",
                Status = "Active",
                ListingData = DateTime.Now,
            };

            var appartment = new Apartment
            {
                EstateId = estate.Id,
                RoomNumber = 3,
                FloorNumber = 2,
                FullySeparated = true,
            };
            var command = new CreateApartmentCommand
            {
                EstateId = estate.Id,
                RoomNumber = 3,
                FloorNumber = 2,
                FullySeparated = true,
            };

            _estateRepository.AddAsync(estate).Returns(Result<Guid>.Success(estate.Id));
            _userRepository.AddAsync(user).Returns(Result<Guid>.Success(user.Id));
            _mapper.Map<Apartment>(command).Returns(appartment);
            _appartmentRepository.AddAsync(appartment).Returns(Result<Guid>.Failure("Error"));

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Data.Should().Be(Guid.Empty);
            result.ErrorMessage.Should().Be("Error");
        }
    }
}

