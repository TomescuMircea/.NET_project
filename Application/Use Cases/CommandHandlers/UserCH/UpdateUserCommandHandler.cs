using Application.Use_Cases.Commands.UserC;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Use_Cases.CommandHandlers.UserCH
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IGenericEntityRepository<User> repository;
        private readonly IMapper mapper;

        public UpdateUserCommandHandler(IGenericEntityRepository<User> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<User>(request);
            return repository.UpdateAsync(user);
        }
    }
}
