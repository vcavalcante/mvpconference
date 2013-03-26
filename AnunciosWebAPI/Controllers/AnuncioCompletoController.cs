using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using AnunciosWebAPI.ViewModel;
using AnunciosWebAPI.Models;
using System.Web;

namespace AnunciosWebAPI.Controllers
{
    public class AnuncioCompletoController : ApiController
    {
        private DBContext db = new DBContext();

        // GET api/anunciocompleto
        public IEnumerable<AnuncioCompleto> Get()
        {
            var dadosCompletos = new List<AnuncioCompleto>();
            var anuncios = db.Anuncios.ToList();
            foreach (var item in anuncios)
            {
                dadosCompletos.Add(new AnuncioCompleto
                {
                    ID = item.ID,
                    IdAnunciante = item.IdAnunciante,
                    NomeAnunciante = db.Anunciantes.Find(item.IdAnunciante).Nome,
                    IdCategoria = item.IdCategoria,
                    NomeCategoria = db.Categorias.Find(item.IdCategoria).NomeCategoria,
                    DtCadastro = item.DtCadastro,
                    Titulo = item.Titulo,
                    Descricao = item.Descricao,
                    Gold = item.Gold,
                    Imagem = HttpContext.Current.Request.ApplicationPath + "/Images/Anuncios/" + item.Imagem,
                    Vendido = item.Vendido,
                    Preco = item.Preco
                });
            }
            return dadosCompletos;
        }

        // GET api/anunciocompleto/5
        public AnuncioCompleto Get(int id)
        {
            Anuncio anuncio = db.Anuncios.Find(id);
            if (anuncio == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            var dados = new AnuncioCompleto
            {
                ID = anuncio.ID,
                IdAnunciante = anuncio.IdAnunciante,
                NomeAnunciante = db.Anunciantes.Find(anuncio.IdAnunciante).Nome,
                IdCategoria = anuncio.IdCategoria,
                NomeCategoria = db.Categorias.Find(anuncio.IdCategoria).NomeCategoria,
                DtCadastro = anuncio.DtCadastro,
                Titulo = anuncio.Titulo,
                Descricao = anuncio.Descricao,
                Gold = anuncio.Gold,
                Imagem = HttpContext.Current.Request.ApplicationPath + "/Images/Anuncios/" + anuncio.Imagem,
                Vendido = anuncio.Vendido,
                Preco = anuncio.Preco
            };
            return dados;
        }

        // POST api/anunciocompleto
        public void Post([FromBody]string value)
        {
        }

        // PUT api/anunciocompleto/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/anunciocompleto/5
        public void Delete(int id)
        {
        }
    }
}
