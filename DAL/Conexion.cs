using System.Data.SqlClient;

namespace DAL
{
    public static class Conexion
    {
        private static string NombreAplicacion = " ";
        private static string Servidor = " ";
        private static string Usuario = " ";
        private static string Password = " ";
        private static string BaseDatos = "MPOO";

        public static string ConexionString(bool SqlAutentication = true)
        {
            SqlConnectionStringBuilder Constructor = new SqlConnectionStringBuilder()
            {
                ApplicationName = NombreAplicacion,
                IntegratedSecurity = !SqlAutentication,
                DataSource = Servidor,
                InitialCatalog = BaseDatos
            };
            if (SqlAutentication)
            {
                Constructor.UserID = Usuario;
                Constructor.Password = Password;
            }
            return Constructor.ConnectionString;
        }
    }
}
