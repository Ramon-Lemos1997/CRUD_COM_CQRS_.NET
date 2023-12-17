
namespace Domain.Entities.User
{
    public class UserContract : BaseEntity
    {
        public UserContract()
        {

        }

        public UserContract(int userId, string contractNumber, decimal totalContractValue, DateTime contractStart, DateTime contractEnd)
        {
            if (userId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(userId), "O ID do usuário deve ser maior que zero.");
            }

            if (string.IsNullOrEmpty(contractNumber))
            {
                throw new ArgumentNullException(nameof(contractNumber), "O número do contrato não pode estar vazio ou nulo.");
            }

            if (totalContractValue <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(totalContractValue), "O valor total do contrato deve ser maior que zero.");
            }

            if (contractStart <= DateTime.MinValue || contractStart >= DateTime.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(contractStart), "A data de início do contrato está fora do intervalo válido.");
            }

            if (contractEnd <= DateTime.MinValue || contractEnd >= DateTime.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(contractEnd), "A data de término do contrato está fora do intervalo válido.");
            }

            if (contractStart >= contractEnd)
            {
                throw new ArgumentException($"A data de início: {contractStart.ToShortDateString()} deve ser anterior à data de término: {contractEnd.ToShortDateString()}");
            }

            UserId = userId;
            ContractNumber = contractNumber;
            TotalContractValue = totalContractValue;
            ContractStart = contractStart;
            ContractEnd = contractEnd;
            CreatedAt = DateTime.Now;
        }

        public string ContractNumber { get; set; }
        public decimal TotalContractValue { get; set; }
        public DateTime ContractStart { get; set; }
        public DateTime ContractEnd { get; set; }

        // Propriedades de navegação
        public virtual int UserId { get; set; }
        public virtual User User { get; set; }


        public (bool, string) ValidateContractDates()
        {
            if (ContractStart >= ContractEnd)
            {
                return (false, $"A data de início: {ContractStart.ToShortDateString()} deve ser anterior à data de término: {ContractEnd.ToShortDateString()}");
            }

            return (true, string.Empty);
        }
    }

}
