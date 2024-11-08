using MediatR;

namespace Application.Use_Cases.Commands.EstateC
{
    public class UpdateEstateCommand : CreateEstateCommand, IRequest
    {
        public Guid Id { get; set; }
    }
}
