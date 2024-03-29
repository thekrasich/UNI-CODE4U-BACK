using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashRegisterStore.DAL.Configurations
{
    public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.HasKey(ph => ph.Id);

            builder.HasOne<Product>()
                .WithMany()
                .HasForeignKey(ph => ph.ProductId);

            builder.Property(ph => ph.Path)
                .HasMaxLength(256);
        }
    }
}