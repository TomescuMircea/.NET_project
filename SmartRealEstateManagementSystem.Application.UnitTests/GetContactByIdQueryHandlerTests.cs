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
    public class GetContactByIdQueryHandlerTests
    {
        private readonly IGenericEntityRepository<Contact> _contactRepository;
        private readonly IMapper _mapper;
        private readonly GetContactByIdQueryHandler _handler;

        public GetContactByIdQueryHandlerTests()
        {
            _contactRepository = Substitute.For<IGenericEntityRepository<Contact>>();
            _mapper = Substitute.For<IMapper>();
            _handler = new GetContactByIdQueryHandler(_contactRepository, _mapper);
        }

        [Fact]
        public void Given_GetContactByIdQueryHandler_When_HandleIsCalled_Then_TheContactShouldBeReturned()
        {
            // Arrange
            var contact = new Contact
            {
                Id = new Guid("a3c7b2a9-715d-4b99-8e1d-43ed32a6a8b1"),
                UserId = new Guid("d2aca8c8-ea05-4303-ad6f-83b41d71f97c"),
                Email = "example@example.com",
                Phone = "123-456-7890"
            };
            _contactRepository.GetByIdAsync(contact.Id).Returns(contact);
            var query = new GetContactByIdQuery { Id = contact.Id };
            var contactDto = new ContactDto
            {
                Id = contact.Id,
                UserId = contact.UserId,
                Email = contact.Email,
                Phone = contact.Phone
            };
            _mapper.Map<ContactDto>(contact).Returns(contactDto);

            // Act
            var result = _handler.Handle(query, CancellationToken.None).Result;

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(contact.Id);
            result.UserId.Should().Be(contact.UserId);
            result.Email.Should().Be(contact.Email);
            result.Phone.Should().Be(contact.Phone);
        }

        [Fact]
        public void Given_GetContactByIdQueryHandler_When_HandleIsCalledWithInexistentId_Then_ShouldReturnNull()
        {
            // Arrange
            var query = new GetContactByIdQuery { Id = new Guid("a3c7b2a9-715d-4b99-8e1d-43ed32a6a8b1") };
            _contactRepository.GetByIdAsync(query.Id).Returns((Contact)null);

            // Act
            var result = _handler.Handle(query, CancellationToken.None).Result;

            // Assert
            result.Should().BeNull();
        }
    }
}
