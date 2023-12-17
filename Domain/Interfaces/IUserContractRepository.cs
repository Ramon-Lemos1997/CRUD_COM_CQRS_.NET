using Domain.Entities.User;

namespace Domain.Interfaces
{
    public interface IUserContractRepository : IRepository<UserContract>
    {
        Task<List<UserContract>> GetContractsByUserId(int userId, CancellationToken cancellationToken);
    }
}
