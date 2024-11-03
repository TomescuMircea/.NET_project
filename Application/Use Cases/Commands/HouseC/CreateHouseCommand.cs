using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Use_Cases.Commands.HouseC
{
    public class CreateHouseCommand : IRequest<Result<Guid>>
    {
        public Guid EstateId { get; set; }
        public decimal OutsideAreaSize { get; set; }
    }
}
