using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPracticaAzure.Models {
    [Table("SERIES")]
    public class Serie {

        [Key]
        [Column("IDSERIE")]
        public int IdSerie { get; set; }

        [Column("SERIE")]
        public String Nombre { get; set; }

        [Column("IMAGEN")]
        public String Imagen { get; set; }

        [Column("PUNTUACION")]
        public double Puntuacion { get; set; }

        [Column("AÑO")]
        public int Annio { get; set; }

        public Serie () { }

        public Serie (int idSerie, string nombre, 
            string imagen, float puntuacion, int annio) {
            IdSerie = idSerie;
            Nombre = nombre;
            Imagen = imagen;
            Puntuacion = puntuacion;
            Annio = annio;
        }
    }
}
