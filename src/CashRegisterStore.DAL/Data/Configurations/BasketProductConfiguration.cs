using CashRegisterStore.DAL.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashRegisterStore.DAL.Data.Configurations
{
    public class BasketProductConfiguration : IEntityTypeConfiguration<BasketProduct>
    {
        public void Configure(EntityTypeBuilder<BasketProduct> builder)
        {
            builder.HasKey(bp => new { bp.BasketId, bp.ProductId });

            builder.HasOne<Basket>()
                .WithMany()
                .HasForeignKey(bp => bp.BasketId);

            builder.HasOne<Product>()
                .WithMany()
                .HasForeignKey(bp => bp.ProductId);
        }
    }
}
