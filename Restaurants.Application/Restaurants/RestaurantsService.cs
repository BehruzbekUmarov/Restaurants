using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;

internal class RestaurantsService(IRestaurantsRepository restaurantsRepository,
    ILogger<RestaurantsService> logger,
    IMapper mapper) : IRestaurantsService
{
    public async Task<int> Create(CreateRestaurantDto dto)
    {
        logger.LogInformation("Creating a new Restaurant");

        var restaurant = mapper.Map<Restaurant>(dto);
        int id = await restaurantsRepository.Create(restaurant);

        return id;
    }

    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        logger.LogInformation("Getall restaurants");
        var restaurants = await restaurantsRepository.GetAllAsync();

        var restaurantDtos = mapper.Map < IEnumerable<RestaurantDto?>>(restaurants);
        return restaurantDtos!;
    }

    public async Task<RestaurantDto?> GetRestaurantById(int id)
    {
        logger.LogInformation("Get restaurant by Id");
        var restaurant = await restaurantsRepository.GetByIdAsync(id);
        var restaurantDto = mapper.Map<RestaurantDto?>(restaurant);

        return restaurantDto;
    }
}
