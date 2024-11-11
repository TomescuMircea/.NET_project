using Application.Use_Cases.CommandHandlers.ContactCH;
using Application.Use_Cases.Commands.ContactC;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRealEstateManagementSystem.Application.UnitTests
{

    public class DeleteContactCommandHandlerTests
    {
        private readonly IGenericEntityRepository<Contact> repository;
        private readonly DeleteContactCommandHandler handler;

        public DeleteContactCommandHandlerTests()
        {
            repository = Substitute.For<IGenericEntityRepository<Contact>>();
            handler = new DeleteContactCommandHandler(repository);
        }

        [Fact]
        public async Task Given_ValidCommand_When_HandleIsCalled_Then_ShouldReturnSuccessResult()
        {
            //Arrange

            var command = new DeleteContactCommand(new Guid("fb0c0cbf-cf67-4cc8-babc-63d8b24862b7"));
            var contact = new Contact
            {
                Id = command.Id,
                Phone = "123456789",
                Email = "jhondoe@gmail.com"

            };

            repository.DeleteAsync(contact.Id).Returns(Result<Guid>.Success(contact.Id));

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            result.IsSuccess.Should().BeTrue();
            result.Data.Should().Be(contact.Id);
            result.ErrorMessage.Should().BeNull();

        }

        [Fact]
        public async Task Given_InvalidCommand_When_HandleIsCalled_Then_ShouldReturnFailureResult()
        {
            //Arrange
            var command = new DeleteContactCommand(new Guid("fb0c0cbf-cf67-4cc8-babc-63d8b24862b7"));

            repository.DeleteAsync(command.Id).Returns(Result<Guid>.Failure("Contact not found"));

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            result.IsSuccess.Should().BeFalse();
            result.Data.Should().Be(Guid.Empty);
            result.ErrorMessage.Should().Be("Contact not found");
        }
    }
}
