using EL;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DAL
{
    public class BDMPOO : DbContext
    {
        public BDMPOO() : base(Conexion.ConexionString(false)) { }

        public virtual DbSet<Formularios>? Formularios { get; set; }
        public virtual DbSet<Permisos>? Permisos { get; set; }
        public virtual DbSet<Roles>? Roles { get; set; }
        public virtual DbSet<RolFormlarios>? RolFormlarios { get; set; }
        public virtual DbSet<RolPermisos>? RolPermisos { get; set; }
        public virtual DbSet<Usuarios>? Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Formularios>().Property(e => e.Formulario).IsUnicode(false);
            modelBuilder.Entity<Permisos>().Property(e => e.Permiso).IsUnicode(false);
            modelBuilder.Entity<Roles>().Property(e => e.Rol).IsUnicode(false);
            modelBuilder.Entity<Usuarios>().Property(e => e.NombreCompleto).IsUnicode(false);
            modelBuilder.Entity<Usuarios>().Property(e => e.Correo).IsUnicode(false);
            modelBuilder.Entity<Usuarios>().Property(e => e.UserName).IsUnicode(false);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
