using API_bancaria.Data;
using API_bancaria.Models;
using API_bancaria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_bancaria.Repositories;

public class TransacaoRepository : ITransacaoRepository
{
    private readonly AppDbContext _context;

    public TransacaoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CriarAsync(Transacao transacao)
    {
        _context.Transacoes.Add(transacao);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Transacao>> GetByContaIdAsync(int contaId)
    {
        return await _context.Transacoes
            .Where(t => t.ContaId == contaId || t.ContaDestinoId == contaId)
            .OrderByDescending(t => t.Data)
            .ToListAsync();
    }
}