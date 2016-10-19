using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDRestaurante.Controllers
{
    public class GerentePedidosController : ApiController
    {
        public IEnumerable<Models.GerentePedido> Get()
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var listaGerentePedidos = from f in dc.GerentePedidos select f;
            return listaGerentePedidos.ToList();
        }


        public void Post([FromBody]string value)
        {
            List<Models.GerentePedido> f = JsonConvert.DeserializeObject<List<Models.GerentePedido>>(value);
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            dc.GerentePedidos.InsertAllOnSubmit(f);
            dc.SubmitChanges();
        }

        // PUT api/values/5
        [Route("api/gerentepedido/{usuario}")]
        [HttpPut]
        public void Put(string usuario, [FromBody]string value)
        {
            Models.GerentePedido c = JsonConvert.DeserializeObject<Models.GerentePedido>(value);
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var gerPedido = (from f in dc.GerentePedidos where f.Usuario == usuario select f).Single();
            gerPedido.Usuario = c.Usuario;
            gerPedido.Senha = c.Senha;
            dc.SubmitChanges();
        }

        // DELETE api/values/5]
        [Route("api/gerentepedido/{usuario}")]
        [HttpDelete]
        public void Delete(string usuario)
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var gerPedido = (from f in dc.GerentePedidos where f.Usuario == usuario select f).Single();
            dc.GerentePedidos.DeleteOnSubmit(gerPedido);
            dc.SubmitChanges();
        }
    }
}
