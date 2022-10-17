using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-05U2J61\\SQLEXPRESS;Initial Catalog=UserLoginDetails;Integrated Security=True");
        static string id;
        protected void Page_Load(object sender, EventArgs e)
        {

            id = Session["ID"].ToString();
            if (id != null)
            {
                selectQuery qs = new selectQuery();
                List<string> data = qs.SelectAll(id);

                if (data.Count==6)
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

        protected void GotoUpdateProfilePage(object sender, EventArgs e)
        {
            Session["ID"] = id;
            Response.Redirect("UpdateProfilePage.aspx");
        }
        protected void GotoUpdateLoginPage(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }
    }
}