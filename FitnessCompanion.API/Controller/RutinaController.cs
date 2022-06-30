using FitnessCompanion.Entities;
using FitnessCompanion.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCompanion.API.Controller;
[ApiController]
[Route("api/[Controller]")]
public class RutinaController:ControllerBase
{
    private readonly IRutinaService _rutinaService;
    public RutinaController(IRutinaService rutinaService)
    {
        this._rutinaService = rutinaService;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Rutina>>> Get()
    {
        return await _rutinaService.GetRutinas();
    }
    [HttpGet("{id}", Name = "GetRutina")]
    public async Task<ActionResult<Rutina>> Get(int id)
    {
        var rutina = await _rutinaService.GetRutina(id);
        if (rutina == null)
        {
            return NotFound();
        }
        return Ok(rutina);
    }
    [HttpPost]
    public async Task<ActionResult<Rutina>> Post(Rutina rutina)
    {
        await _rutinaService.CreateRutina(rutina);
        return CreatedAtRoute("GetRutina", new { id = rutina.Id }, rutina);
    }
    [HttpDelete]
    public async Task<ActionResult> Delete(int id)
    {
        var rutina = await _rutinaService.GetRutina(id);
        if (rutina == null)
        {
            return NotFound();
        }
        await _rutinaService.DeleteRutina(rutina);
        return NoContent();
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, Rutina rutina)
    {
        if (id != rutina.Id)
        {
            return BadRequest();
        }
        await _rutinaService.UpdateRutina(rutina);
        return NoContent();
    }

}
