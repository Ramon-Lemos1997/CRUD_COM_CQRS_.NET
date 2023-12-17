using CQRS.Commands.User;
using CQRS.Support;
using Domain.Interfaces;
using MediatR;

namespace CQRS.CommandHandlers.User
{
    public class DeleteUserHandle : IRequestHandler<DeleteUserCommand, ICommandResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteUserHandle(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //-----------------------------------------------------------------------------------------------

        /// <summary>
        /// Manipula a exclusão de um usuário.
        /// </summary>
        /// <param name="request">Comando de exclusão do usuário.</param>
        /// <param name="cancellationToken">Token para cancelamento da operação.</param>
        /// <returns>Resultado do comando de exclusão.</returns>
        public async Task<ICommandResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.UserRepository.GetById(request.Id, cancellationToken);

            await _unitOfWork.UserRepository.Delete(entity);

            int deleteTask = await _unitOfWork.SaveChanges();

            if (deleteTask == 0)
            {
                return CommandResult.BadRequest("Interno", "Erro ao processar a requisição.");
            }

            return CommandResult.Ok();
        }
        //-----------------------------------------------------------------------------------------------
    }
}
