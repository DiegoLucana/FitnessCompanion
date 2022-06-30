using System.ComponentModel.DataAnnotations;

namespace FitnessCompanion.Entities;

public class Almuerzo: EntityBase
{
    [StringLength(1000)]
    [Required]
    public string Description { get; set; }
    public string? ImagenUrl { get; set; }
}
