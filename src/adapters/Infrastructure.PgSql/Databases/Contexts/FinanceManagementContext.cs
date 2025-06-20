using Microsoft.EntityFrameworkCore;

namespace Infrastructure.PgSql.Databases.Contexts;

public class FinanceManagementContext(DbContextOptions options): DbContext(options)
{
    
}