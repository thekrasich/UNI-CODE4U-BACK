using CashRegisterStore.DAL.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashRegisterStore.DAL.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(pr => pr.Id);

            builder.HasOne<Subcategory>()
                .WithMany()
                .HasForeignKey(pr => pr.SubcategoryId);

            builder.Property(pr => pr.Name)
                .HasMaxLength(50);

            builder.HasIndex(pr => pr.Name);

            builder.HasIndex(pr => pr.Price);
        }
    }
}
