using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDRestaurante.Controllers
{
    public class AdminSistemaController : ApiController
    {
        public IEnumerable<Models.AdminSistema> Get()
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var listaAdminSistema = from f in dc.AdminSistemas select f;
            return listaAdminSistema.ToList();
        }

        public void Post([FromBody]string value)
        {
            List<Models.AdminSistema> f = JsonConvert.DeserializeObject<List<Models.AdminSistema>>(value);
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            dc.AdminSistemas.InsertAllOnSubmit(f);
            dc.SubmitChanges();
        }

        // PUT api/values/5
        [Route("api/adminsistema/{usuario}")]
        [HttpPut]
        public void Put(string usuario, [FromBody]string value)
        {
            Models.AdminSistema c = JsonConvert.DeserializeObject<Models.AdminSistema>(value);
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var admSistema = (from f in dc.AdminSistemas where f.Usuario == usuario select f).Single();
            admSistema.Usuario = c.Usuario;
            admSistema.Senha = c.Senha;
            dc.SubmitChanges();
        }

        // DELETE api/values/5]
        [Route("api/adminsistema/{usuario}")]
        [HttpDelete]
        public void Delete(string usuario)
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var admSistema = (from f in dc.AdminSistemas where f.Usuario == usuario select f).Single();
            dc.AdminSistemas.DeleteOnSubmit(admSistema);
            dc.SubmitChanges();
        }
    }
}
