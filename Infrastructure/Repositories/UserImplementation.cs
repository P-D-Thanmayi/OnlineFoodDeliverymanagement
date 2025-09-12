using Domain.Data;
using Domain.DTO;
using Domain.Models;
using FoodDeliveryProject.DTO;


namespace FoodDeliveryProject.Repositories
{
    public class UserImplementation : IUser
    {
        private readonly AppDbContext appDbContext;
        public UserImplementation(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        
        public UserDto CreateUser(CreateUserDto userdto)
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
                IsValid = user.IsValid,
                Role = user.Role
            };
        }
        public List<UserDto> getUsers()
        {
            return appDbContext.Users.Select(u=>new UserDto
            { 
            
                Id=u.Id,
                Name = u.Name,
                Phoneno=u.Phoneno,
                Role = u.Role,
                IsValid = u.IsValid
            })
            .ToList();
        }
        public List<UserDto> getUsersByRole(string role)
        {
            return appDbContext.Users.Where(r => r.Role == role)
                .Select(r => new UserDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    Phoneno = r.Phoneno,
                    Role = r.Role,
                    IsValid = r.IsValid
                }).ToList();
        }
    }
}
