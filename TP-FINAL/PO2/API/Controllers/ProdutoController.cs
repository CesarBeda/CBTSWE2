using API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Models;

//Cesar Beda CB302704X

namespace API.Controllers
{
    [ApiController]
    [Route("api/produto/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            var produtos = await _produtoRepository.GetAllAsync();
            return Ok(produtos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Produto>> GetProdutoById(int id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> CreateProduto([FromBody] Produto produto)
        {
            var createdProduto = await _produtoRepository.AddAsync(produto);
            return CreatedAtAction(nameof(GetProdutoById), new { id = createdProduto.Id }, createdProduto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Produto>> UpdateProduto(int id, [FromBody] Produto produto, int usuarioId)
        {   
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(id != produto.Id)
                return BadRequest("ID do caminho diferente do corpo da requisição");
            
            await _produtoRepository.UpdateAsync(produto, usuarioId);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var deleted = await _produtoRepository.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
