using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrbitEye.Application.Interfaces;
using OrbitEye.Domain.Entities;

namespace OrbitEye.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EventosClimaticosController : ControllerBase
{
    private readonly IEventoClimaticoRepository _repository;

    public EventosClimaticosController(IEventoClimaticoRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        return Ok(await _repository.ListarAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        var evento = await _repository.BuscarPorIdAsync(id);

        if (evento == null)
            return NotFound();

        return Ok(evento);
    }

    [HttpPost]
    public async Task<IActionResult> Criar(EventoClimatico evento)
    {
        var novoEvento = await _repository.CriarAsync(evento);

        return CreatedAtAction(
            nameof(BuscarPorId),
            new { id = novoEvento.Id },
            novoEvento);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, EventoClimatico evento)
    {
        var eventoAtualizado = await _repository.AtualizarAsync(id, evento);

        if (eventoAtualizado == null)
            return NotFound();

        return Ok(eventoAtualizado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        var deletado = await _repository.DeletarAsync(id);

        if (!deletado)
            return NotFound();

        return NoContent();
    }
}