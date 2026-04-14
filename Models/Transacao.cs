namespace API_bancaria.Models;

// Enum fora da classe
public enum TipoTransacao
{
    Deposito = 1,
    Saque = 2,
    Transferencia = 3
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