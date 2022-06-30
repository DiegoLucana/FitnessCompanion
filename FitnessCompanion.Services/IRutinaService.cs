using FitnessCompanion.Entities;

namespace FitnessCompanion.Services;

public interface IRutinaService
{
    Task<Rutina> CreateRutina(Rutina rutina);
    Task<Rutina> GetRutina(int id);
    Task<List<Rutina>> GetRutinas();
    Task DeleteRutina(Rutina rutina);
    Task UpdateRutina(Rutina rutina);
}
