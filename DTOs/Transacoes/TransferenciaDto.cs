namespace API_bancaria.DTOs.Transacoes;

public class TransferenciaDto
{
    public decimal Valor { get; set; }
    public int ContaId { get; set; }
    public int ContaDestinoId { get; set; }
}