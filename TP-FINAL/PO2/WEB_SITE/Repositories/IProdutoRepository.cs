using Models;

//Desenvolvido por Laysa Bernardes e Lucas Lopes

namespace WEB_SITE.Repositories
{
    public interface IProdutoRepository
    {
        Task<Produto?> AddAsync(Produto produto, int usuarioId);
        Task<Produto[]> GetAllAsync();
        Task<Produto?> GetByIdAsync(int id);
        Task<Produto?> UpdateAsync(Produto produto, int usuarioId);
        Task<bool> DeleteAsync(int id);
    }
}
