


namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public required string Type { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Status { get; set; }

        
        public ICollection<Estate>? Estates { get; set; }
    }
}
