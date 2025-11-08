using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoProdutos.Models
{
    public class Produto
    {
        [Key] // Marca como Chave Primária
        public int Id { get; set; }

        [Display(Name = "Produto")]
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        public string Descricao { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O campo Preço é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O Preço deve ser maior que zero.")]
        [Column(TypeName = "decimal(18, 2)")] // Define o tipo no banco de dados
        public decimal Preco { get; set; }

        [Display(Name = "Quantidade em Estoque")] // Mudar o texto na tela
        [Required(ErrorMessage = "O campo Quantidade é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "A Quantidade não pode ser negativa.")]
        public int QuantidadeEmEstoque { get; set; }
    }
}
