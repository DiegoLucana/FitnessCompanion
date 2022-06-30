using FitnessCompanion.DataAccess;
using FitnessCompanion.Dto.Request;
using FitnessCompanion.Dto.Response;
using FitnessCompanion.Entities;
using FitnessCompanion.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessCompanion.API.Controller;

[ApiController]
[Route("api/[Controller]")]
public class EjercicioController : ControllerBase
{
    private readonly IEjercicioService _ejercicioService;

    public EjercicioController(IEjercicioService ejercicioService)
    {
        this._ejercicioService = ejercicioService;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ejercicio>>> Get()
    {
        return await _ejercicioService.GetEjercicios();
    }
    [HttpGet("{id}", Name = "GetEjercicio")]
    public async Task<ActionResult<Ejercicio>> Get(int id)
    {
        var ejercicio = await _ejercicioService.GetEjercicio(id);
        if (ejercicio == null)
        {
            return NotFound();
        }
        return Ok(ejercicio);
    }
    [HttpPost]
    public async Task<ActionResult<Ejercicio>> Post(Ejercicio ejercicio)
    {
        await _ejercicioService.CreateEjercicio(ejercicio);
        return CreatedAtRoute("GetEjercicio", new { id = ejercicio.Id }, ejercicio);
    }
    [HttpDelete]
    public async Task<ActionResult>Delete(int id)
    {
        var ejercicio = await _ejercicioService.GetEjercicio(id);
        if(ejercicio==null)
        {
            return NotFound();
        }
        await _ejercicioService.DeleteEjercicio(ejercicio);
        return NoContent();
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, Ejercicio ejercicio)
    {
        if(id!=ejercicio.Id)
        {
            return BadRequest();
        }
        await _ejercicioService.UpdateEjercicio(ejercicio);
        return NoContent();
    }

}    