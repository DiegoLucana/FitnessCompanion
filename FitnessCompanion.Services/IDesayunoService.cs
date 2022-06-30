using FitnessCompanion.Entities;

namespace FitnessCompanion.Services;

public interface IDesayunoService
{
    Task<Desayuno> CreateDesayuno(Desayuno desayuno);
    Task DeleteDesayuno(Desayuno desayuno);
    Task<Desayuno> GetDesayuno(int id);
    Task<List<Desayuno>> GetDesayunos();
    Task UpdateDesayuno(Desayuno desayuno);
}
