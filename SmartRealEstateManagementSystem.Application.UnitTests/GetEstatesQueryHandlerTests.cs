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
    public class GetEstatesQueryHandlerTests
    {
        private readonly IGenericEntityRepository<Estate> _estateRepository;
        private readonly IMapper _mapper;
        private readonly GetEstatesQueryHandler _handler;

        public GetEstatesQueryHandlerTests()
        {
            _estateRepository = Substitute.For<IGenericEntityRepository<Estate>>();
            _mapper = Substitute.For<IMapper>();
            _handler = new GetEstatesQueryHandler(_estateRepository, _mapper);
        }

        [Fact]
        public void Given_GetEstatesQueryHandler_When_HandleIsCalled_Then_AListOfEstatesShouldBeReturned()
        {
            // Arrange
            List<Estate> estates = GenerateEstates();
            _estateRepository.GetAllAsync().Returns(estates);
            var query = new GetEstatesQuery();
            GenerateEstatesDto(estates);
            // Act
            var result = _handler.Handle(query, CancellationToken.None);
            // Assert
            result.Should().NotBeNull();
            Assert.Equal(2, result.Result.Count);
            Assert.Equal(estates[0].Id, result.Result[0].Id);
        }

        private void GenerateEstatesDto(List<Estate> estates)
        {
            _mapper.Map<List<EstateDto>>(estates).Returns(new List<EstateDto>
            {
                new EstateDto
                {
                    Id = estates[0].Id,
                    UserId = estates[0].UserId,
                    Name = estates[0].Name,
                    Description = estates[0].Description,
                    Price = estates[0].Price,
                    Address = estates[0].Address,
                    Size = estates[0].Size,
                    Type = estates[0].Type,
                    Status = estates[0].Status,
                    ListingData = estates[0].ListingData
                },
                new EstateDto
                {
                    Id = estates[1].Id,
                    UserId = estates[1].UserId,
                    Name = estates[1].Name,
                    Description = estates[1].Description,
                    Price = estates[1].Price,
                    Address = estates[1].Address,
                    Size = estates[1].Size,
                    Type = estates[1].Type,
                    Status = estates[1].Status,
                    ListingData = estates[1].ListingData
                }
            });
        }

        private List<Estate> GenerateEstates()
        {
            return new List<Estate>
            {
                new Estate
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    Name = "Estate 1",
                    Description = "Description 1",
                    Price = 100000,
                    Address = "Address 1",
                    Size = 1000,
                    Type = "Type 1",
                    Status = "Status 1",
                    ListingData = DateTime.Now
                },
                new Estate
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    Name = "Estate 2",
                    Description = "Description 2",
                    Price = 200000,
                    Address = "Address 2",
                    Size = 2000,
                    Type = "Type 2",
                    Status = "Status 2",
                    ListingData = DateTime.Now
                }
            };
        }
    }
}
