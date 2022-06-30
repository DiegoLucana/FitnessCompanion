using FitnessCompanion.Entities;
using FitnessCompanion.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCompanion.API.Controller;

[ApiController]
[Route("api/[Controller]")]

public class UsuarioController: ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    public UsuarioController(IUsuarioService usuarioService)
    {
        this._usuarioService = usuarioService;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usuario>>> Get()
    {
        return await _usuarioService.GetUsuarios();
    }
    [HttpGet("{id}", Name = "GetUsuario")]
    public async Task<ActionResult<Usuario>> Get(int id)
    {
        var usuario = await _usuarioService.GetUsuario(id);
        if (usuario == null)
        {
            return NotFound();
        }
        return Ok(usuario);
    }
    [HttpPost]
    public async Task<ActionResult<Usuario>> Post(Usuario usuario)
    {
        await _usuarioService.CreateUsuario(usuario);
        return CreatedAtRoute("GetUsuario", new { id = usuario.Id }, usuario);
    }
    [HttpDelete]
    public async Task<ActionResult> Delete(int id)
    {
        var usuario = await _usuarioService.GetUsuario(id);
        if (usuario == null)
        {
            return NotFound();
        }
        await _usuarioService.DeleteUsuario(usuario);
        return NoContent();
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, Usuario usuario)
    {
        if (id != usuario.Id)
        {
            return BadRequest();
        }
        await _usuarioService.UpdateUsuario(usuario);
        return NoContent();
    }

}
