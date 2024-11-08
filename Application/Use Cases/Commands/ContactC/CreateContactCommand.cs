﻿using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Use_Cases.Commands.ContactC
{
    public class CreateContactCommand : IRequest<Result<Guid>>
    {
        public Guid UserId { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
    }
}
