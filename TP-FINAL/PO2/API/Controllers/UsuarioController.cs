using API.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Models;

//Cesar Beda CB302704X

namespace API.Controllers
{
    [ApiController]
    [Route("api/usuario/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> GetUsuarioById(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }
        [HttpGet("{nome}")]
        public async Task<ActionResult<Usuario>> GetUsuarioByNome(string nome)
        {
            var usuario = await _usuarioRepository.GetByNomeAsync(nome);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> CreateUsuario([FromBody] Usuario usuario)
        {
            var createdUsuario = await _usuarioRepository.AddAsync(usuario);
            return CreatedAtAction(nameof(GetUsuarioById), new { id = createdUsuario.Id }, createdUsuario);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Usuario>> UpdateUsuario(int id, [FromBody] Usuario usuario)
        {   
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(id != usuario.Id)
                return BadRequest("ID do caminho diferente do corpo da requisição");

            await _usuarioRepository.UpdateAsync(usuario);

            return NoContent();
        }   

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var deleted = await _usuarioRepository.DeleteAsync(id);
            
            if (!deleted)
                return NotFound();
            
            return NoContent();
        }
    }
}
