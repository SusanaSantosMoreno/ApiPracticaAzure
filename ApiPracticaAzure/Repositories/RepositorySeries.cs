using ApiPracticaAzure.Data;
using ApiPracticaAzure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPracticaAzure.Repositories {
    public class RepositorySeries {

        public SeriesContext context;

        public RepositorySeries(SeriesContext context) { this.context = context; }

        public List<Serie> GetSeries () {
            return this.context.Series.ToList();
        } 

        public List<Personaje> GetPersonajes () {
            return this.context.Personajes.ToList();
        }

        public Serie GetSerie(int idSerie) {
            return this.context.Series.SingleOrDefault(x => x.IdSerie == idSerie);
        }

        public Personaje GetPersonaje (int idPersonaje) {
            return this.context.Personajes.SingleOrDefault(x => x.IdPersonaje == idPersonaje);
        }

        public List<Personaje> GetPersonajeSerie (int idSerie) {
            return this.context.Personajes.Where(x => x.IdSerie == idSerie).ToList();
        }

        public int GetMaxId () {
            return (this.context.Personajes.
                OrderByDescending(x => x.IdPersonaje).FirstOrDefault().IdPersonaje) + 1;
        }

        public void insertPersonaje (String nombre, String imagen, int idSerie) {
            Personaje personaje = new Personaje(this.GetMaxId(), nombre, imagen, idSerie);
            this.context.Personajes.Add(personaje);
            this.context.SaveChanges();
        }

        public void CambiarPersonajeSerie (int idPersonaje, int idSerie) {
            Personaje personaje = this.GetPersonaje(idPersonaje);
            personaje.IdSerie = idSerie;
            this.context.SaveChanges();
        }
    }
}
