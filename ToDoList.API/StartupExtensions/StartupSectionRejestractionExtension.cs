using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.BL.Helpers;

namespace ToDoList.API.StartupExtensions
{
    public static class StartupSectionRejestractionExtension
    {
        public static IServiceCollection RegisterDependencyInjectionSettings(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
            services.Configure<SmtpSettings>(configuration.GetSection("SmtpSettings"));
            services.Configure<FileSettings>(configuration.GetSection("FileSettings"));
            services.Configure<SwaggerSettings>(configuration.GetSection("SwaggerSettings"));

            return services;
        }
    }
}