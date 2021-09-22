using Microsoft.Extensions.DependencyInjection;
using TimeTrackingSystem.Domain.Interfaces;
using TimeTrackingSystem.Infrastructure.Repositories;

namespace TimeTrackingSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<ITimeSheetRepository, TimeSheetRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IActivityRepository, ActivityRepository>();
            services.AddTransient<ILeavesRepository, LeavesRepository>();
            return services;
        }
    }
}
