using API_bancaria.DTOs.Clientes;
using API_bancaria.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly IClienteService _service;

    public ClientesController(IClienteService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CreateClienteDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var cliente = await _service.CriarClienteAsync(dto);

        return CreatedAtAction(nameof(ObterPorId), new { id = cliente.Id }, cliente);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var cliente = await _service.ObterPorIdAsync(id);
        return Ok(cliente);
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        var clientes = await _service.ObterTodosAsync();
        return Ok(clientes);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] UpdateClienteDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _service.AtualizarAsync(id, dto);
        return Ok(new { mensagem = "Cliente atualizado com sucesso" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remover(int id)
    {
        await _service.RemoverAsync(id);
        return Ok(new { mensagem = "Cliente removido com sucesso" });
    }


}