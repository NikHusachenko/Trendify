using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.EntityFramework.Configurations;

internal sealed class AuthenticationTokenConfiguration : IEntityTypeConfiguration<AuthenticationTokenEntity>
{
    public void Configure(EntityTypeBuilder<AuthenticationTokenEntity> builder)
    {
        builder.ToTable("Authentication tokens").HasKey(token => token.Id);

        builder.HasOne<CredentialsEntity>(token => token.Credentials)
            .WithMany(credentials => credentials.AuthenticationTokens)
            .HasForeignKey(token => token.CredentialsId);
    }
}