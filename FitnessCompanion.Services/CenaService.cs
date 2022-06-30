using FitnessCompanion.DataAccess;
using FitnessCompanion.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitnessCompanion.Services;

public class CenaService : ICenaService
{
    private readonly FitnessCompanionDbContext _context;
    public CenaService(FitnessCompanionDbContext context)
    {
        this._context = context;
    }
    public async Task<Cena> CreateCena(Cena cena)
    {
        await _context.Cenas.AddAsync(cena);
        await _context.SaveChangesAsync();
        return cena;
    }

    public async Task DeleteCena(Cena cena)
    {
        _context.Cenas.Remove(cena);
        await _context.SaveChangesAsync();
    }

    public async Task<Cena> GetCena(int id)
    {
        return await _context.Cenas.Where(e => e.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<Cena>> GetCenas()
    {
        return await _context.Cenas.ToListAsync();
    }

    public async Task UpdateCena(Cena cena)
    {
        _context.Entry(cena).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
