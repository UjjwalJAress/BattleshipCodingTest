using BattleshipCodingTest.Interfaces;
using BattleshipCodingTest.Services;
using BattleshipCodingTest.Utilities;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace BattleshipCodingTest
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            //service registration
            services.AddScoped<IBattleshipService, BattleshipService>();
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BattleshipCodingTest", Version = "v1" });
            });
        }
        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseExceptionHandlingMiddleware();
            app.MapControllers();
        }
    }
}