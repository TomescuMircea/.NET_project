﻿

namespace Application.DTO
{
    public class PayDto
    {
        public Guid Id { get; set; }
        public Guid SellerGuid { get; set; }
        public Guid BuyerGuid { get; set; }
        public Guid EstateGuid { get; set; }
    }
}
