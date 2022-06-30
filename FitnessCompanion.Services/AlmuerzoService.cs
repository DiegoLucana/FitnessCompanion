using FitnessCompanion.DataAccess;
using FitnessCompanion.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitnessCompanion.Services;

public class AlmuerzoService : IAlmuerzoService
{
    private readonly FitnessCompanionDbContext _context;
    public AlmuerzoService(FitnessCompanionDbContext context)
    {
        this._context = context;
    }
    public async Task<Almuerzo> CreateAlmuerzo(Almuerzo almuerzo)
    {
        await _context.Almuerzos.AddAsync(almuerzo);
        await _context.SaveChangesAsync();
        return almuerzo;
    }

    public async Task DeleteAlmuerzo(Almuerzo almuerzo)
    {
        _context.Almuerzos.Remove(almuerzo);
        await _context.SaveChangesAsync();
    }

    public async Task<Almuerzo> GetAlmuerzo(int id)
    {
        return await _context.Almuerzos.Where(e => e.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<Almuerzo>> GetAlmuerzos()
    {
        return await _context.Almuerzos.ToListAsync();
    }

    public Task UpdateAlmuerzo(Almuerzo almuerzo)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAlmuerzos(Almuerzo almuerzo)
    {
        _context.Entry(almuerzo).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
