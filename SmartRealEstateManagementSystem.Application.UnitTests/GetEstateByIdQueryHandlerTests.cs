using Application.DTO;
using Application.Use_Cases.Queries.EstateQ;
using Application.Use_Cases.QueryHandlers.EstateQH;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using NSubstitute;

namespace SmartRealEstateManagementSystem.Application.UnitTests
{
    public class GetEstateByIdQueryHandlerTests
    {
        private readonly IGenericEntityRepository<Estate> _estateRepository;
        private readonly IMapper _mapper;
        private readonly GetEstateByIdQueryHandler handler;

        public GetEstateByIdQueryHandlerTests()
        {
            _estateRepository = Substitute.For<IGenericEntityRepository<Estate>>();
            _mapper = Substitute.For<IMapper>();
            handler = new GetEstateByIdQueryHandler(_estateRepository, _mapper);
        }

        [Fact]
        public async Task Given_GetEstateByIdQueryHandler_When_HandleIsCalled_Then_TheEstateShouldBeReturned()
        { 
            // Arrange
            var estate = new Estate
            {
                Id = new Guid("d2aca8c8-ea05-4303-ad6f-83b41d71f97c"),
                Name = "Sample Estate",
                Description = "Sample Description",
                Address = "Sample Address",
                Type = "Sample Type",
                Status = "Available"
            };
            _estateRepository.GetByIdAsync(estate.Id).Returns(estate);
            var query = new GetEstateByIdQuery { Id = estate.Id };
            var estateDto = new EstateDto
            {
                Id = estate.Id,
                Name = estate.Name,
                Description = estate.Description,
                Address = estate.Address,
                Type = estate.Type,
                Status = estate.Status
            };
            _mapper.Map<EstateDto>(estate).Returns(estateDto);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(estate.Id);
            result.Name.Should().Be(estate.Name);
            result.Description.Should().Be(estate.Description);
            result.Address.Should().Be(estate.Address);
            result.Type.Should().Be(estate.Type);
            result.Status.Should().Be(estate.Status);
        }

        [Fact]
        public async Task Given_GetEstateByIdQueryHandler_When_HandleIsCalledWithInexistentId_Then_ShouldReturnNull()
        {
            // Arrange
            var query = new GetEstateByIdQuery { Id = new Guid("d2aca8c8-ea05-4303-ad6f-83b41d71f97c") };
            _estateRepository.GetByIdAsync(query.Id).Returns((Estate?)null);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().BeNull();
        }
    }
}
