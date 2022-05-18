using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.API.StartupExtensions;
using ToDoList.Models;

namespace ToDoList.API
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ToDoListContext>(
                options => { options.UseSqlServer(_configuration.GetConnectionString("default")); });

            services.AddCors();
            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(BL.Helpers.AutoMapper).Assembly);
            services.AddSwaggerService();
            services.RegisterDependencyInjectionSettings(_configuration);
            services.AddAuthentication(_configuration);
            services.RegisterDependencyInjectionServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();
            app.UseSwaggerService(env);
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}