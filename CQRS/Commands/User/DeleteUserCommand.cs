using Domain.Interfaces;
using MediatR;

namespace CQRS.Commands.User
{
    public class DeleteUserCommand : IRequest<ICommandResult>
    {
        public DeleteUserCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
