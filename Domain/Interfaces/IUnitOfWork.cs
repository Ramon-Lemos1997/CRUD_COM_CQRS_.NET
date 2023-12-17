

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IUserContractRepository UserContractRepository { get; }
        Task<int> SaveChanges();
        Task BeginTransaction();
        Task Commit();
        Task Rollback();
    }
}
