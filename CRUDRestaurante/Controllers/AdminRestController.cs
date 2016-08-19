using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDRestaurante.Controllers
{
    public class AdminRestController : ApiController
    {
        public IEnumerable<Models.AdminRest> Get()
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var listaAdminRest = from f in dc.AdminRests select f;
            return listaAdminRest.ToList();
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            List<Models.AdminRest> f = JsonConvert.DeserializeObject<List<Models.AdminRest>>(value);
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            dc.AdminRests.InsertAllOnSubmit(f);
            dc.SubmitChanges();
        }

        // PUT api/values/5
        public void Put(string Usuario, [FromBody]string value)
        {
            Models.AdminRest c = JsonConvert.DeserializeObject<Models.AdminRest>(value);
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var adminRest = (from f in dc.AdminRests where f.Usuario == Usuario select f).Single();
            adminRest.Senha = c.Senha;
            adminRest.Restaurante_id = c.Restaurante_id;
            dc.SubmitChanges();
        }

        // DELETE api/values/5
        public void Delete(string Usuario)
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var adminRest = (from f in dc.AdminRests where f.Usuario == Usuario select f).Single();
            dc.AdminRests.DeleteOnSubmit(adminRest);
            dc.SubmitChanges();
        }
    }
}
