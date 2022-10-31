using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeCrudOperation
{
    public partial class EmployeeDetails : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=MOBACK;Initial Catalog=Student;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                display();
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            con.Open();
            string str = "insert into EmployeeDetails values('" + txtname.Text + "','" + txtmno.Text + "')";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.ExecuteNonQuery();
            lblmsg.Text = "Record Inserted Successfully";
            con.Close();
            display();
            cleartxt();
        }
        protected void lnkselect_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            Session["id"] = btn.CommandArgument;
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from EmployeeDetails", con);
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            if (dt.Rows.Count >= 0)
            {
                txtname.Text = dt.Rows[0]["name"].ToString();
                txtmno.Text = dt.Rows[0]["mno"].ToString();

            }
            con.Close();
        }
        public void cleartxt()
        {
            txtmno.Text = "";
            txtname.Text = "";
        }
        public void display()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from EmployeeDetails", con);
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            con.Open();
            string str = "update EmployeeDetails set name='" + txtname.Text + "', mno='" + txtmno.Text + "'where empid='" + Session["id"] + "'";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.ExecuteNonQuery();
            lblmsg.Text = "Record Updated Successfully";
            con.Close();
            display();
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from EmployeeDetails where empid='" + Session["id"] + "'", con);
            cmd.ExecuteNonQuery();
            lblmsg.Text = "Record Deleted";
            con.Close();
            display();
        }
    }
}