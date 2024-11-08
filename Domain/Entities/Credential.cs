

namespace Domain.Entities
{
    public class Credential
    {
        public Guid UserId { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

    }
}
