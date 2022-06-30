using FitnessCompanion.Entities;

namespace FitnessCompanion.Services;

public interface IUsuarioService
{
    Task<Usuario> CreateUsuario(Usuario usuario);
    Task<Usuario> GetUsuario(int id);
    Task<List<Usuario>> GetUsuarios();
    Task DeleteUsuario(Usuario usuario);
    Task UpdateUsuario(Usuario usuario);
}
