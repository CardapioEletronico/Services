using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDRestaurante.Controllers
{
    public class CardapioController : ApiController
    {
        public IEnumerable<Models.Cardapio> Get()
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var listaCardapios = from f in dc.Cardapios select f;
            return listaCardapios.ToList();
        }

        // POST api/values
        public void Post([FromBody] Models.Cardapio cardapio)
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            dc.Cardapios.InsertOnSubmit(new Models.Cardapio() { Descricao=cardapio.Descricao, Restaurante_id = cardapio.Restaurante_id});
            dc.SubmitChanges();

        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Models.Cardapio cardapio)
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var car = (from f in dc.Cardapios where f.Id == id select f).Single();
            car.Descricao = cardapio.Descricao;
            //car.Restaurante_id = c.Restaurante_id;
            dc.SubmitChanges();
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var cardapio = (from f in dc.Cardapios where f.Id == id select f).Single();
            dc.Cardapios.DeleteOnSubmit(cardapio);
            dc.SubmitChanges();
        }
    }
}
