using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Clients.Domain.Entities;

namespace Clients.Persistence.Configuration
{
    public class UserDeviceConfiguration : IEntityTypeConfiguration<UserDevice>
    {
        public void Configure(EntityTypeBuilder<UserDevice> builder)
        {
            builder.HasKey(u => u.Device_ID);
            builder.Property(u => u.Device_ID).HasColumnName("Device_ID").HasColumnType("uuid");
            builder.Property(u => u.Brand).HasDefaultValue(null);
            builder.Property(u => u.Model).HasDefaultValue(null);
            builder.Property(u => u.Screen_resolution_height).HasDefaultValue(0);
            builder.Property(u => u.Screen_resolution_width).HasDefaultValue(0);
        }
    }
}
