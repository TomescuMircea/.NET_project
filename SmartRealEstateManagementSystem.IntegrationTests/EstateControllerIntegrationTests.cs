using Application.Use_Cases.Commands.EstateC;
using Domain.Entities;
using FluentAssertions;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace SmartRealEstateManagementSystem.IntegrationTests
{
    public class EstateControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>, IDisposable
    {
        private readonly WebApplicationFactory<Program> factory;
        private readonly ApplicationDbContext dbContext;

        private string BaseUrl = "/api/estates";
        public EstateControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            this.factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var descriptor = services.SingleOrDefault(
                        d => d.ServiceType ==
                            typeof(DbContextOptions<ApplicationDbContext>));

                    services.Remove(descriptor);

                    services.AddDbContext<ApplicationDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("InMemoryDbForTesting");
                    });
                });
            });

            var scope = this.factory.Services.CreateScope();
            dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.EnsureCreated();
        }

        [Fact]
        public void GivenEstates_WhenGetAllIsCalled_ThenReturnsTheRightContentType()
        {
            // arrange
            var client = factory.CreateClient();

            // act
            var response = client.GetAsync(BaseUrl);

            // assert
            response.Result.EnsureSuccessStatusCode();
            response.Result.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");
        }

        [Fact]
        public void GivenExistingEtates_WhenGetAllIsCalled_ThenReturnsTheRightEstates()
        {
            // arrange
            var client = factory.CreateClient();
            CreateSUT();

            // act
            var response = client.GetAsync(BaseUrl);

            // assert
            response.Result.EnsureSuccessStatusCode();
            var estates = response.Result.Content.ReadAsStringAsync().Result;
            estates.Should().Contain("Estate 1");
        }

        [Fact]
        public async void GivenValidEstate_WhenCreatedIsCalled_Then_ShouldAddToDatabaseTheEstate()
        {
            // Arrange
            var client = factory.CreateClient();

            var user = new User
            {
                Id = new Guid("fb0c0cbf-cf67-4cc8-babc-63d8b24862b7"),
                Type = "f",
                FirstName = "John",
                LastName = "Doe",
                Status = "Active"
            };

            var command = new CreateEstateCommand
            {
                UserId = user.Id,
                Name = "Estate Name",
                Description = "Estate Description",
                Address = "Estate Address",
                Price = 100000,
                Type = "1",
                Status = "Active"
            };

            // Act
            await client.PostAsJsonAsync(BaseUrl, command);

            // Assert
            var estate = dbContext.Estates.FirstOrDefaultAsync(b => b.Name == "Estate Name");
            estate.Should().NotBeNull();
        }
        public void Dispose()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }


        private void CreateSUT()
        {
            var estate = new Estate
            {
                Id = new Guid("4fd3f7f1-fd01-4731-8c3d-e865306e0d91"),
                UserId = new Guid("fb0c0cbf-cf67-4cc8-babc-63d8b24862b7"),
                Name = "Estate 1",
                Description = "Description 1",
                Address = "Adress 1",
                Price = 1000,
                Size = 70,
                Type = "House",
                Status = "Active",
                ListingData = DateTime.Now,
            };
            dbContext.Estates.Add(estate);
            dbContext.SaveChanges();
        }
    }
}