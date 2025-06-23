using HexagonalTemplate.Core.Domain.Modules.Budgets.Aggregates;
using HexagonalTemplate.Core.Domain.Modules.Budgets.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HexagonalTemplate.Infrastructure.PgSql.Databases.Configurations.Budgets;

public class BudgetConfiguration : IEntityTypeConfiguration<Budget>
{
    public void Configure(EntityTypeBuilder<Budget> builder)
    {
        builder.ToTable(nameof(Budget));

        builder.HasKey(budget => budget.Id);

        builder.Property(prop => prop.ReferencePeriod)
            .HasConversion(
                dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
                dateTime => DateOnly.FromDateTime(dateTime)
            );

        builder
            .OwnsMany(
                account => account.Categories,
                categoryNavigationBuilder =>
                {
                    categoryNavigationBuilder.ToTable(nameof(Category));

                    categoryNavigationBuilder.Property<int>("Id").IsRequired();
                    categoryNavigationBuilder.HasKey("Id");

                    categoryNavigationBuilder
                        .OwnsMany(
                            account => account.Transactions,
                            transactionsNavigationBuilder =>
                            {
                                transactionsNavigationBuilder.ToTable(nameof(Transaction));

                                transactionsNavigationBuilder.Property<int>("Id").IsRequired();
                                transactionsNavigationBuilder.HasKey("Id");
                            }
                        );
                }
            );
    }
}