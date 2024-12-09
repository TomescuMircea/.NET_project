﻿using Application.Use_Cases.CommandHandlers.ContactCH;
using Application.Use_Cases.CommandHandlers.HouseCH;
using Application.Use_Cases.Commands.ContactC;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using NSubstitute;
using NSubstitute.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRealEstateManagementSystem.Application.UnitTests
{
    public class CreateContactCommandHandlerTests
    {
        private readonly IGenericEntityRepository<Contact> _contactRepository;
        private readonly IGenericEntityRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly CreateContactCommandHandler _handler;

        public CreateContactCommandHandlerTests()
        {
            _contactRepository = Substitute.For<IGenericEntityRepository<Contact>>();
            _userRepository = Substitute.For<IGenericEntityRepository<User>>();
            _mapper = Substitute.For<IMapper>();
            _handler = new CreateContactCommandHandler(_contactRepository, _mapper);

        }

        [Fact]
        public async Task Given_ValidCommand_When_HandleIsCalled_Then_ShouldReturnSuccessResult()
        {
            //Arrange
            var user = new User
            {
                Id = new Guid("fb0c0cbf-cf67-4cc8-babc-63d8b24862b7"),
                FirstName = "John",
                LastName = "Doe",
                UserName = "johndoe",
                Email = "john@gmail.com",
                Password = "12345678"
            };
            var contact = new Contact
            {
                Id = new Guid("fb0c0cbf-cf67-4cc8-babc-63d8b24862b7"),
                UserId = user.Id,
                Phone = "123456789",
                Email = "jhondoe@gmail.com"

            };
            var command = new CreateContactCommand
            {
                UserId = user.Id,
                Phone = "123456789",
                Email = "jhondoe@gmail.com"

            };



            _mapper.Map<Contact>(command).Returns(contact);
            _userRepository.AddAsync(user).Returns(Result<Guid>.Success(user.Id));
            _contactRepository.AddAsync(contact).Returns(Result<Guid>.Success(contact.Id));

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Data.Should().Be(contact.Id);
            result.ErrorMessage.Should().BeNull();

        }

        [Fact]
        public async Task Given_InvalidCommand_When_HandleIsCalled_Then_ShouldReturnFailureResult()
        {
            //Arrange
            var user = new User
            {
                Id = new Guid("fb0c0cbf-cf67-4cc8-babc-63d8b24862b7"),
                FirstName = "John",
                LastName = "Doe",
                UserName = "johndoe",
                Email = "john@gmail.com",
                Password = "12345678"
            };
            var contact = new Contact
            {
                Id = new Guid("fb0c0cbf-cf67-4cc8-babc-63d8b24862b7"),
                UserId = user.Id,
                Phone = "123456789",
                Email = "jhondoe@gmail.com"

            };
            var command = new CreateContactCommand
            {
                UserId = user.Id,
                Phone = "123456789",
                Email = "jhondoe@gmail.com"

            };

            _mapper.Map<Contact>(command).Returns(contact);
            _userRepository.AddAsync(user).Returns(Result<Guid>.Failure("Error"));
            _contactRepository.AddAsync(contact).Returns(Result<Guid>.Failure("Error"));

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Data.Should().Be(Guid.Empty);
            result.ErrorMessage.Should().NotBeNullOrEmpty();

        }
    }
}
