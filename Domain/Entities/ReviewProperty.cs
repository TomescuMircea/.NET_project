

namespace Domain.Entities
{
    public class ReviewProperty
    {
        public Guid Id { get; set; }
        public Guid EstateId { get; set; }
        public Guid BuyerId { get; set; }
        public required string Description { get; set; }
        public int Rating { get; set; }
    }
}
