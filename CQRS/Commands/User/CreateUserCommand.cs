using Domain.Interfaces;
using MediatR;

namespace CQRS.Commands.User
{
    public class CreateUserCommand : IRequest<ICommandResult>
    {
        public CreateUserCommand(string businessName, string cnpjNumber, string role, string email, string whatsapp)
        {
            BusinessName = businessName;
            CnpjNumber = cnpjNumber;
            Role = role;
            Email = email;
            WhatsApp = whatsapp;
        }

        public string BusinessName { get; set; }
        public string CnpjNumber { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string? WhatsApp { get; set; }
    }
}