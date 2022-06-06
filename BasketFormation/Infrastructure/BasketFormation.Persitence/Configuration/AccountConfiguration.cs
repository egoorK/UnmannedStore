using BasketFormation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasketFormation.Persitence.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(u => u.Account_ID);
            builder.Property(u => u.Account_ID).HasColumnName("Account_ID").HasColumnType("uuid");
            builder.Property(u => u.Username).IsRequired(); // Not NULL
        }
    }
}
