﻿using Application.Use_Cases.Commands.ContactC;
using Domain.Entities;
using FluentAssertions;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
        public void GivenContacts_WhenGetAllIsCalled_ThenReturnsTheRightContentType()
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
        public void GivenExistingContacts_WhenGetAllIsCalled_ThenReturnsTheRightContacts()
        {
            // arrange
            var client = factory.CreateClient();
            CreateSUT();

            // act
            var response = client.GetAsync(BaseUrl);

            // assert
            response.Result.EnsureSuccessStatusCode();
            var contacts = response.Result.Content.ReadAsStringAsync().Result;
            contacts.Should().Contain("123456789");
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

            var command = new CreateContactCommand
            {
                UserId = user.Id,
                Phone = "123456789",
                Email = "jhondoe@gmail.com"
            };

            // Act
            await client.PostAsJsonAsync(BaseUrl, command);

            // Assert
            var contact = dbContext.Contacts.FirstOrDefaultAsync(b => b.Phone == "123456789");
            contact.Should().NotBeNull();
        }
        public void Dispose()
        {
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