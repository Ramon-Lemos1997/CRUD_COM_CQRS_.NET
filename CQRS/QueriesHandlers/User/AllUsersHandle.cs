using CQRS.Queries.User;
using Domain.Interfaces;
using MediatR;

namespace CQRS.QueriesHandlers.User
{
    public class AllUserHandle : IRequestHandler<QueryAllUser, IEnumerable<Domain.Entities.User.User>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AllUserHandle(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //------------------------------------------------------------------

        /// <summary>
        /// Manipula a consulta de todos os usuários.
        /// </summary>
        /// <param name="request">Requisição de consulta de todos os usuários.</param>
        /// <param name="cancellationToken">Token de cancelamento opcional.</param>
        /// <returns>Uma coleção de usuários.</returns>
        public async Task<IEnumerable<Domain.Entities.User.User>> Handle(QueryAllUser request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.UserRepository.ListAll(cancellationToken);
        }

        //-----------------------------------------------------------
    }
}
