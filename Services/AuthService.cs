using API_bancaria.DTOs.Auth;
using API_bancaria.Repositories.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class AuthService
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IConfiguration _configuration;

    public AuthService(IClienteRepository clienteRepository, IConfiguration configuration)
    {
        _clienteRepository = clienteRepository;
        _configuration = configuration;
    }

    public async Task<string> Login(LoginDto dto)
    {
        var cliente = await _clienteRepository.ObterPorCpfAsync(dto.CPF);

        if (cliente == null || cliente.Senha != dto.Senha)
            throw new Exception("CPF ou senha inválidos");

        var tokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, cliente.Id.ToString()),
                new Claim(ClaimTypes.Name, cliente.Nome)
            }),
            Expires = DateTime.UtcNow.AddHours(2),

            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"],

            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}