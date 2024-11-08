namespace Domain.Entities
{
    public class Estate
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public required string Name { get; set; }
        public required string Description { get; set; }
         
        public decimal Price { get; set; }
        public required string Address { get; set; }
        public decimal Size { get; set; }

        public required string Type { get; set; }
        public required string Status { get; set; }
        public DateTime ListingData { get; set; }

        public User? User { get; set; }
    }
}