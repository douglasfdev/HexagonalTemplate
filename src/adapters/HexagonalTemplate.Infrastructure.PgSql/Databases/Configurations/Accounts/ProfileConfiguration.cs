using HexagonalTemplate.Core.Domain.Modules.Accounts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HexagonalTemplate.Infrastructure.PgSql.Databases.Configurations.Accounts;

public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.ToTable(nameof(Profile));

        builder.HasKey(profile => profile.Id);
    }
}