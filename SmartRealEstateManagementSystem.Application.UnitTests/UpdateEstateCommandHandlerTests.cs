using Application.Use_Cases.CommandHandlers.EstateCH;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using NSubstitute;

namespace Application.Use_Cases.Commands.EstateC
{
    public class UpdateEstateCommandHandlerTests
    {
        private readonly IGenericEntityRepository<Estate> _estateRepository;
        private readonly IGenericEntityRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly UpdateEstateCommandHandler _handler;

        public UpdateEstateCommandHandlerTests()
        {
            _estateRepository = Substitute.For<IGenericEntityRepository<Estate>>();
            _userRepository = Substitute.For<IGenericEntityRepository<User>>();
            _mapper = Substitute.For<IMapper>();
            _handler = new UpdateEstateCommandHandler(_estateRepository, _mapper);
        }

        [Fact]
        public async Task Given_ValidCommand_When_HandleIsCalled_Then_ShouldReturnSuccessResult()
        {
            // Arrange
            var user = new User
            {
                Id = new Guid("fb0c0cbf-cf67-4cc8-babc-63d8b24862b7"),
                Type = "Admin",
                FirstName = "John",
                LastName = "Doe",
                Status = "Active"
            };

            var command = new UpdateEstateCommand
            {
                Id = new Guid("4fd3f7f1-fd01-4731-8c3d-e865306e0d91"),
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
                Id = command.Id,
                UserId = command.UserId,
                Name = command.Name,
                Description = command.Description,
                Address = command.Address,
                Price = command.Price,
                Size = 70,
                Type = "3",
                Status = "Active",
                ListingData = DateTime.Now,
                User = user
            };

            _mapper.Map<Estate>(command).Returns(estate);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            await _estateRepository.Received(1).UpdateAsync(estate);
        }

        [Fact]
        public async Task Given_ValidCommand_When_HandleIsCalled_Then_ShouldReturnFailureResult()
        {
            // Arrange
            var command = new UpdateEstateCommand
            {
                Id = new Guid("4fd3f7f1-fd01-4731-8c3d-e865306e0d91"),
                UserId = new Guid("fb0c0cbf-cf67-4cc8-babc-63d8b24862b7"),
                Name = "Estate Name",
                Description = "Estate Description",
                Address = "Estate Address",
                Price = 100000,
                Type = "1",
                Status = "Active"
            };

            var estate = new Estate
            {
                Id = command.Id,
                UserId = command.UserId,
                Name = command.Name,
                Description = command.Description,
                Address = command.Address,
                Price = command.Price,
                Size = 70,
                Type = "House",
                Status = "Active",
                ListingData = DateTime.Now
            };

            _mapper.Map<Estate>(command).Returns(estate);
            _estateRepository.UpdateAsync(estate).Returns(Result<Guid>.Failure("Update operation failed."));

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().BeOfType<Result<Guid>>();
            result.IsSuccess.Should().BeFalse();
        }

    }
}
