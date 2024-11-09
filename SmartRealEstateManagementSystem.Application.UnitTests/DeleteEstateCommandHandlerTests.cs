﻿using Application.Use_Cases.CommandHandlers.EstateCH;
using Application.Use_Cases.Commands.EstateC;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using NSubstitute;

namespace SmartRealEstateManagementSystem.Application.UnitTests
{
    public class DeleteEstateCommandHandlerTests
    {
        private readonly IGenericEntityRepository<Estate> _estateRepository;
        private readonly IMapper _mapper;
        private readonly DeleteEstateCommandHandler _handler;

        public DeleteEstateCommandHandlerTests()
        {
            _estateRepository = Substitute.For<IGenericEntityRepository<Estate>>();
            _mapper = Substitute.For<IMapper>();
            _handler = new DeleteEstateCommandHandler(_estateRepository, _mapper);
        }

        [Fact]
        public async Task Given_ValidCommand_When_HandleIsCalled_Then_ShouldReturnSuccessResult()
        {
            // Arrange
            var command = new DeleteEstateCommand(new Guid("d2aca8c8-ea05-4303-ad6f-83b41d71f97c"));

            var estate = new Estate
            {
                Id = command.Id,
                Name = "Sample Estate",
                Description = "Sample Description",
                Address = "Sample Address",
                Type = "Sample Type",
                Status = "Available"
            };

            _estateRepository.DeleteAsync(estate.Id).Returns(Result<Guid>.Success(estate.Id));

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
            var command = new DeleteEstateCommand(new Guid("d2aca8c8-ea05-4303-ad6f-83b41d71f97c"));

            _estateRepository.DeleteAsync(command.Id).Returns(Result<Guid>.Failure("Estate not found"));

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Data.Should().Be(Guid.Empty);
            result.ErrorMessage.Should().Be("Estate not found");
        }

    }
}
