using Models;

//Cesar Beda CB302704X

namespace API.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> AddAsync(Usuario usuario);
        Task<Usuario?> GetByIdAsync(int id);
        Task<Usuario?> GetByNomeAsync(string nome);
        Task<IEnumerable<Usuario>> GetAllAsync();   
        Task UpdateAsync(Usuario usuario);
        Task<bool> DeleteAsync(int id);
    }
}
