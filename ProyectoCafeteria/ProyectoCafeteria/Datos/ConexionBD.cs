/*
 * CLASE TEMPORAL DE CONEXION AL FINAL ESTA CLASE NO SE DEBE USAR Y SE DEBE ELIMINAR YA QUE DEBE SER CONEXION HTTP A LA API
 */ 

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCafeteria.Datos
{
    public class ConexionBD
    {
        private string nombreBaseDatos;
        private string nombreServidor;
        private string nombreUsuarioBaseDatos;
        private string nombrePasswordUsuarioBaseDatos;
        private bool configuracionSeguridad;
        private static ConexionBD singletonConexion = null;

        private ConexionBD()
        {
            this.nombreBaseDatos = "DBCafeteriaFEI";
            this.nombreServidor = "HP-ENVY-GRIS\\SQLEXPRESS";
            this.nombreUsuarioBaseDatos = "YasserAdminDB";
            this.nombrePasswordUsuarioBaseDatos = "*Yasser-SQLSERVER!*";
            this.configuracionSeguridad = true;
        }

        public SqlConnection CrearConexion()
        {
            SqlConnection cadenaConexion = new SqlConnection();
            try
            {
                cadenaConexion.ConnectionString = "Server=" + this.nombreServidor + "; Database=" + this.nombreBaseDatos + ";";
                if (this.configuracionSeguridad)
                {
                    cadenaConexion.ConnectionString = cadenaConexion.ConnectionString + "Integrated Security = SSPI";
                }
                else
                {
                    cadenaConexion.ConnectionString = cadenaConexion.ConnectionString + "User Id=" + this.nombreUsuarioBaseDatos + ";Password=" + this.nombrePasswordUsuarioBaseDatos;
                }
            }
            catch (Exception ex)
            {
                cadenaConexion = null;
                throw ex;
            }
            return cadenaConexion;
        }

        public static ConexionBD getInstanciaSingleton()
        {
            if (singletonConexion == null)
            {
                singletonConexion = new ConexionBD();
            }
            return singletonConexion;
        }
    }
}
