using API_bancaria.Models;
using Microsoft.EntityFrameworkCore;

namespace API_bancaria.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Conta> Contas => Set<Conta>();
    public DbSet<Transacao> Transacoes => Set<Transacao>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // CPF único
        modelBuilder.Entity<Cliente>()
            .HasIndex(c => c.CPF)
            .IsUnique();
    }
}
