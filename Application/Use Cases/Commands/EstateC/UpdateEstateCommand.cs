using Domain.Common;
using MediatR;

namespace Application.Use_Cases.Commands.EstateC
{
    public class UpdateEstateCommand : CreateEstateCommand, IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }
    }
}
