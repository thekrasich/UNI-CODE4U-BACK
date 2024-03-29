using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CashRegisterStore.DAL.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(o => o.UserId);

            builder.HasIndex(o => o.CreationDateTime);

            builder.Property(o => o.Status)
                .IsFixedLength()
                .HasMaxLength(1);
        }
    }
}
