using DocuMind.Application.Abstractions.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocuMind.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DocuMindDbContext _dbContext;

        public UnitOfWork(DocuMindDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> SaveChangesAysnc(CancellationToken cancellationToken = default)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
