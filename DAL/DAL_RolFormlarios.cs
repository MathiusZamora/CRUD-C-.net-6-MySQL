using System;
using System.Collections.Generic;
using System.Linq;
using EL;

namespace DAL
{
    public static class DAL_RolFormlarios
    {
        public static RolFormlarios Insert(RolFormlarios Entidad)
        {
            using (BDMPOO bd = new BDMPOO())
            {
                Entidad.Activo = true;
                Entidad.FechaRegistro = DateTime.Now;
                bd.RolFormlarios.Add(Entidad);
                bd.SaveChanges();
                return Entidad;
            }
        }
        public static bool Update(RolFormlarios Entidad)
        {
            using (BDMPOO bd = new BDMPOO())
            {
                var Registro = bd.RolFormlarios.Find(Entidad.IdRolFormulario);
                Registro.IdRol = Entidad.IdRol;
                Registro.IdFormulario = Entidad.IdFormulario;
                Registro.IdUsuarioActualiza = Entidad.IdUsuarioActualiza;
                Registro.FechaActualizacion = Entidad.FechaActualizacion;
                return bd.SaveChanges() > 0;
            }
        }
        public static bool Anular(RolFormlarios Entidad)
        {
            using (BDMPOO bd = new BDMPOO())
            {
                var Registro = bd.RolFormlarios.Find(Entidad.IdRolFormulario);
                Registro.Activo = Entidad.Activo;
                Registro.IdUsuarioActualiza = Entidad.IdUsuarioActualiza;
                Registro.FechaActualizacion = Entidad.FechaActualizacion;
                return bd.SaveChanges() > 0;
            }
        }
        public static bool Existe(RolFormlarios Entidad)
        {
            using (BDMPOO bd = new BDMPOO())
            {
                return bd.RolFormlarios.Where(a => a.IdRolFormulario == Entidad.IdRolFormulario).Count() > 0;
            }
        }
        public static RolFormlarios Registro(RolFormlarios Entidad)
        {
            using (BDMPOO bd = new BDMPOO())
            {
                return bd.RolFormlarios.Where(a => a.IdRolFormulario == Entidad.IdRolFormulario).SingleOrDefault();
            }
        }
        public static List<RolFormlarios> Lista(bool Activo = true)
        {
            using (BDMPOO bd = new BDMPOO())
            {
                return bd.RolFormlarios.Where(a => a.Activo == Activo).ToList();
            }
        }
    }
}