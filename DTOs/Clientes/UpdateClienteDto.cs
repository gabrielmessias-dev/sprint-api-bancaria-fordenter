using System.ComponentModel.DataAnnotations;

namespace API_bancaria.DTOs.Clientes;

public class UpdateClienteDto
{
    [Required]
    public string Nome { get; set; } = string.Empty;
}
