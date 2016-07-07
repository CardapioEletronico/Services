﻿using Newtonsoft.Json;
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
            var cardapios = from f in dc.Cardapios select f;
            return cardapios.ToList();
        }

        public IEnumerable<Models.Cardapio> GetIdRestaurante(int idRestaurante, [FromBody] string value)
        {
            //List<Models.Cardapio> c = JsonConvert.DeserializeObject<List<Models.Cardapio>>(value);
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var cardapios = from f in dc.Cardapios where f.Restaurante_id == idRestaurante select f;
            return cardapios.ToList();
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            List<Models.Cardapio> c = JsonConvert.DeserializeObject<List<Models.Cardapio>>(value);
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            dc.Cardapios.InsertAllOnSubmit(c);
            dc.SubmitChanges();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            Models.Cardapio c = JsonConvert.DeserializeObject<Models.Cardapio>(value);
            Models.CardapioDataContext dc = new Models.CardapioDataContext();
            var cardapio = (from f in dc.Cardapios where f.Id == id select f).Single();
            cardapio.Descricao = c.Descricao;
            cardapio.Restaurante_id = c.Restaurante_id;
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
