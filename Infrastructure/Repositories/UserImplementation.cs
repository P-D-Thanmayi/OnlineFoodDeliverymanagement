using Domain.Data;
using Domain.Models;
using FoodDeliveryProject.DTO;
using Infrastructure.Interfaces;


namespace FoodDeliveryProject.Repositories
{
    public class UserImplementation : IUserRepository
    {
        private readonly AppDbContext appDbContext;
        public UserImplementation(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public UserDto CreateUser(UserDto userdto)
        {
            var user = new User
            {
                Name = userdto.Name,
                Phoneno = userdto.Phoneno,
                Password = userdto.Password,
                IsValid = userdto.IsValid,
                Role = userdto.Role
            };
            appDbContext.Users.Add(user);
            appDbContext.SaveChanges();

            return new UserDto
            {
                Name = user.Name,
                Phoneno = user.Phoneno,
                Password = user.Password,
                IsValid = user.IsValid,
                Role = user.Role
            };
        }
    }
}
