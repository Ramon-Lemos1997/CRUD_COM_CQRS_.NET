using CQRS.Commands.User;
using CQRS.Support;
using Domain.Interfaces;
using MediatR;

namespace CQRS.CommandHandlers.User
{
    public class CreateUserHandle : IRequestHandler<CreateUserCommand, ICommandResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserHandle(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //--------------------------------------------------------------------------------------


        /// <summary>
        /// Manipula a criação de um novo usuário.
        /// </summary>
        /// <param name="request">Comando para criar um novo usuário.</param>
        /// <param name="cancellationToken">Token de cancelamento opcional.</param>
        /// <returns>Um resultado de comando indicando o sucesso da criação.</returns>
        public async Task<ICommandResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.User.User(businessName: request.BusinessName, cnpjNumber: request.CnpjNumber, role: request.Role, email: request.Email)
            { };

            if (request.WhatsApp != null)
            {
                entity.WhatsApp = request.WhatsApp;
            }

            await _unitOfWork.UserRepository.Add(entity, cancellationToken);
            int createTask = await _unitOfWork.SaveChanges();

            if (createTask == 0)
            {
                return CommandResult.BadRequest("Interno", "Erro ao processar a requisição.");
            }

            return CommandResult.Ok(new { entity });
        }




        //--------------------------------------------------------------------------------------
    }
}
