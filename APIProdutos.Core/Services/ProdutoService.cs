using APIProdutos.Core.Interfaces;
using APIProdutos.Core.Model;

namespace APIProdutos.Core.Services
{
    public class ProdutoService: IProdutoService
    {
        public IProdutoRepository _produtoRepository;
        public ProdutoService (IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public List<Produto> GetProdutos()
        {
            return _produtoRepository.GetProdutos();
        }

        public Produto GetProduto(string descricao)
        {
            return _produtoRepository.GetProduto(descricao);
        }

        public bool InsertProduto(Produto produto)
        {
            return _produtoRepository.InsertProduto(produto);
        }

        public bool DeleteProduto(long id)
        {
            return _produtoRepository.DeleteProduto(id);
        }

        public bool UpdateProduto(long id, Produto produto)
        {
            return (_produtoRepository.UpdateProduto(id, produto));
        }

    }
}