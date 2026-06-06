using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrbitEye.Application.Interfaces;
using OrbitEye.Domain.Entities;

namespace OrbitEye.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuariosController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var usuarios = await _usuarioRepository.ListarAsync();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        var usuario = await _usuarioRepository.BuscarPorIdAsync(id);

        if (usuario == null)
            return NotFound();

        return Ok(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> Criar(Usuario usuario)
    {
        var novoUsuario = await _usuarioRepository.CriarAsync(usuario);

        return CreatedAtAction(
            nameof(BuscarPorId),
            new { id = novoUsuario.Id },
            novoUsuario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, Usuario usuario)
    {
        var usuarioAtualizado =
            await _usuarioRepository.AtualizarAsync(id, usuario);

        if (usuarioAtualizado == null)
            return NotFound();

        return Ok(usuarioAtualizado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        var deletado =
            await _usuarioRepository.DeletarAsync(id);

        if (!deletado)
            return NotFound();

        return NoContent();
    }
}