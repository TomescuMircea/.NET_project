using Application.Use_Cases.Commands;
using Domain.Entities;
using FluentAssertions;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SmartRealEstateManagementSystem.IntegrationTests
{
    public class UserControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>, IDisposable
    {
        private readonly WebApplicationFactory<Program> factory;
        private readonly ApplicationDbContext dbContext;

        private string BaseUrl = "api/users";

        public UserControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            this.factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var descriptor = services.SingleOrDefault(
                        d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));

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
        public void GivenUsers_WhenGetAllIsCalled_ThenReturnsTheRightContentType()
        {
            // Arrange
            var client = factory.CreateClient();

            // Act
            var response = client.GetAsync(BaseUrl);

            // Assert
            response.Result.EnsureSuccessStatusCode();
            response.Result.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");
        }

        [Fact]
        public void GivenExistingUsers_WhenGetAllIsCalled_ThenReturnsTheRightUsers()
        {
            // Arrange
            var client = factory.CreateClient();
            CreateSUT();

            // Act
            var response = client.GetAsync(BaseUrl);

            // Assert
            response.Result.EnsureSuccessStatusCode();
            var users = response.Result.Content.ReadAsStringAsync().Result;
            users.Should().Contain("John");
        }


        public void Dispose()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
        private void CreateSUT()
        {
            var user = new User
            {
                FirstName = "John",
                LastName = "Doe",
                Status = "Active",
                Type = "Normal"
            };
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }
    }
}
