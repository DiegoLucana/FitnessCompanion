using FitnessCompanion.Entities;

namespace FitnessCompanion.Services;

public interface IEjercicioService
{
    Task<Ejercicio> CreateEjercicio(Ejercicio ejercicio);
    Task DeleteEjercicio(Ejercicio ejercicio);
    Task<Ejercicio> GetEjercicio(int id);
    Task<List<Ejercicio>> GetEjercicios();
    Task UpdateEjercicio(Ejercicio ejercicio);
}
