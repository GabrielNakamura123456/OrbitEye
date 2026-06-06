using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrbitEye.Application.Interfaces;
using OrbitEye.Domain.Entities;

namespace OrbitEye.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PrevisoesIAController : ControllerBase
{
    private readonly IPrevisaoIARepository _repository;

    public PrevisoesIAController(IPrevisaoIARepository repository)
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
        var previsao = await _repository.BuscarPorIdAsync(id);

        if (previsao == null)
            return NotFound();

        return Ok(previsao);
    }

    [HttpPost]
    public async Task<IActionResult> Criar(PrevisaoIA previsao)
    {
        var novaPrevisao = await _repository.CriarAsync(previsao);

        return CreatedAtAction(
            nameof(BuscarPorId),
            new { id = novaPrevisao.Id },
            novaPrevisao);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, PrevisaoIA previsao)
    {
        var previsaoAtualizada = await _repository.AtualizarAsync(id, previsao);

        if (previsaoAtualizada == null)
            return NotFound();

        return Ok(previsaoAtualizada);
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