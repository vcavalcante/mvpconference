using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnunciosWebAPI.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; }
        public virtual List<Anuncio> Anuncios { get; set; }
    }
}