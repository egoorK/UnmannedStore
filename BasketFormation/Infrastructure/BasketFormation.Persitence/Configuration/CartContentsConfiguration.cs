using Microsoft.EntityFrameworkCore;
using BasketFormation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasketFormation.Persitence.Configuration
{
    public class CartContentsConfiguration : IEntityTypeConfiguration<CartContents>
    {
        public void Configure(EntityTypeBuilder<CartContents> builder)
        {
            builder.HasKey(u => u.CartContents_ID);
            builder.Property(u => u.CartContents_ID).HasColumnName("CartContents_ID").HasColumnType("uuid");
            builder.Property(u => u.Discount_price).HasColumnType("numeric");
            builder.Property(u => u.Quantity).HasColumnType("integer");
            builder.Property(u => u.Price_incl_quantity).HasColumnType("numeric");
            builder.Property(u => u.Item_number_in_cart).HasColumnType("integer");
        }
    }
}
