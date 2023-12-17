using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.User;

namespace Infra.Data.Data.Configuration
{
    public class ClientContractConfiguration : IEntityTypeConfiguration<UserContract>
    {
        public void Configure(EntityTypeBuilder<UserContract> builder)
        {
            builder.ToTable("ClientContracts");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.ContractNumber)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.TotalContractValue)
                 .HasColumnType("decimal(18,2)");

            builder.Property(c => c.ContractStart)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(c => c.ContractEnd)
                .IsRequired()
                .HasColumnType("datetime");
        }
    }
}
