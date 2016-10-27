using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDRestaurante.Controllers
{
    public class PedidoController : ApiController
    {
        public IEnumerable<Models.Pedido> Get()
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var r1 = from r in dc.Pedidos select r;
            return r1.ToList();
        }

        public void Post([FromBody] Models.Pedido pedido)
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            dc.Pedidos.InsertOnSubmit(new Models.Pedido() { ValorTotal = pedido.ValorTotal, Data = pedido.Data, Cliente = pedido.Cliente, Mesa_Id = pedido.Mesa_Id });
            dc.SubmitChanges();
        }

        public void Put(int id, [FromBody] Models.Pedido pedido)
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            Models.Pedido Ped = (from f in dc.Pedidos where f.Id == id select f).Single();
            Ped.ValorTotal = pedido.ValorTotal;
            Ped.Data = pedido.Data;
            Ped.Cliente = pedido.Cliente;
            Ped.Mesa_Id = pedido.Mesa_Id;
            dc.SubmitChanges();
        }

        public void Delete(int id)
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            Models.Pedido r = (from f in dc.Pedidos where f.Id == id select f).Single();
            dc.Pedidos.DeleteOnSubmit(r);
            dc.SubmitChanges();
        }
    }
}
