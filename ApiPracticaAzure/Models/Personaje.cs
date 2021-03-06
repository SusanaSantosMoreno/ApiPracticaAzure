using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPracticaAzure.Models {
    [Table("PERSONAJES")]
    public class Personaje {

        [Key]
        [Column("IDPERSONAJE")]
        public int IdPersonaje { get; set; }

        [Column("PERSONAJE")]
        public String Nombre { get; set; }

        [Column("IMAGEN")]
        public String Imagen { get; set; }

        [Column("IDSERIE")]
        public int IdSerie { get; set; }

        public Personaje () { }

        public Personaje (int idPersonaje, string nombre, 
            string imagen, int idSerie) {
            IdPersonaje = idPersonaje;
            Nombre = nombre;
            Imagen = imagen;
            IdSerie = idSerie;
        }
    }
}
