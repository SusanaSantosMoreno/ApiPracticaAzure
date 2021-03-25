using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPracticaAzure.Models {
    [Table("USUARIOSAZURE")]
    public class UsuariosAzure {

        [Key]
        [Column("IDUSUARIO")]
        public int IdUsuario { get; set; }
        [Column("NOMBRE")]
        public String Nombre { get; set; }
        [Column("APELLIDOS")]
        public String Apellidos { get; set; }
        [Column("EMAIL")]
        public String Email { get; set; }
        [Column("PASS")]
        public String Pass { get; set; }

        public UsuariosAzure () {}

        public UsuariosAzure (int idUsuario, string nombre, 
            string apellidos, string email, string pass) {
            IdUsuario = idUsuario;
            Nombre = nombre;
            Apellidos = apellidos;
            Email = email;
            Pass = pass;
        }
    }
}
