using MediatR;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestauants;

public class GetAllRestaurantsQuery : IRequest<IEnumerable<RestaurantDto>>
{
}
