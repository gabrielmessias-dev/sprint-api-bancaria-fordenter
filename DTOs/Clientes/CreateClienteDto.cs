using System.ComponentModel.DataAnnotations;

namespace API_bancaria.DTOs.Clientes;

public class CreateClienteDto
{
    [Required]
    [MinLength(3)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [MinLength(11)]
    [MaxLength(11)]
    public string CPF { get; set; } = string.Empty;

    [Required]
    [MinLength(6)]
    public string Senha { get; set; } = string.Empty;
}
