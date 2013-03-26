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
    public class CategoriaController : ApiController
    {
        private DBContext db = new DBContext();

        // GET api/Categoria
        public IEnumerable<Categoria> GetCategorias()
        {
            return db.Categorias.AsEnumerable();
        }

        // GET api/Categoria/5
        public Categoria GetCategoria(int id)
        {
            Categoria categoria = db.Categorias.Find(id);
            if (categoria == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return categoria;
        }

        // PUT api/Categoria/5
        public HttpResponseMessage PutCategoria(int id, Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != categoria.IdCategoria)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(categoria).State = EntityState.Modified;

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

        // POST api/Categoria
        public HttpResponseMessage PostCategoria(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                db.Categorias.Add(categoria);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, categoria);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = categoria.IdCategoria }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Categoria/5
        public HttpResponseMessage DeleteCategoria(int id)
        {
            Categoria categoria = db.Categorias.Find(id);
            if (categoria == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Categorias.Remove(categoria);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, categoria);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}