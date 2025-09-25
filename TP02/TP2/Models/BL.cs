using System.ComponentModel.DataAnnotations;

namespace TP2.Models
{
    public class BL
    {
        // Construtor para inicializar a lista de Containers
        public BL()
        {
            Containers = new HashSet<Container>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "O campo N�mero � obrigat�rio.")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O campo Consignee � obrigat�rio.")]
        public string Consignee { get; set; }

        [Required(ErrorMessage = "O campo Navio � obrigat�rio.")]
        public string Navio { get; set; }

        // A cole��o agora � inicializada pelo construtor e nunca ser� nula
        public ICollection<Container> Containers { get; set; }
    }
}