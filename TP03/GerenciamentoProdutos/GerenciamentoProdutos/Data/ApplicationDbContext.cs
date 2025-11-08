using GerenciamentoProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoProdutos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Mapeia o modelo Produto para uma tabela "Produtos" no banco
        public DbSet<Produto> Produtos { get; set; }
    }
}