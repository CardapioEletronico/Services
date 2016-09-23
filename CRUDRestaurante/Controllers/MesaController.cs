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

        // POST api/values
        public void Post([FromBody]Models.Mesa mesa)
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            dc.Mesas.InsertOnSubmit(new Models.Mesa() { Disponivel = mesa.Disponivel, Restaurante_Id = mesa.Restaurante_Id, Numero = mesa.Numero});
            dc.SubmitChanges();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Models.Mesa mesa)
        {
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var mes = (from f in dc.Mesas where f.Id == id select f).Single();
            mes.Disponivel = mesa.Disponivel;
            mes.Restaurante_Id = mesa.Restaurante_Id;
            mes.Numero = mesa.Numero;
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
