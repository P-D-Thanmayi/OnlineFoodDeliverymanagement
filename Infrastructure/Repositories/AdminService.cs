using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Domain.Data;

namespace Infrastructure.Repositories
{
    public class AdminService
    {
        private readonly AppDbContext _context;
        public AdminService(AppDbContext context)
        {
            _context = context;
        }
        //filter based on role like restaurant,customer,deliveryagent
        public IEnumerable<User> GetUserByRole(String role)
        {
            return _context.Users.Where(u => u.Role == role).ToList();
        }

        //get Restaurant by role
        public IEnumerable<User> GetRestaurantByRole()
        {
            return _context.Users.Where(u => u.Role == "restaurant").ToList();
        }
        //get DeliveryAgent by role
        public IEnumerable<User> GetDeliveryAgentByRole()
        {
            return _context.Users.Where(u => u.Role == "deliveryagent").ToList();
        }
        //get Customer by role
        public IEnumerable<User> GetCustomerByRole()
        {
            return _context.Users.Where(u => u.Role == "customer").ToList();
        }

        //total noof orders

        public IEnumerable<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
        }
    }
}
