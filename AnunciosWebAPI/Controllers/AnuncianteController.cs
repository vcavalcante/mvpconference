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
    public class AnuncianteController : ApiController
    {
        private DBContext db = new DBContext();

        // GET api/Anunciante
        public IEnumerable<Anunciante> GetAnunciantes()
        {
            return db.Anunciantes.AsEnumerable();
        }

        // GET api/Anunciante/5
        public Anunciante GetAnunciante(int id)
        {
            Anunciante anunciante = db.Anunciantes.Find(id);
            if (anunciante == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return anunciante;
        }

        // PUT api/Anunciante/5
        public HttpResponseMessage PutAnunciante(int id, Anunciante anunciante)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != anunciante.IdAnunciante)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(anunciante).State = EntityState.Modified;

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

        // POST api/Anunciante
        public HttpResponseMessage PostAnunciante(Anunciante anunciante)
        {
            if (ModelState.IsValid)
            {
                db.Anunciantes.Add(anunciante);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, anunciante);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = anunciante.IdAnunciante }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Anunciante/5
        public HttpResponseMessage DeleteAnunciante(int id)
        {
            Anunciante anunciante = db.Anunciantes.Find(id);
            if (anunciante == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Anunciantes.Remove(anunciante);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, anunciante);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}