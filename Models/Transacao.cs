namespace API_bancaria.Models;

// Enum fora da classe
public enum TipoTransacao
{
    Deposito,
    Saque,
    Transferencia
}

public class Transacao
{
    public int Id { get; set; }

    public TipoTransacao Tipo { get; set; }

    public decimal Valor { get; set; }
    public DateTime Data { get; set; } = DateTime.UtcNow;

    public int ContaId { get; set; }
    public Conta Conta { get; set; } = null!;
}