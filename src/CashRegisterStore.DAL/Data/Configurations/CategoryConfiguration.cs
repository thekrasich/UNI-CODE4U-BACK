using CashRegisterStore.DAL.Data.Entities;
using CashRegisterStore.DAL.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashRegisterStore.DAL.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasMaxLength(40);

            builder.HasIndex(c => c.Name)
                .IsUnique();

            ProductCategory[] productCategories = Enum.GetValues<ProductCategory>();
            ProductCategory currentCategory;

            int count = productCategories.Length;
            Category[] categories = new Category[count];

            for (int i = 0; i < count; ++i)
            {
                currentCategory = productCategories[i];

                categories[i] = new Category()
                {
                    Id = (short)currentCategory,
                    Name = currentCategory.ToString()
                };
            }

            builder.HasData(categories);
        }
    }
}
