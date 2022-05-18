using Microsoft.Extensions.DependencyInjection;
using ToDoList.BL.Logic;
using ToDoList.BL.LogicInterfaces;
using ToDoList.BL.Repository;
using ToDoList.BL.RepositoryInterfaces;
using ToDoList.BL.ServiceInterfaces;
using ToDoList.BL.Services;
using ToDoList.BL.Services.EmailProviders;

namespace ToDoList.API.StartupExtensions
{
    public static class StartupDependencyInjectionExtension
    {
        public static IServiceCollection RegisterDependencyInjectionServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBaseGeneric<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserLogic, UserLogic>();
            services.AddScoped<IProjectLogic, ProjectLogic>();
            services.AddScoped<INotificationLogic, NotificationLogic>();
            services.AddScoped<ISharedProjectLogic, SharedProjectLogic>();
            services.AddScoped<IToDoTaskLogic, ToDoTaskLogic>();
            services.AddScoped<ITokenLogic, TokenLogic>();
            services.AddScoped<IEmailProviderFabric, EmailProviderFabric>();
            services.AddScoped<IFileService, LocalFileService>();
            services.AddScoped<IPdfService, PdfService>();
            
            return services;
        }
    }
}