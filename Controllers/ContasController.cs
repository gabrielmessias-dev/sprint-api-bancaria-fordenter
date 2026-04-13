using API_bancaria.DTOs.Contas;
using API_bancaria.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ContasController : ControllerBase
{
    private readonly IContaService _service;

    public ContasController(IContaService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CreateContaDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var conta = await _service.CriarContaAsync(dto);

        return StatusCode(201, conta);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var conta = await _service.ObterPorIdAsync(id);
        return Ok(conta);
    }

    [HttpGet("cliente/{clienteId}")]
    public async Task<IActionResult> ObterPorCliente(int clienteId)
    {
        var contas = await _service.ObterPorClienteAsync(clienteId);
        return Ok(contas);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remover(int id)
    {
        await _service.RemoverAsync(id);
        return Ok(new { mensagem = "Conta removida com sucesso" });
    }
}