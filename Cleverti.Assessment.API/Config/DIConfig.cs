using Cleverti.Assessment.Application.AppServices;
using Cleverti.Assessment.Application.Interfaces;
using Cleverti.Assessment.Data.Context;
using Cleverti.Assessment.Data.Repository;
using Cleverti.Assessment.Data.UoW;
using Cleverti.Assessment.Domain.Interfaces;
using Cleverti.Assessment.Domain.Interfaces.Repository;
using Cleverti.Assessment.Domain.Notifications;
using Microsoft.Extensions.DependencyInjection;
namespace Cleverti.Assessment.API.Config
{
    public static class DIConfig
    {
        public static IServiceCollection ResolveDI(this IServiceCollection services)
        {
            services.AddScoped<MemoryContext>();
            services.AddScoped<ITodoAppService, TodoAppService>();
            services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddScoped<INotificationContext, NotificationContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
