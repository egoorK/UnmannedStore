using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Clients.Domain.Entities;

namespace Clients.Persistence.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(u => u.Account_ID);
            builder.Property(u => u.Account_ID).HasColumnName("Account_ID").HasColumnType("uuid");
            builder.Property(u => u.Email).HasDefaultValue(null);
            builder.Property(u => u.Phone_number).IsRequired().HasDefaultValue(null);
            builder.Property(u => u.Username).IsRequired(); // Not NULL
            builder.Property(u => u.Date_of_Birth).IsRequired().HasColumnType("date");
        }
    }
}
