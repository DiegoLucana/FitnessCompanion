using System.ComponentModel.DataAnnotations;

namespace FitnessCompanion.Entities;

public class Usuario: EntityBase
{
    [StringLength(50)]
    [Required]
    public string Nombre { get; set; }
    [StringLength(50)]
    [Required]
    public string Apellido { get; set; }
    [StringLength(50)]
    [Required]
    public string Correo { get; set; }
    [StringLength(50)]
    [Required]
    public string Contraseña { get; set; }
    public long Telefono { get; set; }
    public string? ImagenUrl { get; set; }
    public int RutinaId { get; set; }
    public Rutina Rutina { get; set; }
    public int MenuId { get; set; }
    public Menu Menu { get; set; }
    public IList<Rutina> Rutinas { get; set; }= new List<Rutina>();

}
