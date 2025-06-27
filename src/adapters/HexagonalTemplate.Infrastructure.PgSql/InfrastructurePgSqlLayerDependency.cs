using HexagonalTemplate.Core.Application.Abstractions.Ports.Repositories;
using HexagonalTemplate.Infrastructure.PgSql.Databases;
using HexagonalTemplate.Infrastructure.PgSql.Databases.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HexagonalTemplate.Infrastructure.PgSql;

public static class InfrastructurePgSqlLayerDependency
{
    public static IServiceCollection AddPgSqlLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FinanceManagementContext>((builder) =>
        {
            builder
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
                .UseNpgsql(
                    connectionString: configuration.GetConnectionString("FinanceManagmentDBWrite"),
                    npgsqlOptionsAction: options
                        => options.MigrationsAssembly(typeof(FinanceManagementContext).Assembly.GetName().Name)
                )
                .ConfigureWarnings(warning =>
                    warning.Default(WarningBehavior.Throw)
                        .Log(CoreEventId.SensitiveDataLoggingEnabledWarning)
                );
        });

        services.AddDbContext<FinanceManagementReadContext>((builder) =>
        {
            builder
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
                .UseNpgsql(
                    configuration.GetConnectionString("FinanceManagmentDBRead"),
                    options => options.MigrationsAssembly(typeof(FinanceManagementContext).Assembly.GetName().Name)
                )
                .ConfigureWarnings(warning =>
                    warning.Default(WarningBehavior.Throw)
                        .Log(CoreEventId.SensitiveDataLoggingEnabledWarning)
                );
        });

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddScoped<IFinanceManagementRepository, FinanceManagmentRepository>();
        services.AddScoped<IFinanceManagementReadRepository, FinanceManagmentReadRepository>();

        return services;
    }
}