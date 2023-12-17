

namespace Domain.Entities.User
{
    public class User : BaseEntity
    {
        public User()
        {

        }

        public User(string businessName, string cnpjNumber, string role, string email)
        {
            if (string.IsNullOrEmpty(businessName))
            {
                throw new ArgumentNullException(nameof(businessName), "O nome da empresa não pode ser nulo ou vazio.");
            }

            if (string.IsNullOrEmpty(cnpjNumber))
            {
                throw new ArgumentNullException(nameof(cnpjNumber), "O número do CNPJ não pode ser nulo ou vazio.");
            }

            if (string.IsNullOrEmpty(role))
            {
                throw new ArgumentNullException(nameof(role), "O cargo não pode ser nulo ou vazio.");
            }

            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email), "O email não pode ser nulo ou vazio.");
            }

            BusinessName = businessName;
            CnpjNumber = cnpjNumber;
            Role = role;
            Email = email;
            CreatedAt = DateTime.Now;
        }

        public string BusinessName { get; set; }
        public string CnpjNumber { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string? WhatsApp { get; set; }

        // Propriedade de navegação
        public virtual ICollection<UserContract> UserContracts { get; set; }
    }
}
