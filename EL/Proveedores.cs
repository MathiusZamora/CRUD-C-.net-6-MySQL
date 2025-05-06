using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    [Table("Proveedores")]

    public class Proveedores
    {

        [Key]
        public int IdProveedor { get; set; }

        [MaxLength(200), Required]
        public string NombreProveedor { get; set; }

        [MaxLength(10), Required]
        public string Numero { get; set; }

        [MaxLength(200), Required]
        public string Correo { get; set; }

        [MaxLength(200), Required]
        public string Direccion { get; set; }

        [Required]
        public bool Activo { get; set; }

        [Required]
        public int IdUsuarioRegistra { get; set; }
        [Required]
        public DateTime FechaRegistro { get; set; }
        public int? IdUsuarioActualiza { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public Proveedores()
        {
            NombreProveedor= string.Empty;
            Numero= string.Empty;
            Correo= string.Empty;
            Direccion = string.Empty;

        }

    }
}
