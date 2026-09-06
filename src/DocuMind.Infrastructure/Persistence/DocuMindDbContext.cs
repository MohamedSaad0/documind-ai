using System;
using System.Collections.Generic;
using System.Text;
using DocuMind.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocuMind.Infrastructure.Persistence
{
    public class DocuMindDbContext : DbContext
    {
        public DocuMindDbContext(DbContextOptions<DocuMindDbContext> options) : base(options) { }

        public DbSet<KnowledgeDocument> KnowledgeDocuments => Set<KnowledgeDocument>();

        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DocuMindDbContext).Assembly);

            base.OnModelCreating(modelBuilder);

        }
    }
}
