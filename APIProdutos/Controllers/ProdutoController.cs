using APIProdutos;
using Microsoft.AspNetCore.Mvc;
using APIProdutos.Core.Interfaces;
using APIProdutos.Core.Model;
using APIProdutos.Filters;
using Microsoft.AspNetCore.Cors;

[ApiController]
[Route("[controller]")]
[TypeFilter(typeof(LogResourceFilter))]
[EnableCors("PolicyCors")]
public class ProdutoController : ControllerBase
{

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
        Console.WriteLine("Iniciando");
        var produtos = _produtoService.GetProduto(descricao);
        if (produtos == null)
        {
            return NotFound();
        }
        return Ok(produtos);

    }

    [HttpGet("/produto")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    //[TypeFilter(typeof(LogAuthorizationFilter))]
    public ActionResult<List<Produto>> GetProdutos()
    {
        Console.WriteLine("Iniciando");
        return Ok(_produtoService.GetProdutos());
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [TypeFilter(typeof(LogActionFilter))]
    public ActionResult<Produto> PostProduto([FromBody] Produto produto)
    {
        Console.WriteLine("Iniciando");
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
    [TypeFilter(typeof(LogActionFilter))]
    [ServiceFilter(typeof(GaranteProdutoExisteActionFilter))]
    public IActionResult UpdateProduto(long id, Produto produto)
    {
        Console.WriteLine("Iniciando");
        if (!_produtoService.UpdateProduto(id, produto))
        {
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        return Ok();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ServiceFilter(typeof(GaranteProdutoExisteActionFilter))]
    public ActionResult<List<Produto>> DeleteProduto(long id)
    {
        Console.WriteLine("Iniciando");
        if (!_produtoService.DeleteProduto(id))
        {
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
        return Ok();
    }
}
