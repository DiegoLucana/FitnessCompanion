using System.ComponentModel.DataAnnotations;

namespace FitnessCompanion.Entities;

public class Ejercicio: EntityBase
{
    [StringLength(50)]
    [Required]
    public string Description { get; set; }
    public string? ImagenUrl { get; set; }
}
