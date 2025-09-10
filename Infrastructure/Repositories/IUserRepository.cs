using FoodDeliveryProject.DTO;

namespace FoodDeliveryProject.Repositories
{
    public interface IUserRepository
    {
        UserDto CreateUser(UserDto user);

    }
}
