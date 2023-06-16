using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int IdRol { get; set; }
        public int IdUsuarioRegistra { get; set; }
        public int FechaRegistro { get; set; }
        public int IdUsuarioActualiza { get; set; }
        public int FechaActualizacion { get; set; }
    }
}
