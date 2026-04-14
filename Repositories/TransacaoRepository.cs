using API_bancaria.Data;
using API_bancaria.Models;
using API_bancaria.Repositories.Interfaces;

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
}