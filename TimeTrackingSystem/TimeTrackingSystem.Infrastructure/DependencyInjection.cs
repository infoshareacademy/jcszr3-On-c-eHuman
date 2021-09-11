using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
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
            return services;
        }
    }
}
