using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CrudOperations
{
    public partial class ASPDB_Customer_GridView_Editing : System.Web.UI.Page
    {
        Customer obj = new Customer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        private void LoadData()
        {
            GridView1.DataSource = obj.Customer_Select(null, true);
            GridView1.DataBind();
        }

        protected void Page_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            Server.ClearError();
            Response.Write("<script> alert('" + ex.Message.Replace("'", "") + "'</script>");
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
            int Custid = int.Parse(GridView1.Rows[e.RowIndex].Cells[0].Text);
            string Name = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            decimal Balance = decimal.Parse(((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text);
            string City = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            if (obj.Customer_Update(Custid, Name, Balance, City) > 0)
            {
                GridView1.EditIndex = -1;
                LoadData();
            }
            else
            {
                Response.Write("<script>alert('Failed Updating the record in table ')</script>");
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Custid = int.Parse(GridView1.Rows[e.RowIndex].Cells[0].Text);
            if (obj.Customer_Delete(Custid) > 0)
            {
                LoadData();
            }
            else
            {
                Response.Write("<script>alert('Failed Deleting the record From table ')</script>");
            }
        }
    }
}