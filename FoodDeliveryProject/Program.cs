
using Domain.Data;
using FoodDeliveryProject.Repositories;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace FoodDeliveryProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(options =>
      options.UseSqlServer(
          builder.Configuration.GetConnectionString("DefaultConnection"),
          b => b.MigrationsAssembly("Domain")
      ));





            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<UserServices>();
            builder.Services.AddScoped<AddressServices>();
            builder.Services.AddScoped<AdminService>();
<<<<<<< HEAD
            builder.Services.AddScoped<OrderItemService>();
=======
            builder.Services.AddScoped<IRestaurant, RestaurantImplementation>();
            builder.Services.AddScoped<IUserRepository, UserImplementation>();
>>>>>>> 82b9a22a46bf5610326f44db57b137d95048852b
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
