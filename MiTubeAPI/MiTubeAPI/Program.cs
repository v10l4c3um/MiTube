using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MiTubeAPI.Data;
namespace MiTubeAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<MiTubeAPIContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MiTubeAPIContext") ?? throw new InvalidOperationException("Connection string 'MiTubeAPIContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
