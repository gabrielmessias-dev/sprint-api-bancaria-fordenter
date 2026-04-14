using API_bancaria.DTOs.Transacoes;
using Microsoft.AspNetCore.Mvc;
using API_bancaria.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace API_bancaria.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TransacoesController : ControllerBase
{
    private readonly ITransacaoService _service;

    public TransacoesController(ITransacaoService service)
    {
        _service = service;
    }

    [HttpPost("deposito")]
    public async Task<IActionResult> Deposito([FromBody] CreateTransacaoDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _service.DepositoAsync(dto);

        return Ok(new
        {
            mensagem = "Depósito realizado com sucesso"
        });
    }

    [HttpPost("saque")]
    public async Task<IActionResult> Saque([FromBody] CreateTransacaoDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _service.SaqueAsync(dto);

        return Ok(new
        {
            mensagem = "Saque realizado com sucesso"
        });
    }
}