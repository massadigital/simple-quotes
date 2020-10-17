using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleQuotes.Domain.Model.Entity;

namespace SimpleQuotes.Data.Entity.Abstraction.Configuration
{
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .ToTable("PRODUCT");

            builder
              .HasKey(e => e.ProductId)
              .HasName("PK_PRODUCT");

            builder
                .HasIndex(e => e.ProductSku)
                .HasName("UQ_PRODUCT_SKU")
                .IsUnique();

            builder
                .Property(e => e.ProductId)
                .HasColumnName("PRODUCT_ID")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.ProductName)
                .HasColumnName("PRODUCT_NAME")
                .HasMaxLength(256)
                .IsUnicode()
                .IsRequired();
                
            builder
                .Property(e => e.ProductPrice)
                .HasColumnName("PRODUCT_PRICE")
                .HasColumnType("DECIMAL(20,2)")
                .IsRequired();

            builder.Property(e => e.ProductSku)
                .HasColumnName("PRODUCT_SKU")
                .HasMaxLength(256)
                .IsUnicode()
                .IsRequired();

        }
    }
}
