

namespace Application.DTO
{
    public class ReportDto
    {

        public Guid Id { get; set; }
        public Guid BuyerId { get; set; }
        public Guid SellerId { get; set; }
        public string Description { get; set; }
    }
}
