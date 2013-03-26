using System.Collections.ObjectModel;
using AnunciosWebAPI.Models;

namespace AnunciosWebAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AnunciosWebAPI.Models.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DBContext context) {
            CrieCategorias(context);
            CrieAnunciantes(context);

            AddAnuncio(context, 1, "Capacitor de Fluxo", "desc", false);
            AddAnuncio(context, 1, "SuperPhone", "desc", false);
            AddAnuncio(context, 1, "Hoverboard", "desc", false);
            AddAnuncio(context, 1, "Sabre de Luz", "desc", true);
            AddAnuncio(context, 1, "Máquina do Tempo", "desc", false);

            AddAnuncio(context, 2, "Surface Pro 128Gb", "desc", false);
            AddAnuncio(context, 2, "HTC 8x", "desc", false);
            AddAnuncio(context, 2, "Nokia 920", "desc", false);
            AddAnuncio(context, 2, "Surface Phone", "desc", true);
            AddAnuncio(context, 2, "Xbox", "desc", false);

            AddAnuncio(context, 3, "Diskette 360Kb", "desc", false);
            AddAnuncio(context, 3, "MSX", "desc", false);
            AddAnuncio(context, 3, "Telefone de Mesa", "desc", false);
            AddAnuncio(context, 3, "Máquina de Escrever", "desc", true);

            context.SaveChanges();
        }

        private static int _seletorAnunciante = 1;
        private static int _seletorImage = 1;
        private static int _idAnuncios = 1;
        private static Random _random = new Random();

        private void AddAnuncio(DBContext context, int idCategoria, string titulo, string desc, bool gold) {
            context.Anuncios.AddOrUpdate(new Anuncio {
                ID = _idAnuncios++,
                IdAnunciante = (_seletorAnunciante++ % 3) + 1,
                IdCategoria = idCategoria,
                Descricao = desc,
                Titulo = titulo,
                Gold = gold,
                DtCadastro = DateTime.Today,
                Preco = _random.Next(100,1000),
                Imagem = _seletorImage++ + ".jpg"
            });
        }

        private static void CrieCategorias(DBContext context) {
            var cats = new[] {"Novidades", "Eletrônicos", "Clássicos"};
            for (int i = 0; i < 3; i++) {
                context.Categorias.AddOrUpdate(new Categoria { IdCategoria = i + 1, NomeCategoria = cats[i] });
            }
        }

        private static void CrieAnunciantes(DBContext context) {
            var nomes = new[] {"Otávio Araujo Alves", "Kai Rodrigues Silva", "Marcos Cavalcanti Ferreira"};
            var emails = new[] {"OtvioAraujoAlves@mailinator.com", "KaiRodriguesSilva@mailinator.us", "MarcosCavalcantiFerreira@mailinator.com"};
            var telefones = new[] {"(16) 5555-3805", "(81) 5555-5285", "(32) 5555-6523"};

            for (int i = 0; i < 3; i++) {
                context.Anunciantes.AddOrUpdate(new Anunciante {
                    IdAnunciante = i+1,
                    Nome = nomes[i],
                    Email = emails[i],
                    Telefone = telefones[i]
                });
            }
        }
    }
}
