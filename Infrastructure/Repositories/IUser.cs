using Domain.DTO;
using FoodDeliveryProject.DTO;

namespace FoodDeliveryProject.Repositories
{
    public interface IUser
    {
        UserDto CreateUser(CreateUserDto user);
        List<UserDto> getUsers();

        List<UserDto> getUsersByRole(string role);
    }
}
