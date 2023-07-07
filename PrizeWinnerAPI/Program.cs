
using Microsoft.EntityFrameworkCore;
using PrizeWinnerAPI.Models;
using PrizeWinnerAPI.Repositories;

namespace PrizeWinnerAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<GuestRepository>();


            var connectionString = builder.Configuration.GetConnectionString("AWS_Server");
            builder.Services.AddDbContext<AppDbContext>(c => c.UseSqlServer(connectionString));


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