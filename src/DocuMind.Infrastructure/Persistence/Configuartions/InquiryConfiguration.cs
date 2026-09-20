using DocuMind.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuMind.Infrastructure.Persistence.Configurations
{
    public sealed class InquiryConfiguration : IEntityTypeConfiguration<Inquiry>
    {

        public void Configure(EntityTypeBuilder<Inquiry> builder) 
        {
            builder.ToTable("Inquiries");

            builder.HasKey(inquiry => inquiry.Id);

            builder.Property(inquiry => inquiry.Question).IsRequired().HasMaxLength(2000);

            builder.Property(inquiry => inquiry.CreatedAt).IsRequired();

            builder.HasOne<KnowledgeDocument>().WithMany()
                .HasForeignKey(inquiry => inquiry.KnowledgeDocumentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
