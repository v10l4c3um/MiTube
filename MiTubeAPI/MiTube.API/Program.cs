using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MiTube.API.Data;
namespace MiTube.API
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




            //add connectin to Azure Blob
            //builder.Services.AddSingleton(provider => {
            //    IConfigurationRoot configuration = new ConfigurationBuilder().
            //    AddJsonFile("appsettings.json").
            //    Build();
            //    return configuration;
            //});

            IConfigurationRoot configuration = new ConfigurationBuilder().
                AddJsonFile("appsettings.json").
                Build();

            string connectionString = configuration["StorageConnectionString"];

            builder.Services.AddSingleton(provider => {
                BlobServiceClient serviceClient = new BlobServiceClient(connectionString);
                return serviceClient;
            });




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
