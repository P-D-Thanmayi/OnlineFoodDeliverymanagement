using FoodDeliveryProject.DTO;

namespace Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        UserDto CreateUser(UserDto user);

    }
}
