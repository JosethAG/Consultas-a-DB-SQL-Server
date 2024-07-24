using System.Runtime;
//Se incorporan pra el manejo de datos y conexión con la DB
//Se debe de implementar el nugget sqlclient
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Text.Json;

namespace ConexionesDB.Architectur
{
    public class Conection
    {
        /*String de conexión para la base de datos
        Data Source=Nombre_de_Conexión;Initial Catalog=Nombre_de_la_DB;Integrated Security=True;
        */
        public static string connectionString = "Data Source=LOCALHOST;Initial Catalog=UsersDB;Integrated Security=True;";

        /*Conexión para ejecusión de SP de Bases de datos con devolución de una lista
         Incorporado el 24/7/24 por Joseth Araya
         */
        public static DataTable ExcSPList(string SPName, List<Parameter> parameters = null)
        {
            SqlConnection conn = new SqlConnection(connectionString); //Se establece el connectionString como un sqlConnection

            try
            {
                conn.Open(); //Se abre la conexión
                SqlCommand cmd = new SqlCommand(SPName, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //En caso de que el mismo requiera parámetros se agregan a la consulta
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.AddWithValue(parameter.Name, parameter.Value);
                    }
                }
                DataTable table = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(table);

                return table;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        /*Conexión para ejecusión de SP de Bases de datos con devolución de booleano ((Verdadero o falso)
         Incorporado el 24/7/24 por Joseth Araya
         */
        public static bool Execute(string SPName, List<Parameter> parameters = null)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open(); //Se abre la conexión
                SqlCommand cmd = new SqlCommand(SPName, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //En caso de que el mismo requiera parámetros se agregan a la consulta
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.AddWithValue(parameter.Name, parameter.Value);
                    }
                }

                int rowsAffected = cmd.ExecuteNonQuery(); //Indica la cantidad de líneas afectadas

                return rowsAffected > 0; //De editar alguna línea su repuesta será verdadero
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
