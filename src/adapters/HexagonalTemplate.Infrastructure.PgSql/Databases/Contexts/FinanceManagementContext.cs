using HexagonalTemplate.Core.Application.Contracts;
using HexagonalTemplate.Core.Domain.Modules.Accounts.Aggregates;
using HexagonalTemplate.Core.Domain.Modules.Accounts.Entities;
using HexagonalTemplate.Core.Domain.Modules.Budgets.Aggregates;
using HexagonalTemplate.Core.Domain.Modules.Budgets.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace HexagonalTemplate.Infrastructure.PgSql.Databases.Contexts;

public class FinanceManagementContext(DbContextOptions<FinanceManagementContext> options): DbContext(options)
{
    #region Account
    public DbSet<Account> Accounts { get; set; }
    
    public DbSet<Profile> Profiles { get; set; }
    
    public DbSet<Transaction> Transactions { get; set; }
    #endregion
    
    #region Budget
    public DbSet<Budget> Budgets { get; set; }
    
    public DbSet<Category> Categories { get; set; }
    #endregion

    #region Views
    public DbSet<ViewModel.BalanceViewModel> BalanceViewModels { get; set; }
    
    public DbSet<ViewModel.CategoryViewModel> CategoryViewModels { get; set; }
    
    public DbSet<ViewModel.TransactionViewModel> TransactionViewModels { get; set; }
    #endregion
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        modelBuilder.Entity<ViewModel.BalanceViewModel>().HasNoKey().ToView(nameof(ViewModel.BalanceViewModel));
        modelBuilder.Entity<ViewModel.CategoryViewModel>().HasNoKey().ToView(nameof(ViewModel.CategoryViewModel));
        modelBuilder.Entity<ViewModel.TransactionViewModel>().HasNoKey().ToView(nameof(ViewModel.TransactionViewModel));
    }
    
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        => configurationBuilder.Properties<string>()
            .AreUnicode(false)
            .HaveMaxLength(1024);
}