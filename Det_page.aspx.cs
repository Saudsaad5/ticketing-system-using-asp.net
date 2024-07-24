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
    public partial class Det_page : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=ONYX\SAUD;Initial Catalog=LEARNING;Persist Security Info=True;User ID=saud;Password=abcd");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
               // test.Text = Session["viewbaseonreq"].ToString();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                disp_data();
            }

        }
        public void disp_data()
        {
            String reqid = Session["viewbaseonreq"].ToString();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from requests where req_id = @req_id";
            cmd.Parameters.AddWithValue("@req_id", reqid);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("reqlist.aspx");
        }
    }
}