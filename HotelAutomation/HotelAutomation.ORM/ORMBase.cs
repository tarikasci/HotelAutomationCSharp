using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HotelAutomation.ORM
{
    public class ORMBase<TT> : IORM<TT> where TT : class
    {
        public bool Delete(TT entity)
        {
            return Tools.InsertUpdateDelete("Delete", entity);
        }

        public bool Insert(TT entity)
        {
            return Tools.InsertUpdateDelete<TT>("Insert",entity);
        }
        public bool Update(TT entity)
        {
            return Tools.InsertUpdateDelete<TT>("Update", entity);
        }
        public DataTable Select()
        {
            SqlDataAdapter adp = new SqlDataAdapter(string.Format("prc_{0}_Select", typeof(TT).Name), Tools.Connection);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public object InsertScalar(TT entity)
        {
            Type getType = typeof(TT);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = string.Format("prc_{0}_Insert", getType.Name);
            cmd.Connection = Tools.Connection;
            cmd.CommandType = CommandType.StoredProcedure;
            PropertyInfo[] properties = getType.GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                string prmName = "@" + pi.Name;
                object prmValue = pi.GetValue(entity);
                cmd.Parameters.AddWithValue(prmName, prmValue);
            }
            return Tools.ExecuteScalar(cmd);
        }
    }
}
