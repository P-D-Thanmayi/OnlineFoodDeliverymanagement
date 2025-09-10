

using FoodDeliveryProject.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Infrastructure.Repositories

{

    public class ReviewService

    {

        private readonly AppDbContext _context;

        public ReviewService(AppDbContext context)

        {

            _context = context;

        }


        public decimal GetAverageRatingByRestaurantName(string restaurantName)

        {

            var averageRating = _context.Reviews

                .Include(r => r.Restaurant)

                .ThenInclude(r => r.User)

                .Where(r => r.Restaurant != null)

                .Select(r => r.Rating)

                .Average();

            return (decimal)averageRating;

        }

        public IEnumerable<string> GetRestaurantNameByRating(decimal rating)

        {

            var restaurantNames = _context.Reviews

                    .Include(r => r.Restaurant)

                    .ThenInclude(res => res.User)

                    .Where(r => r.Rating == rating && r.Restaurant != null)

                    .Select(r => r.Restaurant.User.Name)

                    .Distinct()

                    .ToList();

            return restaurantNames;

        }


    }

}

