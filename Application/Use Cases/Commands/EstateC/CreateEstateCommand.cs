using Domain.Common;
using MediatR;

namespace Application.Use_Cases.Commands.EstateC
{
    public class CreateEstateCommand: IRequest<Result<Guid>>
    {
    }
}