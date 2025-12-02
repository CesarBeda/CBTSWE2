using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Cesar Beda CB302704X

namespace Models
{
    public class Produto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "É necessário por nome ao produto")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "É necessário por preço no produto")]
        public float Preco { get; set; }
        public bool Status { get; set; }
        public int IdUsuarioCadastro { get; set; }
        public int? IdUsuarioUpdate { get; set; }
    }
}
