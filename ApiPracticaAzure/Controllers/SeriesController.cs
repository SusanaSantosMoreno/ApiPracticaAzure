using ApiPracticaAzure.Models;
using ApiPracticaAzure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPracticaAzure.Controllers {

    [Route("api/")]
    [ApiController]
    public class SeriesController : ControllerBase {

        public RepositorySeries repository;

        public SeriesController(RepositorySeries repo) { this.repository = repo; }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<Serie>> getSeries () {
            return this.repository.GetSeries();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult<Serie> getSerie (int id) {
            return this.repository.GetSerie(id);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<Personaje>> getPersonajes () {
            return this.repository.GetPersonajes();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult<Personaje> getPersonaje (int id) {
            return this.repository.GetPersonaje(id);
        }


        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult<List<Personaje>> getPersonajesSerie (int id) {
            return this.repository.GetPersonajeSerie(id);
        }

        [HttpPost]
        [Route("[action]")]
        public void insertarPersonaje (Personaje personaje) {
            this.repository.insertPersonaje(personaje.Nombre, personaje.Imagen, personaje.IdSerie);
        }

        [HttpPut]
        [Route("[action]/{idPersonaje}/{idSerie}")]
        public void CambiarPersonajeSerie (String idPersonaje, String idSerie) {
            this.repository.CambiarPersonajeSerie(int.Parse(idPersonaje), int.Parse(idSerie));
        }
    }
}
