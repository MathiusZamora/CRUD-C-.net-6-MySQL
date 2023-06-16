using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class Permisos
    {
        public int IdPermiso { get; set; }
        public string Permiso { get; set; }
        public int IdUsuarioRegistra { get; set; }
        public int FechaRegistro { get; set; }
        public int IdUsuarioActualiza { get; set; }
        public int FechaActualizacion { get; set; }
    }
}
