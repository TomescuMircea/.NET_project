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

                    if (descriptor != null)
                    {
                        services.Remove(descriptor);
                    }

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
        public async Task GivenUsers_WhenGetAllIsCalled_ThenReturnsTheRightContentType()
        {
            // Arrange
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync(BaseUrl);

            // Assert
            response.EnsureSuccessStatusCode();
            response.Content.Headers.ContentType?.ToString().Should().Be("application/json; charset=utf-8");
        }

        [Fact]
        public async Task GivenExistingUsers_WhenGetAllIsCalled_ThenReturnsTheRightUsers()
        {
            // Arrange
            var client = factory.CreateClient();
            CreateSUT();

            // Act
            var response = await client.GetAsync(BaseUrl);

            // Assert
            response.EnsureSuccessStatusCode();
            var users = await response.Content.ReadAsStringAsync();
            users.Should().Contain("John");
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this); 
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
