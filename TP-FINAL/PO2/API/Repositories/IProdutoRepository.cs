using Models;

//Cesar Beda CB302704X

namespace API.Repositories
{
    public interface IProdutoRepository
    {
        Task<Produto> AddAsync(Produto produto);
        Task<Produto?> GetByIdAsync(int id);
        Task<IEnumerable<Produto>> GetAllAsync();  
        Task UpdateAsync(Produto produto, int usuarioId);
        Task<bool> DeleteAsync(int id);
    }
}
