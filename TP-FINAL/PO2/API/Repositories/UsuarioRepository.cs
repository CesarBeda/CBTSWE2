using API.Data;
using Microsoft.EntityFrameworkCore;
using Models;

//Cesar Beda CB302704X

namespace API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> AddAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
                return false;
            
            _context.Usuarios.Remove(usuario);

            var linhasAfetadas = await _context.SaveChangesAsync();

            return linhasAfetadas > 0;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.AsNoTracking().ToListAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuario?> GetByNomeAsync(string nome)
        {
            return await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.Nome == nome);
        }

        public Task UpdateAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            return _context.SaveChangesAsync();
        }
    }
}
