﻿namespace Exam.Application.Services.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        Task BeginTransactionAsync();

        Task CommitAsync();

        Task RollbackAsync();
    }
}
