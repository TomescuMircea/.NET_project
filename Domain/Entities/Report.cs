

namespace Domain.Entities
{
    public class Report
    {
        public Guid Id { get; set; }
        public Guid BuyerId { get; set; }

        public Guid SellerId { get; set; }
        public string Description { get; set; }
        
    }
}
