using System.ComponentModel.DataAnnotations;

namespace API_bancaria.DTOs.Transacoes;

public class CreateTransacaoDto
{
    [Required]
    public int ContaId { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal Valor { get; set; }
}
