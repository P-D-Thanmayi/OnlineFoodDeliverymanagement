using Microsoft.EntityFrameworkCore;
using Infrastructure.Repositories;
using Domain.Data;
using Infrastructure.Interfaces;
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
           
            
            builder.Services.AddScoped<AdminService>();
            builder.Services.AddScoped<DeliveryServices>();
            builder.Services.AddScoped<IRestaurant, RestaurantImplementation>();
            builder.Services.AddScoped<IUserRepository, UserServices>();
             builder.Services.AddScoped<IAddress, AddressServices>();
           builder.Services.AddScoped<IFoodItems, FoodItemServices>();
        builder.Services.AddScoped<OrderServices>();
           
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

