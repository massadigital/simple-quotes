using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleQuotes.Domain.Model.Entity;

namespace SimpleQuotes.Data.Entity.Abstraction.Configuration
{
    class LeadConfiguration : IEntityTypeConfiguration<Lead>
    {
        public void Configure(EntityTypeBuilder<Lead> builder)
        {
            builder
                .ToTable("LEAD");

            builder
                .HasKey(e => e.LeadId)
                .HasName("PK_LEAD");

            builder
                .HasIndex(e => e.LeadEmail)
                .HasName("UQ_LEAD_EMAIL")
                .IsUnique();

            builder
                .Property(e => e.LeadId)
                .HasColumnName("LEAD_ID")
                .ValueGeneratedOnAdd();

            builder
                .Property(e => e.LeadEmail)
                .HasColumnName("LEAD_EMAIL")
                .HasMaxLength(256)
                .IsUnicode()
                .IsRequired();

            builder
                .Property(e => e.LeadName)
                .HasColumnName("LEAD_NAME")
                .HasMaxLength(256)
                .IsUnicode()
                .IsRequired();

            //.HasColumnType("varchar(256)")
            //.HasCharSet("utf8")
            //.HasCollation("utf8_general_ci");
        }
    }
}
