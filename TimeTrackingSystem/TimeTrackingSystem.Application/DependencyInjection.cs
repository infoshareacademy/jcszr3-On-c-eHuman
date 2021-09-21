using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TimeTrackingSystem.Application.Interfaces;
using TimeTrackingSystem.Application.Services;

namespace TimeTrackingSystem.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<ITimeSheetService, TimeSheetService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IActivityService, ActivityService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
