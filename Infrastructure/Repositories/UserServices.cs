using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace Infrastructure.Repositories
{
    public class UserServices
    {
        private readonly AppDbContext _context;
        public UserServices(AppDbContext context)
        {
            _context = context;
        }

        // Add methods for user-related operations here

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
           //addresses by user id

        public IEnumerable<Address> GetAddressesByUserId(int userId)
        {
            var user = _context.Addresses.Find(userId);
            if (user != null)
            {
                return _context.Addresses.Where(a => a.CustId == userId).ToList();
            }
            return Enumerable.Empty<Address>();
        }


        //get orders by user id
        public IEnumerable<Order> GetOrdersByUserId(int userId)
        {
            var user = _context.Orders.Find(userId);
            if (user != null)
            {
                return _context.Orders.Where(o=>o.UserId==userId).ToList();
            }
            return Enumerable.Empty<Order>();
        }
    }
}
