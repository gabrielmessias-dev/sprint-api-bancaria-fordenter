using System.ComponentModel.DataAnnotations;

namespace API_bancaria.DTOs.Contas;

public class CreateContaDto
{
    [Required]
    public int ClienteId { get; set; }
}
