using Domain.Common;
using MediatR;

namespace Application.Use_Cases.Commands.ContactC
{
    public record DeleteContactCommand(Guid Id) : IRequest<Result<Guid>>;
   
}
