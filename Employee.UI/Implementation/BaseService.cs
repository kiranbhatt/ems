using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Employee.UI.Implementation
{
    public class BaseService
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;

        protected bool ExecuteNonQuery(string command, CommandType commandType)
        {
            bool status = false;

            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(command, con))
                    {
                        cmd.CommandType = commandType;

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            status = true;
                        }
                    }
                }
                return status;
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