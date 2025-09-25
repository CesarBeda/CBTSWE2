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

        [Required(ErrorMessage = "O campo Número é obrigatório.")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O campo Consignee é obrigatório.")]
        public string Consignee { get; set; }

        [Required(ErrorMessage = "O campo Navio é obrigatório.")]
        public string Navio { get; set; }

        // A coleção agora é inicializada pelo construtor e nunca será nula
        public ICollection<Container> Containers { get; set; }
    }
}