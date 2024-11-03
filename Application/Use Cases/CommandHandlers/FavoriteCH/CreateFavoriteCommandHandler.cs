using Application.Use_Cases.Commands.EstateC;
using Application.Use_Cases.Commands.FavoriteC;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Use_Cases.CommandHandlers.FavoriteCH
{
    public class CreateFavoriteCommandHandler : IRequestHandler<CreateFavoriteCommand, Result<Guid>>
    {
        private readonly IFavoriteRepository repository;
        private readonly IMapper mapper;

        public CreateFavoriteCommandHandler(IFavoriteRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Result<Guid>> Handle(CreateFavoriteCommand request, CancellationToken cancellationToken)
        {
            var favorite = mapper.Map<Favorite>(request);
            return await repository.AddAsync(favorite);
        }
    }
}
