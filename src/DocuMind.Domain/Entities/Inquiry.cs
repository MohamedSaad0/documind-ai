using System;
using System.Collections.Generic;
using System.Text;

namespace DocuMind.Domain.Entities
{
    public class Inquiry
    {
        public Guid Id { get; private set; }
        public Guid KnowledgeDocumentId { get; private set; }

        public string Question { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Inquiry()
        {
            
        }

        public Inquiry(Guid knowledgeDocumentId, string question)
        {

            if(knowledgeDocumentId == Guid.Empty)
            {
                throw new ArgumentNullException("Knowledge document ID is required.", nameof(knowledgeDocumentId));
            }

            if (string.IsNullOrWhiteSpace(question))
            {
                throw new ArgumentException("Question is required.", nameof(question));
            }

            Id = Guid.NewGuid();
            KnowledgeDocumentId = knowledgeDocumentId;
            Question = question;
            CreatedAt = DateTime.UtcNow;
        }
    }


}
