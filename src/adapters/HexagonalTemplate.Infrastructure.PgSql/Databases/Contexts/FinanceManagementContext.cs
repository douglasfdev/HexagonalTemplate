using Microsoft.EntityFrameworkCore;

namespace HexagonalTemplate.Infrastructure.PgSql.Databases.Contexts;

public class FinanceManagementContext(DbContextOptions options): DbContext(options)
{
    
}