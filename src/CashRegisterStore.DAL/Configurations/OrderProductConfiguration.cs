using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashRegisterStore.DAL.Configurations
{
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.HasKey(o => new { o.OrderId, o.ProductId });

            builder.HasOne<Order>()
                .WithMany()
                .HasForeignKey(o => o.OrderId);

            builder.HasOne<Product>()
                .WithMany()
                .HasForeignKey(o => o.ProductId);
        }
    }
}
