using MediatR;

namespace Application.Use_Cases.Commands.EstateC
{
    public class DeleteEstateCommand(Guid id) : IRequest
    {
    }
}