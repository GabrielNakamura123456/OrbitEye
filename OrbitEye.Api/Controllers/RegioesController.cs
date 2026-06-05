using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrbitEye.Application.Interfaces;
using OrbitEye.Domain.Entities;

namespace OrbitEye.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class RegioesController : ControllerBase
{
    private readonly IRegiaoRepository _regiaoRepository;

    public RegioesController(IRegiaoRepository regiaoRepository)
    {
        _regiaoRepository = regiaoRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var regioes = await _regiaoRepository.ListarAsync();
        return Ok(regioes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        var regiao = await _regiaoRepository.BuscarPorIdAsync(id);

        if (regiao == null)
            return NotFound();

        return Ok(regiao);
    }

    [HttpPost]
    public async Task<IActionResult> Criar(Regiao regiao)
    {
        var novaRegiao = await _regiaoRepository.CriarAsync(regiao);

        return CreatedAtAction(
            nameof(BuscarPorId),
            new { id = novaRegiao.Id },
            novaRegiao);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, Regiao regiao)
    {
        var regiaoAtualizada =
            await _regiaoRepository.AtualizarAsync(id, regiao);

        if (regiaoAtualizada == null)
            return NotFound();

        return Ok(regiaoAtualizada);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        var deletado = await _regiaoRepository.DeletarAsync(id);

        if (!deletado)
            return NotFound();

        return NoContent();
    }
}