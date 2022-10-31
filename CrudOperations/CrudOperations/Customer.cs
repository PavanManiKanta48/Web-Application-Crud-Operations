using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace CrudOperations
{
    public class Customer
    {
        SqlCommand cmd;
        SqlConnection con;
        public Customer()
        {
            con = new SqlConnection(ReadCS.ASPDB);
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
        }
        public DataSet Customer_Select(int? Custid, bool? Status)
        {
            DataSet ds;
            try
            {
                cmd.CommandText = "Customer_Select";
                cmd.Parameters.Clear();
                if (Custid != null && Status == null)
                    cmd.Parameters.AddWithValue("@Custid", Custid);
                else if (Custid == null && Status != null)
                    cmd.Parameters.AddWithValue("@Status", Status);
                else if (Custid != null && Status != null)
                {
                    cmd.Parameters.AddWithValue("@Custid", Custid);
                    cmd.Parameters.AddWithValue("@Status", Status);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "Customer");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Customer_Insert(string Name, decimal? Balance, string City, bool? Status, ref int? Custid)
        {
            int Count = 0;
            try
            {
                cmd.CommandText = "Customer_Insert";
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Balance", Balance);
                cmd.Parameters.AddWithValue("@City", City);                
             cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.Add("@Custid", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                Count = cmd.ExecuteNonQuery();
                Custid = Convert.ToInt32(cmd.Parameters["@Custid"].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return Count;
        }
        public int Customer_Update(int? Custid, string Name, decimal? Balance, string City)
        {
            int Count = 0;
            try
            {
                cmd.CommandText = "Customer_Update";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Custid", Custid);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Balance", Balance);
                cmd.Parameters.AddWithValue("@City", City);
                con.Open();
                Count = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return Count;
        }
        public int Customer_Delete(int? Custid)
        {
            int Count = 0;
            try
            {
                cmd.CommandText = "Customer_Delete";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Custid", Custid);
                con.Open();
                Count = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return Count;
        }

    }
}