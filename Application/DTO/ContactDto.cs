﻿

namespace Application.DTO
{
    public class ContactDto
    {

        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
    }
}