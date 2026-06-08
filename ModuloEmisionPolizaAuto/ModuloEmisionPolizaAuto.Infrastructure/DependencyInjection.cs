using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModuloEmisionPolizaAuto.Application.Interfaces;
using ModuloEmisionPolizaAuto.Infrastructure.Persistence;
using ModuloEmisionPolizaAuto.Infrastructure.Repositories;

namespace ModuloEmisionPolizaAuto.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
    this IServiceCollection services,
    IConfiguration configuration)
    {
        services.AddDbContext<Dbcontext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IGenericInterface, GenericRepository>();

        return services;
    }

}
