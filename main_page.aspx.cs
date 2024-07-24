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
        SqlConnection con = new SqlConnection(@"Your Connction String");
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

            string fileName = Path.GetFileName(FileUpload1.FileName);
            string fileExtension = Path.GetExtension(fileName).ToLower();
            int fileSize = FileUpload1.PostedFile.ContentLength;
            byte[] fileBytes = FileUpload1.FileBytes;

            if (String.IsNullOrEmpty(id_Box.Text))
            {
                Error_label.Text = "Please enter your ID.";
                Error_label.Visible = true;
                return;
            }
            if (DropDownList1.SelectedValue == "Select Priority")
            {
                Error_label.Text = "Please select a priority.";
                Error_label.Visible = true;
                return;
            }
            if (DropDownList1.SelectedValue == "High Priority" && String.IsNullOrEmpty(des_Box.Text))
            {
                Error_label.Text = "Please write a description.";
                Error_label.Visible = true;
                return;
            }
            if (DropDownList1.SelectedValue != "High Priority")
            {
                des_Box.Visible = false;
                des_Box.Text= null;
            }
            if (String.IsNullOrEmpty(det_Box.Text))
            {
                Error_label.Text = "Plaese write some details";
                Error_label.Visible = true;
                return;
            }
            if (fileExtension != ".pdf")
            {
                Error_label.Text = "Plaese make sure the file is a pdf file";
                Error_label.Visible = true;
                return;
            }
            if (fileSize > 21000000)
            {
                Error_label.Text = "File must be 21 mb or less";
                Error_label.Visible = true;
            }

                string query = "INSERT INTO requests (priority, desceription, details, employee_id, [file], FileName) " +
                      "VALUES (@Priority, @Description, @Details, @Employee_id, @File, @FileName)";

                using (SqlCommand cmd = new SqlCommand(/*query, con*/))
                {

                    cmd.Connection = con;
                    cmd.CommandText = "insert_req_info";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Priority", DropDownList1.SelectedValue);
                    cmd.Parameters.AddWithValue("@Description", des_Box.Text);
                    cmd.Parameters.AddWithValue("@Details", det_Box.Text);
                    cmd.Parameters.AddWithValue("@Employee_id", Convert.ToInt32(id_Box.Text));
                    cmd.Parameters.AddWithValue("@File", fileBytes);
                    cmd.Parameters.AddWithValue("@FileName", fileName);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("reqlist.aspx");
                }
            
           
           Error_label.Visible=false;
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
