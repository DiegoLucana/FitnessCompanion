using FitnessCompanion.DataAccess;
using FitnessCompanion.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitnessCompanion.Services;

public class DesayunoService : IDesayunoService
{
    private readonly FitnessCompanionDbContext _context;
    public DesayunoService(FitnessCompanionDbContext context)
    {
        this._context = context;
    }

    public async Task<Desayuno> CreateDesayuno(Desayuno desayuno)
    {
        await _context.Desayunos.AddAsync(desayuno);
        await _context.SaveChangesAsync();
        return desayuno;
    }

    public async Task DeleteDesayuno(Desayuno desayuno)
    {
        _context.Desayunos.Remove(desayuno);
        await _context.SaveChangesAsync();
    }

    public async Task<Desayuno> GetDesayuno(int id)
    {
        return await _context.Desayunos.Where(e => e.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<Desayuno>> GetDesayunos()
    {
        return await _context.Desayunos.ToListAsync();
    }

    /*public Task UpdateDesayuno(Desayuno desayuno)
    {
        throw new NotImplementedException();
    }*/

    public async Task UpdateDesayuno(Desayuno desayuno)
    {
        _context.Entry(desayuno).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
