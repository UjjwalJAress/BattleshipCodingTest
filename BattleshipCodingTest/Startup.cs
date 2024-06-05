using BattleshipCodingTest.Interfaces;
using BattleshipCodingTest.Services;
using BattleshipCodingTest.Utilities;
using Microsoft.AspNetCore.Mvc;
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
            //services.AddCors(c =>
            //{
            //    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod()
            //     .AllowAnyHeader());
            //});
            //services.AddSession();
            //services.AddMvc(options =>
            //{
            //    options.Filters.Add(new ResponseCacheAttribute
            //    {
            //        Location = ResponseCacheLocation.None,
            //        NoStore = true
            //    });
            //});
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            //services.AddHttpClient();

            //service registration
            services.AddScoped<IBattleshipService, BattleshipService>();
            //services.AddControllers().AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            //});
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
            //app.UseHttpsRedirection();
            //app.UseRouting();
            //app.UseCors("AllowOrigin");
            app.UseExceptionHandlingMiddleware();
            //app.UseSession();
            //app.MapControllers();
        }
    }
}