using EL;
using System.IO.Pipes;

namespace DAL
{
    public static class DAL_Proveedores
    {
        public static Proveedores Insert(Proveedores Entidad)
        {
            using (BDInventario bd = new BDInventario())
            {
                Entidad.Activo = true;
                Entidad.FechaRegistro = DateTime.Now;
                bd.Proveedores.Add(Entidad);
                bd.SaveChanges();
                return Entidad;
            }
        }
        public static bool Update(Proveedores Entidad)
        {
            using (BDInventario bd = new BDInventario())
            {
                var Registro = bd.Proveedores.Find(Entidad.IdProveedor);

                Registro.NombreProveedor = Entidad.NombreProveedor;
                Registro.Numero = Entidad.Numero;
                Registro.Correo = Entidad.Correo;
                Registro.Direccion = Entidad.Direccion;
                Registro.IdUsuarioActualiza = Entidad.IdUsuarioActualiza;
                Registro.FechaActualizacion = Entidad.FechaActualizacion;
                return bd.SaveChanges() > 0;
            }
        }
        public static bool Anular(Proveedores Entidad)
        {
            using (BDInventario bd = new BDInventario())
            {
                var Registro = bd.Proveedores.Find(Entidad.IdProveedor);
                Registro.Activo = false;
                Registro.IdUsuarioActualiza = Entidad.IdUsuarioActualiza;
                Registro.FechaActualizacion = DateTime.Now;
                return bd.SaveChanges() > 0;
            }
        }
        public static bool Existe(Proveedores Entidad)
        {
            using (BDInventario bd = new BDInventario())
            {
                return bd.Proveedores.Where(a => a.IdProveedor == Entidad.IdProveedor).Count() > 0;
            }
        }
        public static Proveedores Registro(Proveedores Entidad)
        {
            using (BDInventario bd = new BDInventario())
            {
                return bd.Proveedores.Where(a => a.IdProveedor == Entidad.IdProveedor).SingleOrDefault();
            }
        }
        public static List<Proveedores> Lista(bool Activo = true)
        {
            using (BDInventario bd = new BDInventario())
            {
                return bd.Proveedores.Where(a => a.Activo == Activo).ToList();
            }
        }


        public static bool ValidarNumeroProv(string Numero, int IdRegistro)
        {
            using (BDInventario bd = new())
            {
                return bd.Proveedores.Where(a => a.Numero == Numero && a.IdProveedor != IdRegistro && a.Activo == true).Count() > 0;
            }
        }
        public static bool ValidarCorreoProv(string Email, int IdRegistro)
        {
            using (BDInventario bd = new())
            {
                return bd.Proveedores.Where(a => a.Correo == Email && a.IdProveedor != IdRegistro && a.Activo == true).Count() > 0;
            }
        }
        public static bool ValidarDireccionProv(string Direccion, int IdRegistro)
        {
            using (BDInventario bd = new())
            {
                return bd.Proveedores.Where(a => a.Direccion == Direccion && a.IdProveedor != IdRegistro && a.Activo == true).Count() > 0;
            }
        }

    }
}