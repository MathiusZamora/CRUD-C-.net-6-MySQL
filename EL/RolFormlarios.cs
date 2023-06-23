using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EL
{
    [Table("RolFormlarios")]
    public class RolFormlarios
    {  
        [Key]
        public int IdRolFormulario { get; set; }
        [Required]
        public short IdRol { get; set; }
        [Required]
        public int IdFormulario { get; set; }
        [Required]
        public bool Activo { get; set; }
        [Required]
        public int IdUsuarioRegistra { get; set; }
        [Required]
        public DateTime FechaRegistro { get; set; }
        public int? IdUsuarioActualiza { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
