

namespace Application.DTO
{
    public class ContactDto
    {

        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public required string Email { get; set; }
        public required string Phone { get; set; }
    }
}
