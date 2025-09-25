using System.ComponentModel.DataAnnotations;

namespace TP2.Models
{
    public class Container
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo N�mero � obrigat�rio.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O n�mero do container deve ter 11 caracteres.")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O campo Tipo � obrigat�rio.")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "O campo Tamanho � obrigat�rio.")]
        public int Tamanho { get; set; }

        [Required(ErrorMessage = "� obrigat�rio associar um BL.")]
        public int BLId { get; set; }
        public BL? BL { get; set; }
    }
}