﻿

namespace Application.DTO
{
    internal class ReviewUserDto
    {
        public Guid Id { get; set; }
        public Guid BuyerId { get; set; }
        public Guid SellerId { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }

    }
}