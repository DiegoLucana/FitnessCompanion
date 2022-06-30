using FitnessCompanion.Entities;
using Microsoft.EntityFrameworkCore;
namespace FitnessCompanion.DataAccess;

public class FitnessCompanionDbContext: DbContext
{
    public FitnessCompanionDbContext()
    {

    }
    public FitnessCompanionDbContext(DbContextOptions<FitnessCompanionDbContext>options):base(options)
    {

    }
    public DbSet<Ejercicio> Ejercicios { get; set; }
    public DbSet<Rutina> Rutinas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<Desayuno> Desayunos { get; set; }
    public DbSet<Almuerzo> Almuerzos { get; set; }
    public DbSet<Cena> Cenas { get; set; }

}