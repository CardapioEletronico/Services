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
            var r1 = from r in dc.Filas select r;
            return r1.ToList();
        }

        public void Delete(int id)
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            Models.Fila r = (from f in dc.Filas where f.Id == id select f).Single();
            dc.Filas.DeleteOnSubmit(r);
            dc.SubmitChanges();
        }

        //O bom e velho update
        public void Put(int id, [FromBody] string value)
        {
            Models.Fila x = JsonConvert.DeserializeObject<Models.Fila>(value);
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            Models.Fila fila = (from f in dc.Filas where f.Id == id select f).Single();
            fila.Descricao = x.Descricao;
            dc.SubmitChanges();
        }

        public void Post([FromBody] string value)
        {
            //string postData = Encoding.UTF8.GetString(value);
            string postData = value;

            Models.Fila r = JsonConvert.DeserializeObject<Models.Fila>(postData);
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            dc.Filas.InsertOnSubmit(r);
            dc.SubmitChanges();

        }
    }
}
