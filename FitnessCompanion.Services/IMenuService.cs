using FitnessCompanion.Entities;

namespace FitnessCompanion.Services;

public interface IMenuService
{
    Task<Menu> CreateMenu(Menu menu);
    Task<Menu> GetMenu(int id);
    Task<List<Menu>> GetMenus();
    Task DeleteMenu(Menu menu);
    Task UpdateMenu(Menu menu);
}
