using Application.Use_Cases.Commands.ContactC;
using Domain.Entities;
using FluentAssertions;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;
using System.Net.Http.Json;

namespace SmartRealEstateManagementSystem.IntegrationTests
{
    public class ContactControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>, IDisposable
    {
        private readonly WebApplicationFactory<Program> factory;
        private readonly ApplicationDbContext dbContext;

        private string BaseUrl = "/api/contacts";

        public ContactControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            // Configure factory to use InMemory database
            this.factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var descriptor = services.SingleOrDefault(
                        d => d.ServiceType ==
                            typeof(DbContextOptions<ApplicationDbContext>));

                    if (descriptor != null)
                    {
                        services.Remove(descriptor);
                    }
                    descriptor = services.SingleOrDefault(
                        d => d.ServiceType ==
                            typeof(IDbContextOptionsConfiguration<ApplicationDbContext>));

                    if (descriptor != null)
                    {
                        services.Remove(descriptor);
                    }

                    var dbConnectionDescriptor = services.SingleOrDefault(
                        d => d.ServiceType ==
                            typeof(DbConnection));

                    if (dbConnectionDescriptor != null)
                    {
                        services.Remove(dbConnectionDescriptor);
                    }

                    services.AddDbContext<ApplicationDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("InMemoryDbForTesting");
                    });
                });
            });

            // Create service scope to access DbContext
            var scope = this.factory.Services.CreateScope();
            dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.EnsureCreated();
        }

        [Fact]
        public async Task GivenContacts_WhenGetAllIsCalled_ThenReturnsTheRightContentType()
        {
            // arrange
            var client = factory.CreateClient();

            // act
            var response = await client.GetAsync(BaseUrl);

            // assert
            response.EnsureSuccessStatusCode();
            response.Content.Headers.ContentType?.ToString().Should().Be("application/json; charset=utf-8");
        }

        [Fact]
        public async Task GivenExistingContacts_WhenGetAllIsCalled_ThenReturnsTheRightContacts()
        {
            // arrange
            var client = factory.CreateClient();
            CreateSUT();

            // act
            var response = await client.GetAsync(BaseUrl);

            // assert
            response.EnsureSuccessStatusCode();
            var contacts = await response.Content.ReadAsStringAsync();
            contacts.Should().Contain("123456789");
        }

        [Fact]
        public async Task GivenValidEstate_WhenCreatedIsCalled_Then_ShouldAddToDatabaseTheEstate()
        {
            // Arrange
            var client = factory.CreateClient();

            var user = new User
            {
                Id = new Guid("fb0c0cbf-cf67-4cc8-babc-63d8b24862b7"),
                FirstName = "John",
                LastName = "Doe",
                UserName = "johndoe",
                Email = "john@gmail.com",
                Password = "12345678"
            };

            var command = new CreateContactCommand
            {
                UserId = user.Id,
                Phone = "123456789",
                Email = "jhondoe@gmail.com"
            };

            // Act
            await client.PostAsJsonAsync(BaseUrl, command);

            // Assert
            var contact = await dbContext.Contacts.FirstOrDefaultAsync(b => b.Phone == "123456789");
            contact.Should().NotBeNull();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }

        private void CreateSUT()
        {
            var contact = new Contact
            {
                Id = new Guid("fb0c0cbf-cf67-4cc8-babc-63d8b24862b7"),
                UserId = new Guid("fb0c0cbf-cf67-4cc8-babc-63d8b24862b7"),
                Phone = "123456789",
                Email = "jhondoe@gmail.com"
            };
            dbContext.Contacts.Add(contact);
            dbContext.SaveChanges();
        }
    }
}
