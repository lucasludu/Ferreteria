using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.Business
{
    /// <summary>
    /// Establece cadena de conexión a usar por el EF
    /// </summary>
    public static class StringConnection
    {
        private static ConnectionStringSettings defaultConnection;

        /// <summary>
        /// Contiene los settings del app.config
        /// </summary>
        private static NameValueCollection AppSettings; 

        /// <summary>
        /// Contiene la cadena de conexión correspondiente al EF tomada por stringconnection.config
        /// </summary>
        private static readonly EntityConnectionStringBuilder EntityConnectionSB = new EntityConnectionStringBuilder();


        public static void InicializarConexion()
        {
            LoadConfig();
        }


        /// <summary>
        /// Carga las configuraciones del app.config y stringconnection para armar la cadena de conexión
        /// </summary>
        private static void LoadConfig()
        {
            ConfigurationManager.RefreshSection("appSettings");
            AppSettings = ConfigurationManager.AppSettings;

            defaultConnection = ConfigurationManager.ConnectionStrings[GetClave("StringConnectionFerreteria")];
            EntityConnectionSB.ConnectionString = defaultConnection.ConnectionString;

        }


        /// <summary>
        /// Devuelve un string con la cadena de conexión correspondiente a la clave indicada. 
        /// Busca la clave dentro de la sección "appSettings" del app.config
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string GetClave(string key)
        {
            return AppSettings != null
                ? AppSettings[key]
                : string.Empty;
        }


        /// <summary>
        /// Cadena de conexión tomada del stringconnection.config en el formato necesario para EF
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                if(EntityConnectionSB.ConnectionString == null || EntityConnectionSB.ConnectionString == string.Empty)
                {
                    LoadConfig();
                }
                return EntityConnectionSB.ConnectionString;
            }
        }

        /// <summary>
        /// Devuelve el server correspondiente a la cadena de conexión actual
        /// </summary>
        public static string Server
        {
            get
            {
                var stringConnection = ConnectionString.Split(';').ToList();
                var cadenaConDataSource = stringConnection.Find(s => s.Contains("Server"));
                return cadenaConDataSource == null
                    ? string.Empty
                    : cadenaConDataSource.Split('=').Last().Split('"').First().ToUpper();
            }
        }


        public static string BaseDeDatos
        {
            get
            {
                var stringConnection = ConnectionString.Split(';').ToList();
                var cadenaInitialCatalog = stringConnection.Find(s => s.Contains("Database"));
                return cadenaInitialCatalog == null ? string.Empty : cadenaInitialCatalog.Split('=').Last();
            }
        }




        /// <summary>
		/// Devuelve el query en formato EF SQL correspondiente a una consulta LinQ.
		/// </summary>
		/// <param name="query">Query a analizar (sin materializar).</param>
		/// <returns>Un string que representa el comando a ejecutar a través del data source.</returns>
		public static string GetTraceSQL(IQueryable query)
        {
            return ((ObjectQuery)query).ToTraceString();
        }

    }
}
