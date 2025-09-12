using Domain.Models;
using Domain.DTO;


namespace Infrastructure.Interfaces
{
    public interface IRestaurant
    {
        List<Restaurant> GetRestaurants();
        RestaurantDto AddRestaurant(RestaurantCreateDto restaurantCreateDto);
    }
}
