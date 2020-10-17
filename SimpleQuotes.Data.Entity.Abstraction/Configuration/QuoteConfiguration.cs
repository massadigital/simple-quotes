using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleQuotes.Domain.Model.Entity;

namespace SimpleQuotes.Data.Entity.Abstraction.Configuration
{
    class QuoteConfiguration : IEntityTypeConfiguration<Quote>
    {
        public void Configure(EntityTypeBuilder<Quote> builder)
        {
            builder
                .ToTable("QUOTE");

            builder
                .HasKey(e => e.QuoteId)
                .HasName("PK_QUOTE");

            builder
                .HasIndex(e => e.QuoteLeadId)
                .HasName("FK_QUOTE_LEAD_IDX");

            builder
                .HasIndex(e => e.QuoteProductId)
                .HasName("FK_QUOTE_PRODUCT_IDX");

            builder
                .Property(e => e.QuoteId)
                .HasColumnName("QUOTE_ID")
                .ValueGeneratedOnAdd();

            builder
                .Property(e => e.QuoteFrom)
                .HasColumnName("QUOTE_FROM")
                .IsRequired();

            builder
                .Property(e => e.QuoteLeadId)
                .HasColumnName("QUOTE_LEAD_ID")
                .IsRequired();

            builder
                .Property(e => e.QuoteProductId)
                .HasColumnName("QUOTE_PRODUCT_ID")
                .IsRequired();

            builder
                .Property(e => e.QuoteQuantity)
                .HasColumnName("QUOTE_QUANTITY")
                .HasColumnType("DECIMAL(20,2)")
                .IsRequired();

            builder
                .Property(e => e.QuoteUntil)
                .HasColumnName("QUOTE_UNTIL")
                .IsRequired();

            builder
              .Property(e => e.QuoteRemmarks)
              .HasColumnName("QUOTE_REMMARKS")
              .HasMaxLength(512)
              .IsUnicode()
              .IsRequired();

            builder
                .HasOne(d => d.QuoteLead)
                .WithMany()
                .HasForeignKey(d => d.QuoteLeadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QUOTE_LEAD");

            builder
                .HasOne(d => d.QuoteProduct)
                .WithMany()
                .HasForeignKey(d => d.QuoteProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QUOTE_PRODUCT");
        }
    }
}
