using MediatR;


namespace Application.Use_Cases.Commands.ContactC
{
    public class UpdateContactCommand : CreateContactCommand, IRequest
    {
        public Guid Id { get; set; }
    }
}
