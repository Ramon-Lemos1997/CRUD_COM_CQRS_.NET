using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace Infra.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserContract> UserContracts { get; set; }

        /// <summary>
        /// Método responsável por configurar o modelo do banco de dados.
        /// </summary>
        /// <param name="builder">Builder para configuração do modelo.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Aplica todas as configurações de entidades do assembly atual.
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Insere dados iniciais na tabela de usuários.
            builder.Entity<User>().HasData(new User("Company Test", "99.999.999/9999-99", "Ramon", "emaiil@company.com") { Id = 1 });

        }
    }
}
