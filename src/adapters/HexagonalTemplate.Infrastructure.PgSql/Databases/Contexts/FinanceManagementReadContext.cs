using Microsoft.EntityFrameworkCore;

namespace HexagonalTemplate.Infrastructure.PgSql.Databases.Contexts;

public class FinanceManagementReadContext(DbContextOptions<FinanceManagementReadContext> options) : DbContext(options)
{
    
}