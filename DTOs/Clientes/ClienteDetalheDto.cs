namespace API_bancaria.DTOs.Clientes;

public class ClienteDetalheDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;

    public List<ContaDto> Contas { get; set; } = new();
}

public class ContaDto
{
    public int Id { get; set; }
    public string Numero { get; set; } = string.Empty;
    public decimal Saldo { get; set; }
}