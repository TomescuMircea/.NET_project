


namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Status { get; set; }

        
        public ICollection<Estate> Estates { get; set; }
    }
}
