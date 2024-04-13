
using Esercitazione12Aprile_MarioKart.Model;
using Esercitazione12Aprile_MarioKart.Repository;
using Esercitazione12Aprile_MarioKart.Service;
using Microsoft.EntityFrameworkCore;

namespace Esercitazione12Aprile_MarioKart
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            IServiceCollection services = builder.Services;
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Importanti per la configurazione di Context e Repository
            builder.Services.AddDbContext<Es12AprileContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
                ));
            builder.Services.AddScoped<PersonaggioRepository>();
            builder.Services.AddScoped<PersonaggioService>();
            builder.Services.AddScoped<SquadraRepository>();
            builder.Services.AddScoped<SquadraService>();
            #endregion


            var app = builder.Build();

            app.UseCors(builder =>
                 builder
                 .WithOrigins("*")
                 .AllowAnyMethod()
                 .AllowAnyHeader());

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
