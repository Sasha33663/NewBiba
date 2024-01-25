
using Application;
using Infrastructure;
using Infrastructure.NoteRepository;
using Infrastructure.UserRepository;
using Microsoft.EntityFrameworkCore;
using Presentation.Controllers;

namespace WebApplication3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers().AddApplicationPart(typeof(UserController).Assembly);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<Database>((options) => options.UseNpgsql("Server=localhost;Port=5432;Database=Meow;User Id=postgres;Password=Batonbatonbaton123;"));
            
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IUserServes, UserServes>();
            builder.Services.AddTransient<INoteRepository, NoteRepository>();
           
                
            var app = builder.Build();

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
