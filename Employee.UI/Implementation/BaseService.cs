using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Employee.UI.Implementation
{
    public class BaseService
    {
        protected string ConnectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;

        protected bool ExecuteNonQuery(string command, CommandType commandType)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(command, con))
                    {
                        cmd.CommandType = commandType;

                        int result = cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }


        protected DataTable ExecuteReader(string command, CommandType commandType)
        {
            try
            {
                DataTable dtResult = null;
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(command, con))
                    {
                        cmd.CommandType = commandType;

                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            dtResult = new DataTable();
                            dtResult.Load(dr);
                        }
                    }
                }
                return dtResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
    }
}