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
    private readonly ITransacaoService _transacaoService;

    public TransacoesController(ITransacaoService transacaoService)
    {
        _transacaoService = transacaoService;
    }

    [HttpPost("deposito")]
    public async Task<IActionResult> Deposito([FromBody] CreateTransacaoDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _transacaoService.DepositoAsync(dto);

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

        await _transacaoService.SaqueAsync(dto);

        return Ok(new
        {
            mensagem = "Saque realizado com sucesso"
        });
    }

    [HttpPost("transferencia")]
    public async Task<IActionResult> Transferencia([FromBody] CreateTransacaoDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _transacaoService.TransferenciaAsync(dto);

        return Ok(new
        {
            mensagem = "Transferência realizada com sucesso"
        });
    }
}