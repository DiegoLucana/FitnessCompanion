using FitnessCompanion.Entities;
using FitnessCompanion.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCompanion.API.Controller;

[ApiController]
[Route("api/[Controller]")]
public class DesayunoController:ControllerBase
{
    private readonly IDesayunoService _desayunoService;

    public DesayunoController(IDesayunoService desayunoService)
    {
        this._desayunoService = desayunoService;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Desayuno>>> Get()
    {
        return await _desayunoService.GetDesayunos();
    }
    [HttpGet("{id}", Name = "GetDesayuno")]
    public async Task<ActionResult<Desayuno>> Get(int id)
    {
        var desayuno = await _desayunoService.GetDesayuno(id);
        if (desayuno == null)
        {
            return NotFound();
        }
        return Ok(desayuno);
    }
    [HttpPost]
    public async Task<ActionResult<Desayuno>> Post(Desayuno desayuno)
    {
        await _desayunoService.CreateDesayuno(desayuno);
        return CreatedAtRoute("GetDesayuno", new { id = desayuno.Id }, desayuno);
    }
    [HttpDelete]
    public async Task<ActionResult> Delete(int id)
    {
        var desayuno = await _desayunoService.GetDesayuno(id);
        if (desayuno == null)
        {
            return NotFound();
        }
        await _desayunoService.DeleteDesayuno(desayuno);
        return NoContent();
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, Desayuno Desayuno)
    {
        if (id != Desayuno.Id)
        {
            return BadRequest();
        }
        await _desayunoService.UpdateDesayuno(Desayuno);
        return NoContent();
    }
}
