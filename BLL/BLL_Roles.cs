using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class BLL_Roles
    {
        //control k control d para acomodar el codigo

        //Insertar
        public static Roles Insert(Roles Entidad)
        {

            return DAL_Roles.Insert(Entidad);
        }

        //Actualizar
        public static bool Update(Roles Entidad)
        {
            return DAL_Roles.Update(Entidad);

        }

        //Anular
        public static bool Delete(Roles Entidad)
        {
            return DAL_Roles.Delete(Entidad);

        }

        //Seleccionar un Registro
        public static Roles Registro(short IdRegistro)
        {
            return DAL_Roles.Registro(IdRegistro);

        }

        //Listar todos los registros
        public static List<Roles> Listar(bool Activo = true)
        {
            return DAL_Roles.Listar(Activo);

        }
    }
}
