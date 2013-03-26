using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnunciosWebAPI.Models
{
    public class Anunciante
    {
        [Key]
        public int IdAnunciante { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public virtual List<Anuncio> Anuncios { get; set; }

    }
}