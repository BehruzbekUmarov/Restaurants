using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger,
    IMapper mapper,
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<UpdateRestaurantCommand, int>
{
    public async Task<int> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Updating restaurant by id : {request.Id}");
        var existRestaurant = await restaurantsRepository.GetByIdAsync(request.Id);
        if(existRestaurant is null) return 0;

        var restaurant = mapper.Map<Restaurant>(request); 
        int id = await restaurantsRepository.Update(restaurant);

        return id;
    }
}
