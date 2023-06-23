using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EL
{
    [Table("usuarios")]
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        [MaxLength(200)]
        [Required]
        public string NombreCompleto { get; set; }
        [MaxLength(200)]
        [Required]
        public string Correo { get; set; }
        [MaxLength(50)]
        [Required]
        public string UserName { get; set; }
        [Required]
        public byte[] Password { get; set; }
        [Required]
        public bool Bloqueado { get; set; }
        [Required]
        public byte[] IntentosFallidos { get; set; }
        public short? IdRol { get; set; }
        [Required]
        public bool Activo { get; set; }
        [Required]
        public int IdUsuarioRegistra { get; set; }
        [Required]
        public DateTime FechaRegistro { get; set; }
        public int? IdUsuarioActualiza { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public Usuarios()
        {
            NombreCompleto = string.Empty;
            Correo = string.Empty;
            UserName = string.Empty;
            Password = UTF8Encoding.UTF8.GetBytes(string.Empty);
        }
    }
}
