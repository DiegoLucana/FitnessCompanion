using FitnessCompanion.DataAccess;
using FitnessCompanion.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitnessCompanion.Services;

public class RutinaService : IRutinaService
{
    private readonly FitnessCompanionDbContext _context;
    public RutinaService(FitnessCompanionDbContext context)
    {
        this._context = context;
    }
    public async Task<Rutina> CreateRutina(Rutina rutina)
    {
       if(rutina == null)
        {
            var r = new Rutina()
            {
                Title = rutina.Title,
                Description = rutina.Description,
                DateRutina = rutina.DateRutina,
                CantidadEjercicios = rutina.CantidadEjercicios,
                FechaInicio = rutina.FechaInicio,
                FechaFin = rutina.FechaFin,
                EjercicioId = rutina.EjercicioId,
                Status = true
            };
            await _context.Rutinas.AddAsync(r);
            await _context.SaveChangesAsync();
        }
       return rutina;
    }

    public async Task DeleteRutina(Rutina rutina)
    {
        _context.Rutinas.Remove(rutina);
        await _context.SaveChangesAsync();
    }

    public async Task<Rutina> GetRutina(int id)
    {
        return await _context.Rutinas.Where(u => u.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<Rutina>> GetRutinas()
    {
        return await _context.Rutinas.ToListAsync();
    }

    public async Task UpdateRutina(Rutina rutina)
    {
        var r = await _context.Rutinas.FindAsync(rutina.Id);
        r.Title = rutina.Title;
        r.Description = rutina.Description;
        r.DateRutina = rutina.DateRutina;
        r.CantidadEjercicios = rutina.CantidadEjercicios;
        r.FechaInicio = rutina.FechaInicio;
        r.FechaFin = rutina.FechaFin;
        _context.Entry(r).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
