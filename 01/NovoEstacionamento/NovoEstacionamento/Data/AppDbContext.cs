using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore;
using NovoEstacionamento.Models;

namespace NovoEstacionamento.Data
{

    internal class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext>  opt) : base (opt) 
        {

        }
            public DbSet<Cliente> Clientes { get; set; }
            public DbSet<Vaga> Vagas { get; set; }
            public DbSet<Veiculo> Veiculos { get; set; }
            public DbSet<Servico> Servicos { get; set; }
        
    }
}
