using Microsoft.EntityFrameworkCore;
using Prova.Api.Models;

namespace Prova.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Produto> Produtos => Set<Produto>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Imovel> Imoveis => Set<Imovel>();
        public DbSet<Contrato> Contratos => Set<Contrato>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .HasIndex(p => p.SKU)
                .IsUnique();

            modelBuilder.Entity<Contrato>()
                .HasOne(c => c.Cliente)
                .WithMany()
                .HasForeignKey(c => c.ClienteId);

            modelBuilder.Entity<Contrato>()
                .HasOne(c => c.Imovel)
                .WithMany()
                .HasForeignKey(c => c.ImovelId);
        }
    }
}
