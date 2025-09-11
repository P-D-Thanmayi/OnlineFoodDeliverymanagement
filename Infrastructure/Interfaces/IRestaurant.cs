using Domain.Models;
using FoodDeliveryProject.DTO;


namespace Infrastructure.Interfaces
{
    public interface IRestaurant
    {
        List<Restaurant> GetRestaurants();
        RestaurantDto AddRestaurant(RestaurantCreateDto restaurantCreateDto);
    }
}
