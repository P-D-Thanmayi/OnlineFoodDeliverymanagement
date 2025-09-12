using Domain.Data;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OrderServices
    {
        private readonly AppDbContext _context;
        public OrderServices(AppDbContext context)
        {
            _context = context;
        }
        public void AddOrder(int userId, int restaurantId)
        {
            var newOrder = new Order
            {
                UserId = userId,
                RestaurantId = restaurantId
            };

            _context.Orders.Add(newOrder);
            _context.SaveChanges();
        }

        public IEnumerable<Order> GetOrderByUserId(int userId)
        {
            var user = _context.Orders.Find(userId);
            if (user != null)
            {
                return _context.Orders.Where(o => o.UserId == userId).ToList();
            }
            return Enumerable.Empty<Order>();
        }

        public IEnumerable<Order> GetOrderByRestaurantId(int restaurantId)
        {
            var user = _context.Orders.Find(restaurantId);
            if (user != null)
            {
                return _context.Orders.Where(o => o.RestaurantId == restaurantId).ToList();
            }
            return Enumerable.Empty<Order>();
        }

        public IEnumerable<Order> GetOrderByOrderId(int orderId)
        {
            var user = _context.Orders.Find(orderId);
            if (user != null)
            {
                return _context.Orders.Where(o => o.OrderId == orderId).ToList();
            }
            return Enumerable.Empty<Order>();
        }


    }
}
