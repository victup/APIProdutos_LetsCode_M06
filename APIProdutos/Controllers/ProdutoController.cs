using APIProdutos;
using Microsoft.AspNetCore.Mvc;
using APIProdutos.Core.Interfaces;
using APIProdutos.Core.Model;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    public List<Produto> ProdutoList { get; set; }

    public IProdutoService _produtoService;

    public ProdutoController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet("/produto/{descricao}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Produto> GetProduto(string descricao)
    {
        var produtos = _produtoService.GetProduto(descricao);
        if (produtos == null)
            return BadRequest();
        return Ok(produtos);

    }

    [HttpGet("/produto")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<Produto>> GetProdutos()
    {
        return Ok(_produtoService.GetProdutos());
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Produto> PostProduto([FromBody] Produto produto)
    {
        if (!_produtoService.InsertProduto(produto))
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(PostProduto), produto);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult UpdateProduto(long id, Produto produto)
    {
        if (!_produtoService.UpdateProduto(id, produto))
            return BadRequest();

        return Ok();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<List<Produto>> DeleteProduto(long id)
    {
        if (!_produtoService.DeleteProduto(id))
        {
            return NotFound();
        }
        return NoContent();
    }
}
