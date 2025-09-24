using System.ComponentModel.DataAnnotations;

namespace TP2.Models
{
    public class Container
    {
        public int Id { get; set; }

        [Required]
        [StringLength(11)]
        public string Numero { get; set; }

        [Required]
        public string Tipo { get; set; } // Valida��o para "Dry" ou "Reefer" ser� feita na View

        [Required]
        public int Tamanho { get; set; } // Valida��o para 20 ou 40 ser� feita na View

        public int BLId { get; set; }
        public BL BL { get; set; }
    }
}
