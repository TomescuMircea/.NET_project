using Application.Use_Cases.CommandHandlers.BusinessSpaceCH;
using Application.Use_Cases.Commands.BusinessSpaceC;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using NSubstitute;

namespace SmartRealEstateManagementSystem.Application.UnitTests
{
    public class CreateBusinessSpaceCommandHandlerTests
    {
        private readonly IGenericEntityRepository<BusinessSpace> _businessSpaceRepository;
        private readonly IMapper _mapper;
        private readonly CreateBusinessSpaceCommandHandler _handler;

        public CreateBusinessSpaceCommandHandlerTests()
        {
            _businessSpaceRepository = Substitute.For<IGenericEntityRepository<BusinessSpace>>();
            _mapper = Substitute.For<IMapper>();
            _handler = new CreateBusinessSpaceCommandHandler(_businessSpaceRepository, _mapper);
        }

        [Fact]
        public async Task Given_ValidCommand_When_HandleIsCalled_Then_ShouldReturnSuccessResult()
        {
            // Arrange
            var command = new CreateBusinessSpaceCommand
            {
                EstateId = new Guid("fb0c0cbf-cf67-4cc8-babc-63d8b24862b7"),
                FloorNumber = 2
            };

            var businessSpace = new BusinessSpace
            {
                EstateId = new Guid("fb0c0cbf-cf67-4cc8-babc-63d8b24862b7"),
                FloorNumber = command.FloorNumber
            };

            _mapper.Map<BusinessSpace>(command).Returns(businessSpace);
            _businessSpaceRepository.AddAsync(businessSpace).Returns(Result<Guid>.Success(businessSpace.EstateId));

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Data.Should().Be(businessSpace.EstateId);
            result.ErrorMessage.Should().BeNull();
        }

        [Fact]
        public async Task Given_InvalidCommand_When_HandleIsCalled_Then_ShouldReturnFailureResult()
        {
            // Arrange
            var command = new CreateBusinessSpaceCommand
            {
                EstateId = new Guid("fb0c0cbf-cf67-4cc8-babc-63d8b24862b7"),
                FloorNumber = 2
            };

            var businessSpace = new BusinessSpace
            {
                EstateId = new Guid("fb0c0cbf-cf67-4cc8-babc-63d8b24862b7"),
                FloorNumber = command.FloorNumber
            };

            _mapper.Map<BusinessSpace>(command).Returns(businessSpace);
            _businessSpaceRepository.AddAsync(businessSpace).Returns(Result<Guid>.Failure("Error"));

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Data.Should().Be(Guid.Empty);
            result.ErrorMessage.Should().Be("Error");
        }
    }
}
