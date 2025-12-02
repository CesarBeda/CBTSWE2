using API.Data;
using Microsoft.EntityFrameworkCore;
using Models;

//Cesar Beda CB302704X

namespace API.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Produto> AddAsync(Produto produto)
        {
            var usuarioExistente = _context.Usuarios.Find(produto.IdUsuarioCadastro);

            if (usuarioExistente == null)
                throw new ArgumentException("Usuário não encontrado.", nameof(produto.IdUsuarioCadastro));

            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
                return false;

            _context.Produtos.Remove(produto);

            var linhasAfetadas = await _context.SaveChangesAsync();

            return linhasAfetadas > 0;
        }

        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            return await _context.Produtos.AsNoTracking().ToListAsync();
        }

        public async Task<Produto?> GetByIdAsync(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public Task UpdateAsync(Produto produto, int usuarioId)
        {
            var usuarioExistente = _context.Usuarios.Find(usuarioId);

            if (usuarioExistente == null)
                throw new ArgumentException("Usuário não encontrado.", nameof(usuarioId));

            produto.IdUsuarioUpdate = usuarioId;

            _context.Produtos.Update(produto);

            return _context.SaveChangesAsync();
        }
    }
}
