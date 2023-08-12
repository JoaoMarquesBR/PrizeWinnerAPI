
using Microsoft.EntityFrameworkCore;
using PrizeWinner.Application.Interface.IRepository;
using PrizeWinner.Application.Services;
using PrizeWinner.Domain.Entities;
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

            var connectionString = builder.Configuration.GetConnectionString("AWS_Server");
            builder.Services.AddDbContext<TheFactoryDevContext>(c => c.UseSqlServer(connectionString));

            builder.Services.AddScoped<IPromotionGroupRepository, PromotionGroupRepository>();
            builder.Services.AddScoped<IPromotionGroupService, PromotionGroupService>();


            builder.Services.AddScoped<IGuestService<Guest>, GuestService>();
            builder.Services.AddScoped<IGuestRepository<Guest>, GuestRepository>();

            //POR QUE O REPOSITORY TA DANDO ERRO PRA SER INICIADO? MEU DEUS!!!!!!!!!!!!!!
            builder.Services.AddScoped<IItemService<Item>, ItemService>();
            builder.Services.AddScoped<IItemRepository<Item>, IItemRepository>();


            builder.Services.AddScoped<IItemGroupRepository<ItemGroup>, ITemGroupRepository>();
            builder.Services.AddScoped<IItemGroupService<ItemGroup>, ItemGroupService>();



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