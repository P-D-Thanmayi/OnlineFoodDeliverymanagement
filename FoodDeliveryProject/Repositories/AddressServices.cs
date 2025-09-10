using FoodDeliveryProject.Models;
using FoodDeliveryProject.Data;
using System.Linq;
namespace FoodDeliveryProject.Repositories
{
    public class AddressServices
    {
        private readonly AppDbContext _context;
        public AddressServices(AppDbContext context)
        {
            _context = context;
        }
        
        
        // Add a new address
        public void AddAddress(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
        }
        // Update an existing address
        public void UpdateAddress(Address address)
        {
            _context.Addresses.Update(address);
            _context.SaveChanges();
        }
        // Delete an address by ID
        public bool DeleteAddress(int id)
        {
            var address = _context.Addresses.Find(id);
            if (address != null)
            {
                _context.Addresses.Remove(address);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
