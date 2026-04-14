using System.ComponentModel.DataAnnotations;

namespace API_bancaria.DTOs.Transacoes;

public class CreateTransacaoDto
{
    public decimal Valor { get; set; }

    public TipoTransacao Tipo { get; set; }

    public int ContaId { get; set; }

    public int? ContaDestinoId { get; set; }
}
