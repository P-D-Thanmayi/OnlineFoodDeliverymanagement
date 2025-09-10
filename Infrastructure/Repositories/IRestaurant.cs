using Domain.Models;
using FoodDeliveryProject.DTO;


namespace FoodDeliveryProject.Repositories
{
    public interface IRestaurant
    {
        List<Restaurant> GetRestaurants();
        RestaurantDto AddRestaurant(RestaurantCreateDto restaurantCreateDto);
    }
}
