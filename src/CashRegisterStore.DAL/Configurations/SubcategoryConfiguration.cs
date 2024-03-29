using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashRegisterStore.DAL.Configurations
{
    public class SubcategoryConfiguration : IEntityTypeConfiguration<Subcategory>
    {
        public void Configure(EntityTypeBuilder<Subcategory> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne<Category>()
                .WithMany()
                .HasForeignKey(s => s.CategoryId);

            builder.Property(s => s.Name)
                .HasMaxLength(40);

            builder.HasIndex(s => s.Name)
                .IsUnique();
        }
    }
}
