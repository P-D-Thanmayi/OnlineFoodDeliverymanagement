using Domain.Data;
using Domain.Models;

using FoodDeliveryProject.DTO;
using Infrastructure.Interfaces;


namespace FoodDeliveryProject.Repositories
{
    public class RestaurantImplementation : IRestaurant
    {
        
        private readonly AppDbContext appDbContext;

        public RestaurantImplementation(AppDbContext appDbContext)
        {
           
            this.appDbContext = appDbContext;
        }
        public List<Restaurant> GetRestaurants()
        {
            return appDbContext.Restaurants.ToList();
        }
        public RestaurantDto AddRestaurant(RestaurantCreateDto restaurantCreateDto)
        {
            var user = appDbContext.Users.Find(restaurantCreateDto.UserId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var restaurant = new Restaurant
            {
                Status=restaurantCreateDto.Status,
                User=user,
            };
            appDbContext.Restaurants.Add(restaurant);
            appDbContext.SaveChanges();

            return new RestaurantDto
            {
                RestaurantId = restaurant.RestaurantId,
                Status = restaurant.Status,
                OwnerName = user.Name
            };
        }

    }
}
