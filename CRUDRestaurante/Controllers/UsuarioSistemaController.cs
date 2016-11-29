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

        public void Post([FromBody]Models.UsuarioSistema usuarioSistema)
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            dc.UsuarioSistemas.InsertOnSubmit(new Models.UsuarioSistema() { Usuario = usuarioSistema.Usuario, AdminRest = usuarioSistema.AdminRest, Garcom = usuarioSistema.Garcom, GerentePedidos = usuarioSistema.GerentePedidos, Caixa = usuarioSistema.Caixa, Restaurante_Id = usuarioSistema.Restaurante_Id, Senha = usuarioSistema.Senha });
            dc.SubmitChanges();
        }

        // PUT api/values/5
        [Route("api/usuariosistema/{usuario}")]
        [HttpPut]
        public void Put(string usuario, [FromBody]Models.UsuarioSistema c)
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var x = (from f in dc.UsuarioSistemas where f.Usuario == usuario select f).Single();
            x.Usuario = c.Usuario;
            x.Senha = c.Senha;
            x.Restaurante_Id = c.Restaurante_Id;
            x.Garcom = c.Garcom;
            x.AdminRest = c.AdminRest;
            x.Caixa = c.Caixa;
            x.GerentePedidos = c.GerentePedidos;
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
