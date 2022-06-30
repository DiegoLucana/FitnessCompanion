using FitnessCompanion.DataAccess;
using FitnessCompanion.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitnessCompanion.Services;

public class UsuarioService : IUsuarioService
{
    private readonly FitnessCompanionDbContext _context;
    public UsuarioService(FitnessCompanionDbContext context)
    {
        this._context = context;
    }
    public async Task<Usuario> CreateUsuario(Usuario usuario)
    {
        if (usuario == null)
        {
            var user = new Usuario()
            {
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Correo = usuario.Correo,
                Contraseña = usuario.Contraseña,
                Telefono = usuario.Telefono,
                RutinaId = usuario.RutinaId,
                MenuId = usuario.MenuId,
                Status = true

            };
            await _context.Usuarios.AddAsync(user);
            await _context.SaveChangesAsync();

        }

        return usuario;
    }

    public async Task DeleteUsuario(Usuario usuario)
    {
        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task<Usuario> GetUsuario(int id)
    {
        return await _context.Usuarios.Where(u => u.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<Usuario>> GetUsuarios()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task UpdateUsuario(Usuario usuario)
    {
        var user = await _context.Usuarios.FindAsync(usuario.Id);
        user.Nombre = usuario.Nombre;
        user.Apellido = usuario.Apellido;
        user.Correo = usuario.Correo;
        user.Contraseña = usuario.Contraseña;
        user.Telefono = usuario.Telefono;
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
