

namespace Application.DTO
{
    public class ReviewPropertyDto
    {
        public Guid Id { get; set; }
        public Guid EstateId { get; set; }
        public Guid BuyerId { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }


    }
}
