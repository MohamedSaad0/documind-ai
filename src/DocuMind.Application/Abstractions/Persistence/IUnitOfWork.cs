using System;
using System.Collections.Generic;
using System.Text;

namespace DocuMind.Application.Abstractions.Persistence
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAysnc(CancellationToken cancellationToken = default);
    }
}
