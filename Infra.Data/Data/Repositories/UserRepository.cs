using Domain.Entities.User;
using Domain.Interfaces;

namespace Infra.Data.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        { }
    }
}
