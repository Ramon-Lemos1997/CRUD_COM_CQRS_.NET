using CQRS.Queries.User;
using Domain.Interfaces;
using MediatR;

namespace CQRS.QueriesHandlers.User
{
    public class UserByIdHandle : IRequestHandler<QueryUserById, Domain.Entities.User.User>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserByIdHandle(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //-------------------------------------------------------------------------

        /// <summary>
        /// Manipula a consulta de usuário por ID.
        /// </summary>
        /// <param name="request">Requisição de consulta de usuário por ID.</param>
        /// <param name="cancellationToken">Token de cancelamento opcional.</param>
        /// <returns>Um usuário específico com base no ID fornecido.</returns>
        public async Task<Domain.Entities.User.User> Handle(QueryUserById request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.UserRepository.GetById(request.Id, cancellationToken);
        }

        //-------------------------------------------------------------------------
    }
}
