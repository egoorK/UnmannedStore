using BasketFormation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasketFormation.Persitence.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(u => u.Product_ID);
            builder.Property(u => u.Product_ID).HasColumnName("Product_ID").HasColumnType("uuid");
            builder.Property(u => u.Name).HasDefaultValue(null);
            builder.Property(u => u.Unit_price).IsRequired().HasDefaultValue(0);  // Not NULL
            builder.Property(u => u.Article_number).HasDefaultValue(null);
        }
    }
}
