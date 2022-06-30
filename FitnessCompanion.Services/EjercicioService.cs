using FitnessCompanion.DataAccess;
using FitnessCompanion.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitnessCompanion.Services;

public class EjercicioService: IEjercicioService
{
    private readonly FitnessCompanionDbContext _context;
    public EjercicioService(FitnessCompanionDbContext context)
    {
        this._context = context;
    }

    public async Task<Ejercicio> CreateEjercicio(Ejercicio ejercicio)
    {
        await _context.Ejercicios.AddAsync(ejercicio);
        await _context.SaveChangesAsync();
        return ejercicio;
    }

    public async Task DeleteEjercicio(Ejercicio ejercicio)
    {
       _context.Ejercicios.Remove(ejercicio);
        await _context.SaveChangesAsync();
    }

    public async Task<Ejercicio> GetEjercicio(int id)
    {
        return await _context.Ejercicios.Where(e => e.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<Ejercicio>> GetEjercicios()
    {
        return await _context.Ejercicios.ToListAsync();
    }

    public async Task UpdateEjercicio(Ejercicio ejercicio)
    {
        _context.Entry(ejercicio).State=EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
