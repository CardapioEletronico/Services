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

        public void Post([FromBody] Models.AdminSistema adminsistema)
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            dc.AdminSistemas.InsertOnSubmit(new Models.AdminSistema() { Usuario = adminsistema.Usuario, Senha = adminsistema.Senha });
            dc.SubmitChanges();

        }

        // PUT api/values/5
        [Route("api/adminsistema/{usuario}")]
        [HttpPut]
        public void Put(string usuario, [FromBody] Models.AdminSistema adminsistema)
        {

            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            Models.AdminSistema rest = (from f in dc.AdminSistemas where f.Usuario == usuario select f).Single();
            rest.Usuario = adminsistema.Usuario;
            rest.Senha = adminsistema.Senha;
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
