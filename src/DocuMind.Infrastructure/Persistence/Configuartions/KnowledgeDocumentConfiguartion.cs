using DocuMind.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuMind.Infrastructure.Persistence.Configurations
{
    public class KnowledgeDocumentConfiguartion : IEntityTypeConfiguration<KnowledgeDocument>
    {
        public void Configure(EntityTypeBuilder<KnowledgeDocument> builder)
        {

            builder.ToTable("KnowledgeDocuments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Content)
                .IsRequired();

            builder.Property(x => x.DocumentType)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.CreatedAt)
                .IsRequired();
        }
    }
    }
