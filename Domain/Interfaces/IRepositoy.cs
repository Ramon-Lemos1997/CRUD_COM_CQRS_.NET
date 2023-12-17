﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetById(int id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> ListAll(CancellationToken cancellationToken = default);
        Task<T> Add(T entity, CancellationToken cancellationToken = default);
        Task Update(T entity, CancellationToken cancellationToken = default);
        Task Delete(T entity, CancellationToken cancellationToken = default);
        Task<IDbContextTransaction> BeginTransaction(CancellationToken cancellationToken = default);
    }

}
