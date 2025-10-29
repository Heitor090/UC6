using Microsoft.EntityFrameworkCore;
using VeiculoConsoleApp.Models;

namespace VeiculoConsoleApp.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Veiculos> Veiculo { get; set;}


}
