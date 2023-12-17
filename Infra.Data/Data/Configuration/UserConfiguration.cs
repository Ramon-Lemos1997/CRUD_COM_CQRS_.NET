using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infra.Data.Data.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Clients");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.BusinessName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.CnpjNumber)
                .IsRequired()
                .HasMaxLength(255);


            builder.Property(c => c.Role)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.WhatsApp)
                .HasMaxLength(255);

            // Configuração de relacionamento
            builder.HasMany(c => c.UserContracts)
             .WithOne(cp => cp.User)
             .HasForeignKey(cp => cp.UserId);
            ;
        }
    }
}
