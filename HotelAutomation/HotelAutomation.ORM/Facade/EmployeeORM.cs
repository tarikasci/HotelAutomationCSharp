using HotelAutomation.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAutomation.ORM.Facade
{
    public class EmployeeORM : ORMBase<Employees>
    {
        public static Employees ActiveUser;
        public Employees Login(Employees emp)
        {
            SqlDataAdapter adp = new SqlDataAdapter("prc_Employees_Login",Tools.Connection);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.AddWithValue("@un",emp.UserName);
            adp.SelectCommand.Parameters.AddWithValue("@pwd",emp.Password);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            Employees isActive = new Employees();
            foreach (DataRow dr in dt.Rows)
            {
                isActive.Id = (int)dr["Id"];
                isActive.Name = dr["Name"].ToString();
                isActive.Surname = dr["Surname"].ToString();
                isActive.UserName = dr["UserName"].ToString();
                isActive.Password = dr["Password"].ToString();
            }
            return isActive;
        }
    }
}
