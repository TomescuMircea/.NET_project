

namespace Application.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public required string Type { get; set; }
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Status { get; set; }

    }
}
