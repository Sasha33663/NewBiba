
using Application;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Presentation.Controllers;

namespace WebApplication3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddApplicationPart(typeof(UserController).Assembly);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<IUserServes, UserServes>();
            builder.Services.AddDbContext<Database>((options) => options.UseNpgsql("Server=localhost;Port=5432;Database=Meow;User Id=postgres;Password=Batonbatonbaton123;"));
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();//newсапро 2 
     
            app.MapControllers();

            app.Run();//ertyyteytrty

 
        }
    }
}
