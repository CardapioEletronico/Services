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
        public void Post([FromBody]string value)
        {
            List<Models.Produto> f = JsonConvert.DeserializeObject<List<Models.Produto>>(value);
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            dc.Produtos.InsertAllOnSubmit(f);
            dc.SubmitChanges();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            Models.Produto c = JsonConvert.DeserializeObject<Models.Produto>(value);
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var produto = (from f in dc.Produtos where f.Id == id select f).Single();
            produto.Descricao = c.Descricao;
            produto.Preco = c.Preco;
            produto.Foto = c.Foto;
            produto.NomeDescricao = c.Descricao;
            produto.Cardapio_id = c.Cardapio_id;
            produto.Fila_id = c.Fila_id;
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
