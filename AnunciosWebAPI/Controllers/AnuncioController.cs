using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AnunciosWebAPI.Models;

namespace AnunciosWebAPI.Controllers
{
    public class AnuncioController : ApiController
    {
        private DBContext db = new DBContext();

        // GET api/Anuncio
        //public IEnumerable<Anuncio> GetAnuncios()
        public IEnumerable<Anuncio> GetAnuncios()
        {
            //return db.Anuncios.AsEnumerable();
            return db.Anuncios.ToList().Select(x =>
            {
                x.Imagem = HttpContext.Current.Request.ApplicationPath + "/Images/Anuncios/" + x.Imagem;
                return x;
            });
        }

        // GET api/Anuncio/5
        public Anuncio GetAnuncio(int id)
        {
            Anuncio anuncio = db.Anuncios.Find(id);
            if (anuncio == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return anuncio;
        }

        // GET api/AnunciosPorCategoria/?cat=1
        public IEnumerable<Anuncio> GetAnuncioPorCategoria(int categoria)
        {
            var dados = GetAnuncios().Where(a => a.IdCategoria == categoria);
            if (dados == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return dados;
        }

        // GET api/AnunciosDoAnunciante/?anunciante=10
        public IEnumerable<Anuncio> GetAnuncioDoAnunciante(int anunciante)
        {
            var dados = GetAnuncios().Where(a => a.IdAnunciante == anunciante);
            if (dados == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return dados;
        }

        // GET api/AnunciosFiltraNome/?filtro=bike
        public IEnumerable<Anuncio> GetPesquisaAnunciosPorNome(string filtro)
        {
            var dados = GetAnuncios().Where(a => a.Titulo.Contains(filtro) || a.Descricao.Contains(filtro));
            if (dados == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return dados;
        }

        
        // PUT api/Anuncio/5
        public HttpResponseMessage PutAnuncio(int id, Anuncio anuncio)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != anuncio.ID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(anuncio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Anuncio
        public HttpResponseMessage PostAnuncio(Anuncio anuncio)
        {
            if (ModelState.IsValid)
            {
                db.Anuncios.Add(anuncio);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, anuncio);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = anuncio.ID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Anuncio/5
        public HttpResponseMessage DeleteAnuncio(int id)
        {
            Anuncio anuncio = db.Anuncios.Find(id);
            if (anuncio == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Anuncios.Remove(anuncio);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, anuncio);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}