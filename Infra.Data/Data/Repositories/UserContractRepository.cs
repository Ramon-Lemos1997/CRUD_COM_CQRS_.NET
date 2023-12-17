using Domain.Entities.User;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Data.Repositories
{
    public class UserContractRepository : Repository<UserContract>, IUserContractRepository
    {
        public UserContractRepository(ApplicationDbContext context)
            : base(context)
        { }

        /// <summary>
        /// Obtém uma lista de contratos de usuário por ID de usuário.
        /// </summary>
        /// <param name="userId">ID do usuário para filtrar contratos.</param>
        /// <param name="cancellationToken">Token de cancelamento opcional.</param>
        /// <returns>Lista de contratos de usuário correspondentes ao ID do usuário.</returns>
        public async Task<List<UserContract>> GetContractsByUserId(int userId, CancellationToken cancellationToken)
            => await _context.UserContracts.Where(x => x.UserId == userId).ToListAsync(cancellationToken);
    }
}
