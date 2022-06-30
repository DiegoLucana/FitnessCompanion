using System.ComponentModel.DataAnnotations;

namespace FitnessCompanion.Entities;

public class Rutina: EntityBase
{
    [StringLength(100)]
    [Required]
    public string Title { get; set; }
    [StringLength(500)]
    [Required]
    public string Description { get; set; }
    public DateTime DateRutina { get; set; }
    public int CantidadEjercicios { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public bool VerificadorEjercicio { get; set; }
    public string? ImagenUrl { get; set; }
    public int EjercicioId { get; set; }
    public Ejercicio Ejercicio { get; set; }
}