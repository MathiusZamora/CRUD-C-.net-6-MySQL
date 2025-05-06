using System;
using System.Collections.Generic;
using System.Linq;
using EL;

namespace DAL
{
    public static class DAL_Permisos
    {
        public static Permisos Insert(Permisos Entidad)
        {
            using (BDInventario bd = new BDInventario())
            {
                Entidad.Activo = true;
                Entidad.FechaRegistro = DateTime.Now;
                bd.Permisos.Add(Entidad);
                bd.SaveChanges();
                return Entidad;
            }
        }
        public static bool Update(Permisos Entidad)
        {
            using (BDInventario bd = new BDInventario())
            {
                var Registro = bd.Permisos.Find(Entidad.IdPermiso);
                Registro.Permiso = Entidad.Permiso;
                Registro.IdUsuarioActualiza = Entidad.IdUsuarioActualiza;
                Registro.FechaActualizacion = Entidad.FechaActualizacion;
                return bd.SaveChanges() > 0;
            }
        }
        public static bool Anular(Permisos Entidad)
        {
            using (BDInventario bd = new BDInventario())
            {
                var Registro = bd.Permisos.Find(Entidad.IdPermiso);
                Registro.Activo = Entidad.Activo;
                Registro.IdUsuarioActualiza = Entidad.IdUsuarioActualiza;
                Registro.FechaActualizacion = Entidad.FechaActualizacion;
                return bd.SaveChanges() > 0;
            }
        }
        public static bool Existe(Permisos Entidad)
        {
            using (BDInventario bd = new BDInventario())
            {
                return bd.Permisos.Where(a => a.IdPermiso == Entidad.IdPermiso).Count() > 0;
            }
        }
        public static Permisos Registro(Permisos Entidad)
        {
            using (BDInventario bd = new BDInventario())
            {
                return bd.Permisos.Where(a => a.IdPermiso == Entidad.IdPermiso).SingleOrDefault();
            }
        }
        public static List<Permisos> Lista(bool Activo = true)
        {
            using (BDInventario bd = new BDInventario())
            {
                return bd.Permisos.Where(a => a.Activo == Activo).ToList();
            }
        }
    }
}