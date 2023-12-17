using Domain.Interfaces;
using MediatR;

namespace CQRS.Commands.User
{
    public class UpdateUserCommand : IRequest<ICommandResult>
    {
        public UpdateUserCommand(int id, string businessName, string cnpjNumber, string role, string email, string? whatsapp)
        {
            Id = id;
            BusinessName = businessName;
            CnpjNumber = cnpjNumber;
            Role = role;
            Email = email;
            WhatsApp = whatsapp;
        }

        public int Id { get; set; }
        public string BusinessName { get; set; }
        public string CnpjNumber { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string? WhatsApp { get; set; }
    }
}
