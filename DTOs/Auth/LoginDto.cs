namespace API_bancaria.DTOs.Auth;

public class LoginDto
{
    public string CPF { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}