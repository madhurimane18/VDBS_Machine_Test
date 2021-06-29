using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;


namespace VDBS_TEST
{

    public partial class CompanyView : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataUpload();
        }

        public void DataUpload()
        {

            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select ID,Name,Status from CompanyMaster", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Companymaster.DataSource = dt;
            Companymaster.DataBind();
        }

        protected void lnkshow_Click(object sender, EventArgs e)
        {

        }
    
        protected void lnkshow_Click1(object sender, EventArgs e)
        {
          
        }

        protected void lnkApprove_Click(object sender, EventArgs e)
        {

        }

        protected void lnkDisApprove_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow gvr = lnk.NamingContainer as GridViewRow;

            Label lbl_n = gvr.FindControl("lbl_Name") as Label;
           
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandText = "UPDATE [CompanyMaster] set [Status]= '1' where [Name] ='" + lbl_n.Text + "'";
            con.Open();
            cmd1.ExecuteNonQuery();
            con.Close();

            DataUpload();

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow gvr = lnk.NamingContainer as GridViewRow;

            Label lbl_n = gvr.FindControl("lbl_Name") as Label;
           
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandText = "UPDATE [CompanyMaster] set [Status]= '0' where [Name] ='" + lbl_n.Text + "'";
            con.Open();
            cmd1.ExecuteNonQuery();
            con.Close();


            DataUpload();
        }

        protected void Companymaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = e.Row.Cells[0].Text;
                if (status == "0")
                {
                    Label lbl_n = (e.Row.FindControl("lbl_Name") as Label);
                    lbl_n.Enabled = false;
                }
            }
        }

        protected void Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ComapnyMaster.aspx");
        }
    }
}