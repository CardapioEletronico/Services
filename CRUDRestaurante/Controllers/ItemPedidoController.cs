using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDRestaurante.Controllers
{
    public class ItemPedidoController : ApiController
    {
        public IEnumerable<Models.ItemPedido> Get()
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var r1 = from r in dc.ItemPedidos select r;
            return r1.ToList();
        }

        public void Post([FromBody] Models.ItemPedido itempedido)
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            dc.ItemPedidos.InsertOnSubmit(new Models.ItemPedido() { Quantidade = itempedido.Quantidade, Hora = itempedido.Hora, Situacao = itempedido.Situacao, Produto_Id = itempedido.Produto_Id, Pedido_Id = itempedido.Pedido_Id });
            dc.SubmitChanges();
        }

        public void Put(int id, [FromBody] Models.ItemPedido itempedido)
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            Models.ItemPedido itPed = (from f in dc.ItemPedidos where f.Id == id select f).Single();
            itPed.Quantidade = itempedido.Quantidade;
            itPed.Situacao = itempedido.Situacao;
            itPed.Hora = itempedido.Hora;
            itPed.Pedido_Id = itempedido.Pedido_Id;
            itPed.Produto_Id = itempedido.Produto_Id;
            dc.SubmitChanges();
        }

        public void Delete(int id)
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            Models.ItemPedido r = (from f in dc.ItemPedidos where f.Id == id select f).Single();
            dc.ItemPedidos.DeleteOnSubmit(r);
            dc.SubmitChanges();
        }

    }
}
