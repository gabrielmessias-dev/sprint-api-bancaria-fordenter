namespace API_bancaria.Models;

public class Conta
{
    public int Id { get; set; }
    public string Numero { get; set; } = DateTime.UtcNow.Ticks.ToString();
    public decimal Saldo { get; set; } = 0;

    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; } = null!;

    public List<Transacao> Transacoes { get; set; } = new();
}
