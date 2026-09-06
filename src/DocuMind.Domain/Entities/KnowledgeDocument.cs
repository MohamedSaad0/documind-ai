using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace DocuMind.Domain.Entities
{
    public class KnowledgeDocument
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public string DocumentType { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private KnowledgeDocument()
        {
            // Required by EF core      
        }

        public KnowledgeDocument(string title, string content, string documentType)
        {           
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Document title is required.", nameof(title));

            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("content", nameof(content));

            if (string.IsNullOrWhiteSpace(documentType))
                throw new ArgumentException( "Document type is required.", nameof(documentType));

            Id = Guid.NewGuid();
            Title = title;
            Content = content;
            DocumentType = documentType;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
