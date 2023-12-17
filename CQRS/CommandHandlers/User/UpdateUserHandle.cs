using CQRS.Commands.User;
using CQRS.Support;
using Domain.Interfaces;
using MediatR;

namespace CQRS.CommandHandlers.User
{
    public class UpdateClientHandle : IRequestHandler<UpdateUserCommand, ICommandResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateClientHandle(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //-------------------------------------------------------------------------------------

        /// <summary>
        /// Manipula a atualização de um usuário/cliente.
        /// </summary>
        /// <param name="request">Comando de atualização do usuário.</param>
        /// <param name="cancellationToken">Token para cancelamento da operação.</param>
        /// <returns>Resultado do comando de atualização.</returns>
        public async Task<ICommandResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {

            var entity = await _unitOfWork.UserRepository.GetById(request.Id, cancellationToken);

            entity.BusinessName = request.BusinessName;
            entity.CnpjNumber = request.CnpjNumber;
            entity.Role = request.Role;
            entity.Email = request.Email;
            entity.WhatsApp = request.WhatsApp;
            entity.UpdatedAt = DateTime.Now;

            if (request.WhatsApp != null)
            {
                entity.WhatsApp = request.WhatsApp;
            }

            int updateTask = await _unitOfWork.SaveChanges();

            if (updateTask == 0)
            {
                return CommandResult.BadRequest("Interno", "Erro ao processar a requisição.");
            }

            return CommandResult.Ok();

        }

        //-------------------------------------------------------------------------------------
    }
}

