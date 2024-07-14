using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.NetworkInformation;
using static System.Net.WebRequestMethods;

namespace Requesting_system
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=ONYX\SAUD;Initial Catalog=LEARNING;Persist Security Info=True;User ID=saud;Password=abcd");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();


        }

        protected void save_Button_Click(object sender, EventArgs e)
        {
            
            String priority = DropDownList1.SelectedValue;
            String description = des_Box.Text;
            String details = det_Box.Text;
            int emp_id = Convert.ToInt32(id_Box.Text);
            if (priority == "Select Priority")
            {
                priority_Label.Visible = true;
            }else if(priority != "Select Priority") 
            {
                priority_Label.Visible = false;
            }
            else if (des_Box.Visible == true && des_Box.Text == "")
            {
                priority_Label.Visible = false;
                des_Label.Visible = true;
            }
            else if (det_Box.Text == "")
            {
                des_Label.Visible = false;
                det_Label.Visible = true;
            }
            else
            {
                
                
                    string fileName = Path.GetFileName(FileUpload1.FileName);
                    byte[] fileBytes = FileUpload1.FileBytes;
                
                

                string query = "INSERT INTO requests (priority, desceription, details, employee_id, [file], FileName) " +
                      "VALUES (@Priority, @Description, @Details, @Employee_id, @File, @FileName)";

                using (SqlCommand cmd = new SqlCommand(/*query, con*/))
                {

                    cmd.Connection = con;
                    cmd.CommandText = "insert_req_info";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Priority", priority);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Details", details);
                    cmd.Parameters.AddWithValue("@Employee_id", emp_id);
                    cmd.Parameters.AddWithValue("@File", fileBytes);
                    cmd.Parameters.AddWithValue("@FileName", fileName);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("reqlist.aspx");
                }
            }
           
        }   

       

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String Value = DropDownList1.SelectedValue;
            if (Value == "High Priority")
            {
                des_Box.Visible = true;
                des_text.Visible = true;
            }
            else
            {
                des_Box.Visible = false;
                des_text.Visible = false;
            }
            
        }

        protected void View_Click(object sender, EventArgs e)
        {
            Response.Redirect("reqlist.aspx");
        }
    }
}