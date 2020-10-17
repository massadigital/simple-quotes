using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleQuotes.Domain.Model.Entity;

namespace SimpleQuotes.Data.Entity.Abstraction.Configuration
{
    class QuotedConfiguration : IEntityTypeConfiguration<Quoted>
    {
        public void Configure(EntityTypeBuilder<Quoted> builder)
        {
            builder
                .ToTable("QUOTED");

            builder
                .HasKey(e => e.QuotedId)
                .HasName("PK_QUOTE");

            builder
                .HasIndex(e => e.QuotedQuoteId)
                .HasName("FK_QUOTED_QUOTE_IDX");

            builder
                .Property(e => e.QuotedId)
                .HasColumnName("QUOTED_ID")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.QuotedFrom)
                .HasColumnName("QUOTED_FROM")
                .IsRequired();

            builder
                .Property(e => e.QuotedQuoteId)
                .HasColumnName("QUOTED_QUOTE_ID")
                .IsRequired();

            builder
                .Property(e => e.QuotedRemmarks)
                .HasColumnName("QUOTED_REMMARKS")
                .HasMaxLength(512)
                .IsUnicode()
                .IsRequired();

            builder
                .Property(e => e.QuotedUnitPrice)
                .HasColumnName("QUOTED_UNIT_PRICE")
                .HasColumnType("DECIMAL(20,2)")
                .IsRequired();

            builder
                .Property(e => e.QuotedUntil)
                .HasColumnName("QUOTED_UNTIL")
                .IsRequired();

            builder
                .HasOne(d => d.QuotedQuote)
                .WithMany()
                .HasForeignKey(d => d.QuotedQuoteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QUOTED_QUOTE");
        }
    }
}
