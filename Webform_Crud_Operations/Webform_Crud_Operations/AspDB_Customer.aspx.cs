using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webform_Crud_Operations
{
    public partial class AspDB_Customer : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ReadCS.ASPDB);
            cmd = new SqlCommand();
            cmd.Connection = con;
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        private void LoadData()
        {
            cmd.CommandText = "Select Custid,Name,Balance,City,Status From Customer Where Status=1 Order By Custid";
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                
            }
            SqlDataReader dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            con.Close();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            LoadData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            LoadData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int Custid = int.Parse(GridView1.Rows[e.RowIndex].Cells[0].Text);
                string Name = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
                decimal Balance = decimal.Parse(((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text);
                string City = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
                cmd.CommandText =
               $"Update Customer Set Name='{Name}', Balance={Balance}, City='{City}' Where Custid={Custid}";
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    GridView1.EditIndex = -1;
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message.Replace("'", "") + "')</script>");
            }
            finally
            {
                con.Close();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int Custid = int.Parse(GridView1.Rows[e.RowIndex].Cells[0].Text);
                cmd.CommandText = $"Update Customer Set Status=0 Where Custid={Custid}";
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message.Replace("'", "") + "')</script>");
            }
            finally
            {
                con.Close();
            }
        }
    }
}