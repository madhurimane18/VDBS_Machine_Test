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
       public partial class ComapnyMaster : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Click(object sender, EventArgs e)
        {
            var compid = 0;
            int id = 0;

            if (TextBox1.Text != "")
            {
                try
                {
                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = con;
                    cmd1.CommandText = "Insert into CompanyMaster (Name) values('" + TextBox1.Text + "')";
                    con.Open();
                    cmd1.ExecuteNonQuery();
                    con.Close();


                    SqlConnection con2 = new SqlConnection(cs);
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = con2;
                    cmd2.CommandText = "Select ID From CompanyMaster Where Name= '" + TextBox1.Text + "'";
                    con2.Open();
                    SqlDataReader sdr = cmd2.ExecuteReader();
                    while (sdr.Read())
                    {
                        compid = Convert.ToInt32(sdr["ID"].ToString());
                        id = compid;
                    }
                    con2.Close();
                }
                catch (Exception )
                {

                }
            }
            else
            {
                
            }

            SqlConnection con1 = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con1;
            cmd.CommandText = "Insert Into FileMaster (FileName,Company_ID) values (@name,@comid)";
            con1.Open();
            
            if (FileUpload1.HasFiles)
            {
                foreach (HttpPostedFile fu in FileUpload1.PostedFiles)
                {
                    cmd.Parameters.AddWithValue("@name", fu.FileName);
                    cmd.Parameters.AddWithValue("@comid", id);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        FileUpload1.SaveAs(Path.Combine(Server.MapPath("/Files/"), fu.FileName));
                        cmd.Parameters.Clear();
                    }
                }
            }
            else
            {
                
            }

            ClientScript.RegisterClientScriptBlock(this.GetType(),"Company Master","alert('Record Inserted!..')",true);

            if(TextBox1.Text !="")
            {
               
                    Response.Redirect("CompanyView.aspx");
               
            }
         
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CompanyView.aspx");
        }
    }
}