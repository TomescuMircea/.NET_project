using Domain.Common;
using MediatR;


namespace Application.Use_Cases.Commands.ContactC
{
    public class UpdateContactCommand : CreateContactCommand, IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }
    }
}
