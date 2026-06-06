using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrbitEye.Application.Interfaces;
using OrbitEye.Domain.Entities;

namespace OrbitEye.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AlertasController : ControllerBase
{
    private readonly IAlertaRepository _alertaRepository;

    public AlertasController(IAlertaRepository alertaRepository)
    {
        _alertaRepository = alertaRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var alertas = await _alertaRepository.ListarAsync();
        return Ok(alertas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        var alerta = await _alertaRepository.BuscarPorIdAsync(id);

        if (alerta == null)
            return NotFound();

        return Ok(alerta);
    }

    [HttpPost]
    public async Task<IActionResult> Criar(Alerta alerta)
    {
        var novoAlerta = await _alertaRepository.CriarAsync(alerta);

        return CreatedAtAction(
            nameof(BuscarPorId),
            new { id = novoAlerta.Id },
            novoAlerta);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, Alerta alerta)
    {
        var alertaAtualizado = await _alertaRepository.AtualizarAsync(id, alerta);

        if (alertaAtualizado == null)
            return NotFound();

        return Ok(alertaAtualizado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        var deletado = await _alertaRepository.DeletarAsync(id);

        if (!deletado)
            return NotFound();

        return NoContent();
    }
}