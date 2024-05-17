using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.EntityFramework.Configurations;

internal sealed class CredentialsConfiguration : IEntityTypeConfiguration<CredentialsEntity>
{
    public void Configure(EntityTypeBuilder<CredentialsEntity> builder)
    {
        builder.ToTable("Credentials").HasKey(credentials => credentials.Id);
    }
}