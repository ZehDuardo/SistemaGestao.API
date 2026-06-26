using Microsoft.EntityFrameworkCore;
using SistemaGestao.API.Models;

namespace SistemaGestao.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Veiculo> Veiculos { get; set; } = null!;
        public DbSet<Cliente> Clientes { get; set; } = null!;
        public DbSet<Ocupacao> Ocupacoes { get; set; } = null!;
    }
}