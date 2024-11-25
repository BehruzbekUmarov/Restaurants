using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger,
    IMapper mapper,
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<UpdateRestaurantCommand, bool>
{
    public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating restaurant by id : {@RestaurantId} with {UpdateRestaurant}", request.Id, request);
        var existRestaurant = await restaurantsRepository.GetByIdAsync(request.Id);
        if(existRestaurant is null) return false;

         mapper.Map(request, existRestaurant);


        await restaurantsRepository.SaveChanges();
        return true;
    }
}
