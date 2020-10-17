using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SimpleQuotes.Entity
{
    public partial class quotes_modelContext : DbContext
    {
        public quotes_modelContext()
        {
        }

        public quotes_modelContext(DbContextOptions<quotes_modelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Lead> Lead { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Quote> Quote { get; set; }
        public virtual DbSet<Quoted> Quoted { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;user id=root;persistsecurityinfo=True;database=quotes_model;pwd=fti@123", x => x.ServerVersion("8.0.21-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lead>(entity =>
            {
                entity.ToTable("lead");

                entity.HasIndex(e => e.LeadEmail)
                    .HasName("LEAD_EMAIL_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.LeadId).HasColumnName("LEAD_ID");

                entity.Property(e => e.LeadEmail)
                    .IsRequired()
                    .HasColumnName("LEAD_EMAIL")
                    .HasColumnType("varchar(256)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LeadName)
                    .IsRequired()
                    .HasColumnName("LEAD_NAME")
                    .HasColumnType("varchar(256)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.HasIndex(e => e.ProductSku)
                    .HasName("PRODUCT_SKU_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("PRODUCT_NAME")
                    .HasColumnType("varchar(256)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProductPrice)
                    .HasColumnName("PRODUCT_PRICE")
                    .HasColumnType("decimal(20,3)");

                entity.Property(e => e.ProductSku)
                    .IsRequired()
                    .HasColumnName("PRODUCT_SKU")
                    .HasColumnType("varchar(256)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Quote>(entity =>
            {
                entity.ToTable("quote");

                entity.HasIndex(e => e.QuoteLeadId)
                    .HasName("FK_QUOTE_LEAD_idx");

                entity.HasIndex(e => e.QuoteProductId)
                    .HasName("FK_QUOTE_PRODUCT1_idx");

                entity.Property(e => e.QuoteId).HasColumnName("QUOTE_ID");

                entity.Property(e => e.QuoteFrom)
                    .HasColumnName("QUOTE_FROM")
                    .HasColumnType("datetime");

                entity.Property(e => e.QuoteLeadId).HasColumnName("QUOTE_LEAD_ID");

                entity.Property(e => e.QuoteProductId).HasColumnName("QUOTE_PRODUCT_ID");

                entity.Property(e => e.QuoteQuantity)
                    .HasColumnName("QUOTE_QUANTITY")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.QuoteUntil)
                    .HasColumnName("QUOTE_UNTIL")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.QuoteLead)
                    .WithMany(p => p.Quote)
                    .HasForeignKey(d => d.QuoteLeadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QUOTE_LEAD");

                entity.HasOne(d => d.QuoteProduct)
                    .WithMany(p => p.Quote)
                    .HasForeignKey(d => d.QuoteProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QUOTE_PRODUCT1");
            });

            modelBuilder.Entity<Quoted>(entity =>
            {
                entity.ToTable("quoted");

                entity.HasIndex(e => e.QuotedQuoteId)
                    .HasName("FK_QUOTED_QUOTE1_idx");

                entity.Property(e => e.QuotedId).HasColumnName("QUOTED_ID");

                entity.Property(e => e.QuotedFrom)
                    .HasColumnName("QUOTED_FROM")
                    .HasColumnType("datetime");

                entity.Property(e => e.QuotedQuoteId).HasColumnName("QUOTED_QUOTE_ID");

                entity.Property(e => e.QuotedRemmarks)
                    .IsRequired()
                    .HasColumnName("QUOTED_REMMARKS")
                    .HasColumnType("varchar(512)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.QuotedUnitPrice)
                    .HasColumnName("QUOTED_UNIT_PRICE")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.QuotedUntil)
                    .HasColumnName("QUOTED_UNTIL")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.QuotedQuote)
                    .WithMany(p => p.Quoted)
                    .HasForeignKey(d => d.QuotedQuoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QUOTED_QUOTE1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
