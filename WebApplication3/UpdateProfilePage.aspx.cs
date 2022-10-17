using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class UpdateProfilePage : System.Web.UI.Page
    {
        static string id;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-05U2J61\\SQLEXPRESS;Initial Catalog=UserLoginDetails;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            Display();
        }
        protected void Display()
        {
            id = Session["ID"].ToString();
            if (!this.IsPostBack)
            {
                //Populating a DataTable from database.
                selectQuery qs = new selectQuery();
                DataTable dt = qs.SelectAllinTable(id);

                //Building an HTML string.
                StringBuilder html = new StringBuilder();

                //Table start.
                html.Append("<table border = '1'>");

                //Building the Header row.
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<th>");
                    html.Append(column.ColumnName);
                    html.Append("</th>");
                }
                html.Append("</tr>");

                //Building the Data rows.
                foreach (DataRow row in dt.Rows)
                {
                    html.Append("<tr>");
                    foreach (DataColumn column in dt.Columns)
                    {
                        html.Append("<td>");
                        html.Append(row[column.ColumnName]);
                        html.Append("</td>");
                    }
                    html.Append("</tr>");
                }

                //Table end.
                html.Append("</table>");

                //Append the HTML string to Placeholder.
                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
            }
        }
        protected void UpdateProfilePages(object sender, EventArgs e)
        {
            if (LName.Text != "" && psw.Text != "" && RName.Text != "" && LName.Text != "" && DName.Text != "" && DOB.Text != "")
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE [dbo].[useraccount] SET [Login Name]='" + LName.Text + "',[Password]='" + psw.Text + "'," +
                    "[Real Name]='" + RName.Text + "'," +
                    "[Department]='" + DName.Text + "'," +
                    "[Date of Birth]='" + DOB.Text + "' WHERE [ID]=" + id + "";
                int check = cmd.ExecuteNonQuery();
                selectQuery qs = new selectQuery();
                List<string> data = qs.SelectAll(id);
                if (data.Count == 6)
                {
                    LName.Text = data[0];
                    psw.Text = data[1];
                    RName.Text = data[2];
                    DName.Text = data[3];
                    DOB.Text = data[4];
                    id = data[5];
                }
                if (check != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Updated successfully...')", true);
                    Page_Load(sender, e);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Updated unsuccessfull, try again.')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fileds should not be blank.')", true);
            }
        }

        protected void GotoProfilePage(object sender, EventArgs e)
        {
            Response.Redirect("ProfilePage.aspx");
        }

        protected void GetAllDetails(object sender, EventArgs e)
        {
            Page_Load(sender, e);
            if (id != null)
            {
                selectQuery qs = new selectQuery();
                List<string> data = qs.SelectAll(id);

                if (data.Count == 6)
                {
                    LName.Text = data[0];
                    psw.Text = data[1];
                    RName.Text = data[2];
                    DName.Text = data[3];
                    DOB.Text = data[4];
                    id = data[5];
                }
            }
        }
    }
}