using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDRestaurante.Controllers
{
    public class RestauranteController : ApiController
    {
        public IEnumerable<Models.Restaurante> Get()
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var r1 = from r in dc.Restaurantes select r;
            return r1.ToList();
        }

        public void Delete(int id)
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            Models.Restaurante r = (from f in dc.Restaurantes where f.Id == id select f).Single();
            dc.Restaurantes.DeleteOnSubmit(r);
            dc.SubmitChanges();
        }

        public void Put(int id, [FromBody] Models.Restaurante restaurante)
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            Models.Restaurante rest = (from f in dc.Restaurantes where f.Id == id select f).Single();
            rest.Descricao = restaurante.Descricao;
            dc.SubmitChanges();
        }

        public void Post([FromBody] Models.Restaurante restaurante)
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            dc.Restaurantes.InsertOnSubmit(new Models.Restaurante() { Descricao = restaurante.Descricao });
            dc.SubmitChanges();
        }
    }
}
