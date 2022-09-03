using APIProdutos.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIProdutos.Core.Interfaces
{
    public interface IProdutoRepository
    {
        public List<Produto> GetProdutos();
        public Produto GetProduto(string descricao);

        public bool InsertProduto(Produto produto);

        public bool DeleteProduto(long id);

        public bool UpdateProduto(long id, Produto produto);


    }
}
