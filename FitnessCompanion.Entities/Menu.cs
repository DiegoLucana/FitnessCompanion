using System.ComponentModel.DataAnnotations;

namespace FitnessCompanion.Entities;

public class Menu: EntityBase
{
    [StringLength(100)]
    [Required]
    public string Title { get; set; }
    [StringLength(500)]
    [Required]
    public string Description { get; set; }
    public bool VerificadorMenu { get; set; }
    public int DesayunoId { get; set; }
    public Desayuno Desayuno { get; set; }
    public int AlmuerzoId { get; set; }
    public Almuerzo Almuerzo { get; set; }
    public int CenaId { get; set; }
    public Cena Cena { get; set; }
    public IList<Desayuno> Desayunos { get; set; }=new List<Desayuno>();
    public IList<Almuerzo> Almuerzos { get; set; }= new List<Almuerzo>();
    public IList<Cena> Cenas { get; set; }= new List<Cena>();
}
