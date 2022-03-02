using ProyectoBack.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Infrastructure.Bussiness
{
    public class db
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-I95D9JN\\SQLEXPRESS;Initial Catalog=CSHARSPACE;User Id=sa;Password=sql");

        public string EmployeeOpt(Employee emp) 
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("SP_EMPLOYEE", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", emp.ID);
                com.Parameters.AddWithValue("@EMAIL", emp.EMAIL);
                com.Parameters.AddWithValue("@EMP_NAME", emp.EMP_NAME);
                com.Parameters.AddWithValue("@DESIGNATION", emp.DESIGNATION);
                com.Parameters.AddWithValue("@TYPE", emp.TYPE);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            finally 
            {
                if (con.State == ConnectionState.Open) 
                {
                    con.Close();
                }
            }

            return msg;
        }

        public DataSet EmployeeGet(Employee emp, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("SP_EMPLOYEE", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", emp.ID);
                com.Parameters.AddWithValue("@EMAIL", emp.EMAIL);
                com.Parameters.AddWithValue("@EMP_NAME", emp.EMP_NAME);
                com.Parameters.AddWithValue("@DESIGNATION", emp.DESIGNATION);
                com.Parameters.AddWithValue("@TYPE", emp.TYPE);

                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "Success";

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }
    }
}
