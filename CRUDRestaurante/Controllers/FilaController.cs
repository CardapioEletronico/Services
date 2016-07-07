using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDRestaurante.Controllers
{
    public class FilaController : ApiController
    {
        public IEnumerable<Models.Fila> Get()
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var listaFilas = from f in dc.Filas select f;
            return listaFilas.ToList();
        }
        //Testar
        public IEnumerable<Models.Fila> GetIdRestaurante(int idRestaurante, [FromBody] string value)
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var filas = from f in dc.Filas where f.Restaurante_id == idRestaurante select f;
            return filas.ToList();
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            List<Models.Fila> f = JsonConvert.DeserializeObject<List<Models.Fila>>(value);
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            dc.Filas.InsertAllOnSubmit(f);
            dc.SubmitChanges();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            Models.Fila c = JsonConvert.DeserializeObject<Models.Fila>(value);
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var fila = (from f in dc.Filas where f.Id == id select f).Single();
            fila.Descricao = c.Descricao;
            fila.Restaurante_id = c.Restaurante_id;
            dc.SubmitChanges();
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var fila = (from f in dc.Filas where f.Id == id select f).Single();
            dc.Filas.DeleteOnSubmit(fila);
            dc.SubmitChanges();
        }
    }
}
