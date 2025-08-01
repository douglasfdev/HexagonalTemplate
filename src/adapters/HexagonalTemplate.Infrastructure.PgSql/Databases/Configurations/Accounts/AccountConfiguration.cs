using HexagonalTemplate.Core.Domain.Modules.Accounts.Aggregates;
using HexagonalTemplate.Core.Domain.Modules.Accounts.Entities;
using HexagonalTemplate.Core.Domain.Modules.Accounts.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HexagonalTemplate.Infrastructure.PgSql.Databases.Configurations.Accounts;

public class AccountConfiguration: IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable(nameof(Account));

        builder.HasKey(account => account.Id);

        builder
            .HasOne(account => account.Profile)
            .WithOne(profile => profile.Account)
            .HasForeignKey<Profile>(profile => profile.AccountId)
            .IsRequired();

        builder
            .OwnsOne(
                account => account.Address,
                addressNavigationBuilder =>
                {
                    addressNavigationBuilder.ToTable(nameof(Address));

                    addressNavigationBuilder.Property<int>("Id").IsRequired();
                    addressNavigationBuilder.HasKey("Id");
                }
            );
    }
}