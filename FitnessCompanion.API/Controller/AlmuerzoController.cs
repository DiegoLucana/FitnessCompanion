using FitnessCompanion.Entities;
using FitnessCompanion.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCompanion.API.Controller;
[ApiController]
[Route("api/[Controller]")]

public class AlmuerzoController: ControllerBase
{
    private readonly IAlmuerzoService _almuerzoService;

    public AlmuerzoController(IAlmuerzoService _almuerzoService)
    {
        this._almuerzoService = _almuerzoService;  
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Almuerzo>>> Get()
    {
        return await _almuerzoService.GetAlmuerzos();
    }
    [HttpGet("{id}", Name = "GetAlmuerzo")]
    public async Task<ActionResult<Almuerzo>> Get(int id)
    {
        var almuerzo = await _almuerzoService.GetAlmuerzo(id);
        if (almuerzo == null)
        {
            return NotFound();
        }
        return Ok(almuerzo);
    }
    [HttpPost]
    public async Task<ActionResult<Almuerzo>> Post(Almuerzo almuerzo)
    {
        await _almuerzoService.CreateAlmuerzo(almuerzo);
        return CreatedAtRoute("Getalmuerzo", new { id = almuerzo.Id }, almuerzo);
    }
    [HttpDelete]
    public async Task<ActionResult> Delete(int id)
    {
        var almuerzo = await _almuerzoService.GetAlmuerzo(id);
        if (almuerzo == null)
        {
            return NotFound();
        }
        await _almuerzoService.DeleteAlmuerzo(almuerzo);
        return NoContent();
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, Almuerzo almuerzo)
    {
        if (id != almuerzo.Id)
        {
            return BadRequest();
        }
        await _almuerzoService.UpdateAlmuerzo(almuerzo);
        return NoContent();
    }
}
