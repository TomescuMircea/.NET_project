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
        private readonly IGenericEntityRepository<Contact> _contactRepository;
        private readonly IMapper _mapper;
        private readonly DeleteContactCommandHandler _handler;

        public DeleteContactCommandHandlerTests()
        {
            _contactRepository = Substitute.For<IGenericEntityRepository<Contact>>();
            _mapper = Substitute.For<IMapper>();
            _handler = new DeleteContactCommandHandler(_contactRepository, _mapper);
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

            _contactRepository.DeleteAsync(contact.Id).Returns(Result<Guid>.Success(contact.Id));

            //Act
            var result = await _handler.Handle(command, System.Threading.CancellationToken.None);

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

            _contactRepository.DeleteAsync(command.Id).Returns(Result<Guid>.Failure("Contact not found"));

            //Act
            var result = await _handler.Handle(command, System.Threading.CancellationToken.None);

            //Assert
            result.IsSuccess.Should().BeFalse();
            result.Data.Should().Be(Guid.Empty);
            result.ErrorMessage.Should().Be("Contact not found");
        }
    }
}
