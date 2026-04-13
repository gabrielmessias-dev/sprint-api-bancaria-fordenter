using API_bancaria.Data;
using API_bancaria.Models;
using API_bancaria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_bancaria.Repositories;

public class ContaRepository : IContaRepository
{
    private readonly AppDbContext _context;

    public ContaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Conta> CriarAsync(Conta conta)
    {
        _context.Contas.Add(conta);
        await _context.SaveChangesAsync();
        return conta;
    }

    public async Task<Conta?> ObterPorIdAsync(int id)
    {
        return await _context.Contas
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Conta>> ObterPorClienteAsync(int clienteId)
    {
        return await _context.Contas
            .Where(c => c.ClienteId == clienteId)
            .ToListAsync();
    }

    public async Task RemoverAsync(Conta conta)
    {
        _context.Contas.Remove(conta);
        await _context.SaveChangesAsync();
    }
}
