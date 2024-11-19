using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;
namespace Restaurants.Infrastructure.Seeders;

internal class RestaurantSeeders(RestaurantsDbContext dbContext) : IRestaurantSeeders
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Restaurants.Any())
            {
                var restaurants = GetRestaurants();
                dbContext.Restaurants.AddRange(restaurants);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Restaurant> GetRestaurants()
    {
        List<Restaurant> restaurants = [
            new()
            {
                Name = "KFC",
                Category = "Fast food",
                Description = "scacasdcsdvcasdvdvgvbhnnkhfgvjbknjgjxfcgvb ,",
                ContactEmail = "contact@kfc.com",
                HasDelivery = true,
                Dishes = [
                    new(){
                        Name = "Bu juja guchadir",
                        Description =  "Uzb da ishlab chiqarilgan",
                        Price = 10.30M,
                        KiloCalories = 300
                    },
                    new (){
                        Name = "qALAMPIRLI BODRING",
                        Description =  "Uzb da ishlab chiqarilgan",
                        Price = 12.20M,
                        KiloCalories = 340
                    }
                    ],
                Address = new (){
                    City = "London",
                    Street = "Yuksalish 1724",
                    PostalCode = "HGS 876"
                }
            },
            new()
            {
                Name = "MacDonals",
                Category = "Fast Food",
                Description = "sxacsaccadsvdfbsdfgbsdfbsdfbdfhD",
                ContactEmail = "contact@mcdonal.com",
                HasDelivery = true,
                Address = new Address(){
                    City = "Qarshi",
                    Street = "Yuksalish",
                    PostalCode = "FGH 847"
                }
            }
            ];

        return restaurants;
    }
}
