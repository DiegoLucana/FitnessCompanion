namespace FitnessCompanion.Dto.Request;

public class DtoRutina
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DateRutina { get; set; }
    public int CantidadEjercicios { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public bool VerificadorEjercicio { get; set; }
}
