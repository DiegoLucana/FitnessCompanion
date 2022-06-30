using FitnessCompanion.Entities;

namespace FitnessCompanion.Services;

public interface IAlmuerzoService
{
    Task<Almuerzo> CreateAlmuerzo(Almuerzo almuerzo);
    Task DeleteAlmuerzo(Almuerzo almuerzo);
    Task<Almuerzo> GetAlmuerzo(int id);
    Task<List<Almuerzo>> GetAlmuerzos();
    Task UpdateAlmuerzo(Almuerzo almuerzo);
}
