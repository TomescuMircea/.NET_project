using Application.DTO;
using Application.Use_Cases.Queries.Contact;
using Application.Use_Cases.QueryHandlers.ContactQH;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using NSubstitute;

namespace SmartRealEstateManagementSystem.Application.UnitTests
{
    public class GetContactsQueryHandlerTests
    {
        private readonly IGenericEntityRepository<Contact> _contactRepository;
        private readonly IMapper _mapper;
        private readonly GetContactsQueryHandler _handler;

        public GetContactsQueryHandlerTests()
        {
            _contactRepository = Substitute.For<IGenericEntityRepository<Contact>>();
            _mapper = Substitute.For<IMapper>();
            _handler = new GetContactsQueryHandler(_contactRepository, _mapper);
        }

        [Fact]
        public async Task Given_GetContactsQueryHandler_When_HandleIsCalled_Then_AListOfContactsShouldBeReturned()
        {
            // Arrange
            List<Contact> contacts = GenerateContacts();
            _contactRepository.GetAllAsync().Returns(contacts);
            var query = new GetContactsQuery();
            GenerateContactsDto(contacts);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            Assert.Equal(2, result.Count);
            Assert.Equal(contacts[0].Id, result[0].Id);
            Assert.Equal(contacts[1].Id, result[1].Id);
        }

        private void GenerateContactsDto(List<Contact> contacts)
        {
            _mapper.Map<List<ContactDto>>(contacts).Returns(new List<ContactDto>
            {
                new ContactDto
                {
                    Id = contacts[0].Id,
                    UserId = contacts[0].UserId,
                    Email = contacts[0].Email,
                    Phone = contacts[0].Phone
                },
                new ContactDto
                {
                    Id = contacts[1].Id,
                    UserId = contacts[1].UserId,
                    Email = contacts[1].Email,
                    Phone = contacts[1].Phone
                }
            });
        }

        static private List<Contact> GenerateContacts()
        {
            return new List<Contact>
            {
                new Contact
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    Email = "contact1@example.com",
                    Phone = "123-456-7890"
                },
                new Contact
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    Email = "contact2@example.com",
                    Phone = "987-654-3210"
                }
            };
        }
    }
}
