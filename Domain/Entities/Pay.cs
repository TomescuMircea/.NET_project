

namespace Domain.Entities
{
    public class Pay
    {
        public Guid Id { get; set; }
        public Guid SellerGuid { get; set; }
        public Guid BuyerGuid { get; set; }
        public Guid EstateGuid { get; set; }

    }
}
