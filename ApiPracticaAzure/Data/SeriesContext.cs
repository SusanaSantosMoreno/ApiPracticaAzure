using ApiPracticaAzure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPracticaAzure.Data {
    public class SeriesContext: DbContext {

        public SeriesContext (DbContextOptions<SeriesContext> options) : base(options) { }

        public DbSet<Serie> Series { get; set; }
        public DbSet<Personaje> Personajes { get; set; }
        public DbSet<UsuariosAzure> Usuarios { get; set; }

    }
}
