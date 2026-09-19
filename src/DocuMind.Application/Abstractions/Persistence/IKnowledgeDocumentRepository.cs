using DocuMind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocuMind.Application.Abstractions.Persistence
{
    public interface IKnowledgeDocumentRepository
    {
        Task<KnowledgeDocument?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<KnowledgeDocument>> GetAllAysnc(CancellationToken cancellationToken = default);

        void Add(KnowledgeDocument document);

        void Remove(KnowledgeDocument document);

        Task<KnowledgeDocument?> GetByIdForUpdateAsync(Guid id, CancellationToken cancellationToken = default);
    }
}