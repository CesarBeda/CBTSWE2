using System.ComponentModel.DataAnnotations;

namespace TP2.Models
{
    public class Container
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Número é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O número do container deve ter 11 caracteres.")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O campo Tipo é obrigatório.")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "O campo Tamanho é obrigatório.")]
        public int Tamanho { get; set; }

        [Required(ErrorMessage = "É obrigatório associar um BL.")]
        public int BLId { get; set; }
        public BL? BL { get; set; }
    }
}