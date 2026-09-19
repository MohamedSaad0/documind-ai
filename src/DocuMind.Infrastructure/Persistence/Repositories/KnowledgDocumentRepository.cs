using DocuMind.Application.Abstractions.Persistence;
using DocuMind.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocuMind.Infrastructure.Persistence.Repositories
{
    public class KnowledgeDocumentRepository : IKnowledgeDocumentRepository
    {
        private readonly DocuMindDbContext _dbContext;

        public KnowledgeDocumentRepository(DocuMindDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<KnowledgeDocument?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.KnowledgeDocuments.AsNoTracking().FirstOrDefaultAsync(document => document.Id == id, cancellationToken);
        }

        public async Task<IReadOnlyList<KnowledgeDocument>> GetAllAysnc(CancellationToken cancellationToken = default)
        {
            return await _dbContext.KnowledgeDocuments.AsNoTracking().ToListAsync(cancellationToken);
        }

        public void Add(KnowledgeDocument document)
        {
            _dbContext.KnowledgeDocuments.Add(document);
        }

        public void Remove(KnowledgeDocument document)
        {
            _dbContext.Remove(document);
        }

        public async Task<KnowledgeDocument?> GetByIdForUpdateAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.KnowledgeDocuments.FirstOrDefaultAsync(document => document.Id == id, cancellationToken);
        }
    }
}
