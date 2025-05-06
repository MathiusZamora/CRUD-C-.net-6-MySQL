using EL;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace DAL
{
    public class BDInventario : DbContext
    {
        public BDInventario() : base(Conexion.ConexionString()) { }
        public virtual DbSet<Formularios>? Formularios { get; set; }
        public virtual DbSet<Permisos>? Permisos { get; set; }
        public virtual DbSet<Roles>? Roles { get; set; }
        public virtual DbSet<RolFormularios>? RolFormularios { get; set; }
        public virtual DbSet<RolPermisos>? RolPermisos { get; set; }
        public virtual DbSet<Usuarios>? Usuarios { get; set; }
        public virtual DbSet<Clientes>? Clientes { get; set; }
        public virtual DbSet<Productos>? Productos { get; set; }
        public virtual DbSet<Proveedores>? Proveedores { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Formularios>().Property(e => e.Formulario).IsUnicode(false);
            modelBuilder.Entity<Permisos>().Property(e => e.Permiso).IsUnicode(false);
            modelBuilder.Entity<Roles>().Property(e => e.Rol).IsUnicode(false);
            modelBuilder.Entity<Usuarios>().Property(e => e.NombreCompleto).IsUnicode(false);
            modelBuilder.Entity<Usuarios>().Property(e => e.Correo).IsUnicode(false);
            modelBuilder.Entity<Usuarios>().Property(e => e.UserName).IsUnicode(false);
            modelBuilder.Entity<Clientes>().Property(e => e.NombreCliente).IsUnicode(false);
            modelBuilder.Entity<Clientes>().Property(e => e.Correo).IsUnicode(false);
            modelBuilder.Entity<Productos>().Property(e => e.Descripcion).IsUnicode(false);
            modelBuilder.Entity<Proveedores>().Property(e => e.NombreProveedor).IsUnicode(false);
            modelBuilder.Entity<Proveedores>().Property(e => e.Correo).IsUnicode(false);



            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

        }
    }
}
