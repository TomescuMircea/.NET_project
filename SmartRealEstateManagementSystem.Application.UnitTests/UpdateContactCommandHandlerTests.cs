using Application.Use_Cases.CommandHandlers.ContactCH;
using Application.Use_Cases.Commands.ContactC;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using NSubstitute;


namespace SmartRealEstateManagementSystem.Application.UnitTests
{
    public class UpdateContactCommandHandlerTests
    {
        private readonly IGenericEntityRepository<Contact> repository;
        private readonly IMapper mapper;
        private readonly UpdateContactCommandHandler handler;

        public UpdateContactCommandHandlerTests()
        {
            repository = Substitute.For<IGenericEntityRepository<Contact>>();
            mapper = Substitute.For<IMapper>();
            handler = new UpdateContactCommandHandler(repository, mapper);
        }

        [Fact]
        public async Task Given_ValidCommand_When_HandleIsCalled_Then_ShouldReturnSuccessResult()
        {
            // Arrange
            var command = new UpdateContactCommand
            {
                Id = new Guid("12345678-abcd-ef00-1234-567890abcdef"),
                UserId = new Guid("87654321-dcba-fe00-4321-098765fedcba"),
                Email = "contact@example.com",
                Phone = "123-456-7890"
            };

            var contact = new Contact
            {
                Id = command.Id,
                UserId = command.UserId,
                Email = command.Email,
                Phone = command.Phone
            };

            mapper.Map<Contact>(command).Returns(contact);
            repository.UpdateAsync(contact).Returns(Result<Guid>.Success(contact.Id));

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().BeOfType<Result<Guid>>();
            result.IsSuccess.Should().BeTrue();
            result.Data.Should().Be(contact.Id);
            await repository.Received(1).UpdateAsync(contact);
        }

        [Fact]
        public async Task Given_InvalidCommand_When_HandleIsCalled_Then_ShouldReturnFailureResult()
        {
            // Arrange
            var command = new UpdateContactCommand
            {
                Id = new Guid("12345678-abcd-ef00-1234-567890abcdef"),
                UserId = new Guid("87654321-dcba-fe00-4321-098765fedcba"),
                Email = "contact@example.com",
                Phone = "123-456-7890"
            };

            var contact = new Contact
            {
                Id = command.Id,
                UserId = command.UserId,
                Email = command.Email,
                Phone = command.Phone
            };

            mapper.Map<Contact>(command).Returns(contact);
            repository.UpdateAsync(contact).Returns(Result<Guid>.Failure("Update operation failed."));

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().BeOfType<Result<Guid>>();
            result.IsSuccess.Should().BeFalse();
            result.ErrorMessage.Should().Be("Update operation failed.");
        }
    }
}
