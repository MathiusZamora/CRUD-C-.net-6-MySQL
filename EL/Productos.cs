using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    [Table("Productos")]
    public class Productos
    {
        [Key]
        public int IdProducto { get; set; }

        [MaxLength(200), Required]
        public string Descripcion { get; set; }

        [MaxLength(8), Required]
        public string Cantidad { get; set; }

        public bool Activo { get; set; }

        [Required]
        public int IdUsuarioRegistra { get; set; }

        [Required]
        public DateTime FechaRegistro { get; set; }

        public int? IdUsuarioActualiza { get; set; }

        public DateTime? FechaActualizacion { get; set; }

        // Nueva propiedad para IdProveedor
        [Required]
        public int IdProveedor { get; set; }

        // Relación con la entidad Proveedores
        [ForeignKey("IdProveedor")]
        public virtual Proveedores Proveedor { get; set; }

        public Productos()
        {
            Descripcion = string.Empty;
            Cantidad = string.Empty;
        }
    }
}
