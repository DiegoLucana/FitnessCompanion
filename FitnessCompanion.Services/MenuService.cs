using FitnessCompanion.DataAccess;
using FitnessCompanion.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitnessCompanion.Services;

public class MenuService : IMenuService
{
    private readonly FitnessCompanionDbContext _context;
    public MenuService(FitnessCompanionDbContext context)
    {
        this._context = context;
    }
    public async Task<Menu> CreateMenu(Menu menu)
    {
        if (menu == null)
        {
            var c = new Menu()
            {
               Title       = menu.Title,
               Description = menu.Description,
               DesayunoId  = menu.DesayunoId,
               AlmuerzoId  = menu.AlmuerzoId,
               CenaId = menu.CenaId,
                Status = true

            };
            await _context.Menus.AddAsync(c);
            await _context.SaveChangesAsync();

        }
        return menu;
    }

    public async Task DeleteMenu(Menu menu)
    {
        _context.Menus.Remove(menu);
        await _context.SaveChangesAsync();
    }

    public async Task<Menu> GetMenu(int id)
    {
        return await _context.Menus.Where(u => u.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<Menu>> GetMenus()
    {
        return await _context.Menus.ToListAsync();
    }

    public async Task UpdateMenu(Menu menu)
    {
        var m = await _context.Menus.FindAsync(menu.Id);
        m.Title = menu.Title;
        m.Description = menu.Description; 
        _context.Entry(m).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
