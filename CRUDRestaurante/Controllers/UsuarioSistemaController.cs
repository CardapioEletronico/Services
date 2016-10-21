using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDRestaurante.Controllers
{
    public class UsuarioSistemaController : ApiController
    {
        public IEnumerable<Models.UsuarioSistema> Get()
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var listaUsuariosSistema = from f in dc.UsuarioSistemas select f;
            return listaUsuariosSistema.ToList();
        }

        public void Post([FromBody]string value)
        {
            List<Models.UsuarioSistema> f = JsonConvert.DeserializeObject<List<Models.UsuarioSistema>>(value);
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            dc.UsuarioSistemas.InsertAllOnSubmit(f);
            dc.SubmitChanges();
        }

        // PUT api/values/5
        [Route("api/usuariosistema/{usuario}")]
        [HttpPut]
        public void Put(string usuario, [FromBody]string value)
        {
            Models.UsuarioSistema c = JsonConvert.DeserializeObject<Models.UsuarioSistema>(value);
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var usuarioSist = (from f in dc.UsuarioSistemas where f.Usuario == usuario select f).Single();
            usuarioSist.Usuario = c.Usuario;
            usuarioSist.Senha = c.Senha;
            usuarioSist.Restaurante_Id = c.Restaurante_Id;
            usuarioSist.Garcom = c.Garcom;
            usuarioSist.AdminRest = c.AdminRest;
            usuarioSist.Caixa = c.Caixa;
            usuarioSist.GerentePedidos = c.GerentePedidos;
            dc.SubmitChanges();
        }

        // DELETE api/values/5]
        [Route("api/usuariosistema/{usuario}")]
        [HttpDelete]
        public void Delete(string usuario)
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var usuarioSist = (from f in dc.UsuarioSistemas where f.Usuario == usuario select f).Single();
            dc.UsuarioSistemas.DeleteOnSubmit(usuarioSist);
            dc.SubmitChanges();
        }
    }
}
