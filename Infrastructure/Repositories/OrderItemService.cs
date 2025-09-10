using FoodDeliveryProject.Data;
using FoodDeliveryProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Metadata;


namespace FoodDeliveryProject.Repositories
{
	public class OrderItemService
	{
		
     	private readonly AppDbContext _context;
			public OrderItemService(AppDbContext context)
			{
				_context = context;
			}
			public IEnumerable<FoodItem> GetFoodByOrderId(int id)
			{

				var foodItems = _context.OrderItems
                            .Include(oi => oi.Item)
                            .Where(oi => oi.OrderId == id)
                            .Select(oi => oi.Item)
                            .Where(item => item != null)
                            .ToList();

				return foodItems!;

            

			}

	}

}

