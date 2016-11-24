using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDRestaurante.Controllers
{
    public class ProdutoController : ApiController
    {
        public IEnumerable<Models.Produto> Get()
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var listaProdutos = from f in dc.Produtos select f;
            return listaProdutos.ToList();
        }

        // POST api/values
        public void Post([FromBody]Models.Produto produto)
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            dc.Produtos.InsertOnSubmit(new Models.Produto() { Descricao = produto.Descricao, Preco = produto.Preco, Foto = produto.Foto, NomeDescricao = produto.NomeDescricao, Cardapio_id = produto.Cardapio_id, Fila_id = produto.Fila_id, ArquivoFoto = produto.ArquivoFoto});
            dc.SubmitChanges();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] Models.Produto produto)
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var x = (from f in dc.Produtos where f.Id == id select f).Single();
            x.Descricao = produto.Descricao;
            x.Preco = produto.Preco;
            x.Foto = produto.Foto;
            x.NomeDescricao = produto.Descricao;
            x.Cardapio_id = produto.Cardapio_id;
            x.Fila_id = produto.Fila_id;
            x.ArquivoFoto = produto.ArquivoFoto;
            dc.SubmitChanges();
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var produto = (from f in dc.Produtos where f.Id == id select f).Single();
            dc.Produtos.DeleteOnSubmit(produto);
            dc.SubmitChanges();
        }
    }
}
