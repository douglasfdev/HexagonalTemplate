using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using HexagonalTemplate.Infrastructure.PgSql.Databases.Contexts;
using Microsoft.Extensions.Configuration;

namespace HexagonalTemplate.Infrastructure.PgSql;

public class FinanceManagementContextFactory : IDesignTimeDbContextFactory<FinanceManagementContext>
{
    public FinanceManagementContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "HexagonalTemplate.Adapters.WebApi"))
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.Development.json", optional: true, reloadOnChange: true)
            .Build();

        var connectionString = configuration.GetConnectionString("FinanceManagmentDB");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException(
                "A string de conexão 'FinanceManagmentDB' não foi encontrada nas configurações.");
        }

        var optionsBuilder = new DbContextOptionsBuilder<FinanceManagementContext>();

        optionsBuilder.UseNpgsql(
            connectionString: connectionString,
            npgsqlOptionsAction: options
                => options.MigrationsAssembly(typeof(FinanceManagementContext).Assembly.GetName().Name)
        );

        return new FinanceManagementContext(optionsBuilder.Options);
    }
}