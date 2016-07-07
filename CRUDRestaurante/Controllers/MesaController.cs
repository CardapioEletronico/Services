using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDRestaurante.Controllers
{
    public class MesaController : ApiController
    {
        public IEnumerable<Models.Mesa> Get()
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var mesas = from f in dc.Mesas select f;
            return mesas.ToList();
        }

        public IEnumerable<Models.Mesa> GetIdRestaurante(int idRestaurante, [FromBody] string value)
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var mesas = from f in dc.Mesas where f.Restaurante_Id == idRestaurante select f;
            return mesas.ToList();
        }

        public IEnumerable<Models.Mesa> GetDisponiveis(int idRestaurante, [FromBody] string value)
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var mesas = (from f in dc.Mesas where f.Restaurante_Id == idRestaurante && f.Disponivel == true select f);
            return mesas.ToList();
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            List<Models.Mesa> f = JsonConvert.DeserializeObject<List<Models.Mesa>>(value);
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            dc.Mesas.InsertAllOnSubmit(f);
            dc.SubmitChanges();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            Models.Mesa c = JsonConvert.DeserializeObject<Models.Mesa>(value);
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var mesa = (from f in dc.Mesas where f.Id == id select f).Single();
            mesa.Disponivel = c.Disponivel;
            mesa.Restaurante_Id = c.Restaurante_Id;
            mesa.Numero = c.Numero;
            dc.SubmitChanges();
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var mesa = (from f in dc.Mesas where f.Id == id select f).Single();
            dc.Mesas.DeleteOnSubmit(mesa);
            dc.SubmitChanges();
        }
    }
}
