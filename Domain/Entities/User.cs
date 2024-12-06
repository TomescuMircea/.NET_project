


namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public ICollection<Estate>? Estates { get; set; }
    }
}
