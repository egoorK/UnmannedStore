using BasketFormation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasketFormation.Persitence.Configuration
{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.HasKey(u => u.ShoppingCart_ID);
            builder.Property(u => u.ShoppingCart_ID).HasColumnName("ShoppingCart_ID").HasColumnType("uuid");
            builder.Property(u => u.Fill_start_time).HasColumnType("timestamp");
            builder.Property(u => u.Fill_end_time).HasColumnType("timestamp");
            builder.Property(u => u.Total_without_discount).HasColumnType("numeric");
            builder.Property(u => u.Total_with_discount).HasColumnType("numeric");
        }
    }
}
