using HexagonalTemplate.Core.Application.Abstractions.Ports.Repositories;
using Infrastructure.PgSql.Databases;
using Infrastructure.PgSql.Databases.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.PgSql;

public static class InfrastructurePgSqlLayerDependency
{
    public static IServiceCollection AddPgSqlLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DbContext, FinanceManagementContext>((provider, builder) =>
        {
            builder
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
                .UseNpgsql(
                    connectionString: configuration.GetConnectionString("FinanceManagmentDB"),
                    npgsqlOptionsAction: options
                        => options.MigrationsAssembly(typeof(FinanceManagementContext).Assembly.GetName().Name)
                );
        });

        services.AddScoped<IFinanceManagementRepository, FinanceManagmentRepository>();

        return services;
    }
}