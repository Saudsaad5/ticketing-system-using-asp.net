using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Requesting_system
{
    public partial class reqlist : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=ONYX\SAUD;Initial Catalog=LEARNING;Persist Security Info=True;User ID=saud;Password=abcd");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            disp_data();
        }

        protected void back_Button_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("main_page.aspx");
        }
        public void disp_data()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from requests";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}