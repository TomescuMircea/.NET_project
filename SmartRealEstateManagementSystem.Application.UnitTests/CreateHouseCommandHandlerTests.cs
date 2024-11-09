using Application.Use_Cases.CommandHandlers.ApartmentCH;
using Application.Use_Cases.CommandHandlers.HouseCH;
using Application.Use_Cases.Commands.ApartmentC;
using Application.Use_Cases.Commands.HouseC;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SmartRealEstateManagementSystem.Application.UnitTests
{
    public class CreateHouseCommandHandlerTests
    {
        private readonly IGenericEntityRepository<House> _houseRepository;
        private readonly IGenericEntityRepository<Estate> _estateRepository;
        private readonly IGenericEntityRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly CreateHouseCommandHandler _handler;
        public CreateHouseCommandHandlerTests()
        {
            _houseRepository = Substitute.For<IGenericEntityRepository<House>>();
            _estateRepository = Substitute.For<IGenericEntityRepository<Estate>>();
            _userRepository = Substitute.For<IGenericEntityRepository<User>>();
            _mapper = Substitute.For<IMapper>();
            _handler = new CreateHouseCommandHandler(_houseRepository, _mapper);
        }



        [Fact]
        public async Task Given_ValidCommand_When_HandleIsCalled_Then_ShouldReturnSuccessResult()
        {
            //Arrange
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
                Name = "House Name",
                Description = "House Description",
                Address = "House Address",
                Price = 100000,
                Size = 70,
                Type = "House",
                Status = "Active",
                ListingData = DateTime.Now,
            };
            var house = new House
            {
                EstateId = estate.Id,
                OutsideAreaSize = 3000,

            };
            var command = new CreateHouseCommand
            {
                EstateId = estate.Id,
                OutsideAreaSize = 3000,
            };

            _estateRepository.AddAsync(estate).Returns(Result<Guid>.Success(estate.Id));
            _userRepository.AddAsync(user).Returns(Result<Guid>.Success(user.Id));
            _mapper.Map<House>(command).Returns(house);
            _houseRepository.AddAsync(house).Returns(Result<Guid>.Success(house.EstateId));

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Data.Should().Be(house.EstateId);
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
                Name = "House Name",
                Description = "House Description",
                Address = "House Address",
                Price = 100000,
                Size = 70,
                Type = "House",
                Status = "Active",
                ListingData = DateTime.Now,
            };


            var house = new House
            {
                EstateId = estate.Id,
                OutsideAreaSize = 3000,

            };
            var command = new CreateHouseCommand
            {
                EstateId = estate.Id,
                OutsideAreaSize = 3000,
            };

            _estateRepository.AddAsync(estate).Returns(Result<Guid>.Success(estate.Id));
            _userRepository.AddAsync(user).Returns(Result<Guid>.Success(user.Id));
            _mapper.Map<House>(command).Returns(house);
            _houseRepository.AddAsync(house).Returns(Result<Guid>.Failure("Error"));

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Data.Should().Be(Guid.Empty);
            result.ErrorMessage.Should().Be("Error");
        }
    }
}
