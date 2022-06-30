using FitnessCompanion.Entities;
using FitnessCompanion.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessCompanion.API.Controller;
[ApiController]
[Route("api/[Controller]")]

public class CenaController:ControllerBase
{
    private readonly ICenaService _cenaService;

    public CenaController(ICenaService cenaService)
    {
        this._cenaService = cenaService;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cena>>> Get()
    {
        return await _cenaService.GetCenas();
    }
    [HttpGet("{id}", Name = "GetCena")]
    public async Task<ActionResult<Cena>> Get(int id)
    {
        var cena = await _cenaService.GetCena(id);
        if (cena == null)
        {
            return NotFound();
        }
        return Ok(cena);
    }
    [HttpPost]
    public async Task<ActionResult<Cena>> Post(Cena cena)
    {
        await _cenaService.CreateCena(cena);
        return CreatedAtRoute("GetCena", new { id = cena.Id }, cena);
    }
    [HttpDelete]
    public async Task<ActionResult> Delete(int id)
    {
        var cena = await _cenaService.GetCena(id);
        if (cena == null)
        {
            return NotFound();
        }
        await _cenaService.DeleteCena(cena);
        return NoContent();
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, Cena cena)
    {
        if (id != cena.Id)
        {
            return BadRequest();
        }
        await _cenaService.UpdateCena(cena);
        return NoContent();
    }
}
