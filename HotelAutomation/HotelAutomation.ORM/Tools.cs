using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HotelAutomation.ORM
{
    public class Tools
    {
		//Singleton Pattern
		private static SqlConnection connection;
		public static SqlConnection Connection
		{
			get 
			{
				if (connection == null)
				{
					connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
				}
				return connection; 
			}
		}
        public static bool ExecuteNonQuery(SqlCommand cmd)
        {
            try
            {
                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }
                int affectedRows = cmd.ExecuteNonQuery();
                return affectedRows > 0 ? true : false;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                {
                    cmd.Connection.Close();
                }
            }
        }
        public static bool InsertUpdateDelete<T>(string procType, T entity)
        {
            Type getType = typeof(T);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = string.Format("prc_{0}_{1}", getType.Name, procType);
            cmd.Connection = Tools.Connection;
            cmd.CommandType = CommandType.StoredProcedure;
            PropertyInfo[] properties = getType.GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                //No need to pass id because I already included it to the sql proc as a parameter but excluded it from insert query
                //so sending it as a parameter with null value won't be a problem. Also it will be possible to write only one method to use both
                //update and insert(id will be needed in update querys)
                string prmName = "@" + pi.Name;                 
                object prmValue = pi.GetValue(entity);
                cmd.Parameters.AddWithValue(prmName, prmValue);
            }
            return Tools.ExecuteNonQuery(cmd);
        }
        public static object ExecuteScalar(SqlCommand cmd)
        {
            try
            {
                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }
                return cmd.ExecuteScalar(); //returns the id
            }
            catch (Exception)
            {

                return 0;
            }

            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                {
                    cmd.Connection.Close();
                }
            }
        }
    }
}
