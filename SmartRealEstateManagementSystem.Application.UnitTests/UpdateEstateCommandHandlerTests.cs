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
        private readonly IGenericEntityRepository<Estate> repository;
        private readonly IMapper mapper;
        private readonly UpdateEstateCommandHandler handler;

        public UpdateEstateCommandHandlerTests()
        {
            repository = Substitute.For<IGenericEntityRepository<Estate>>();
            mapper = Substitute.For<IMapper>();
            handler = new UpdateEstateCommandHandler(repository, mapper);
        }

        [Fact]
        public async Task Given_ValidCommand_When_HandleIsCalled_Then_ShouldReturnSuccessResult()
        {
            // Arrange
            var user = new User
            {
                Id = new Guid("fb0c0cbf-cf67-4cc8-babc-63d8b24862b7"),
                FirstName = "John",
                LastName = "Doe",
                UserName = "johndoe",
                Email = "john@gmail.com",
                Password = "12345678"
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

            mapper.Map<Estate>(command).Returns(estate);

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            await repository.Received(1).UpdateAsync(estate);
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

            mapper.Map<Estate>(command).Returns(estate);
            repository.UpdateAsync(estate).Returns(Result<Guid>.Failure("Update operation failed."));

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().BeOfType<Result<Guid>>();
            result.IsSuccess.Should().BeFalse();
        }

    }
}
