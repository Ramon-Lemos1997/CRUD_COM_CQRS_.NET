
using System.ComponentModel.DataAnnotations;


namespace Domain.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [Required(ErrorMessage = "O campo 'Nome da Empresa' é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo 'Nome da Empresa' deve ter no máximo 100 caracteres.")]
        [Display(Name = "Nome da empresa")]
        public string BusinessName { get; set; }

        [Required(ErrorMessage = "O campo 'CNPJ' é obrigatório.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O campo 'CNPJ' deve ter 14 caracteres.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "O campo 'CNPJ' deve conter somente números.")]
        [Display(Name = "CNPJ")]
        public string CnpjNumber { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo 'Cargo' deve ter no máximo 100 caracteres.")]
        [Display(Name = "Cargo")]
        public string Role { get; set; }

        [Required(ErrorMessage = "O campo 'E-mail' é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo 'E-mail' deve ser um endereço de e-mail válido.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string? WhatsApp { get; set; }
    }
}
