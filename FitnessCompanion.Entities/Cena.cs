using System.ComponentModel.DataAnnotations;

namespace FitnessCompanion.Entities;

public class Cena: EntityBase
{
    [StringLength(1000)]
    [Required]
    public string Description { get; set; }
    public string? ImagenUrl { get; set; }
}
