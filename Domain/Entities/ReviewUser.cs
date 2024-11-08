

namespace Domain.Entities
{
    public class ReviewUser
    {
        public Guid Id { get; set; }
        public Guid BuyerId { get; set; }
        public Guid SellerId { get; set; }
        public required string Description { get; set; }
        public int Rating { get; set; }
    }
}
