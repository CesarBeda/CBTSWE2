using Models;

//Desenvolvido por Laysa Bernardes e Lucas Lopes

namespace WEB_SITE.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetUsuarioByNome(string nome); 
    }
}
