using FitnessCompanion.Entities;

namespace FitnessCompanion.Services;

public interface ICenaService
{
    Task<Cena> CreateCena(Cena cena);
    Task DeleteCena(Cena cena);
    Task<Cena> GetCena(int id);
    Task<List<Cena>> GetCenas();
    Task UpdateCena(Cena cena);
}
