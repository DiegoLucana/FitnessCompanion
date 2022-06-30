using FitnessCompanion.Entities;
using FitnessCompanion.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCompanion.API.Controller;
[ApiController]
[Route("api/[Controller]")]

public class MenuController:ControllerBase
{
    private readonly IMenuService _menuService;
    public MenuController(IMenuService menuService)
    {
        this._menuService = menuService;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Menu>>> Get()
    {
        return await _menuService.GetMenus();
    }
    [HttpGet("{id}", Name = "GetMenu")]
    public async Task<ActionResult<Menu>> Get(int id)
    {
        var menu = await _menuService.GetMenu(id);
        if (menu == null)
        {
            return NotFound();
        }
        return Ok(menu);
    }
    [HttpPost]
    public async Task<ActionResult<Menu>> Post(Menu menu)
    {
        await _menuService.CreateMenu(menu);
        return CreatedAtRoute("GetMenu", new { id = menu.Id }, menu);
    }
    [HttpDelete]
    public async Task<ActionResult> Delete(int id)
    {
        var menu = await _menuService.GetMenu(id);
        if (menu == null)
        {
            return NotFound();
        }
        await _menuService.DeleteMenu(menu);
        return NoContent();
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, Menu menu)
    {
        if (id != menu.Id)
        {
            return BadRequest();
        }
        await _menuService.UpdateMenu(menu);
        return NoContent();
    }
}
