namespace API_bancaria.Models;

public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;

    public List<Conta> Contas { get; set; } = new();
}
