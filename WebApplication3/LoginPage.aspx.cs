using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GotoProfilePage(object sender, EventArgs e)
        {
            var LoginName = LName.Text;
            var LoginPwd = psw.Text;
            var userName = "";
            var userPWd = "";
            var id = "";
            if (LoginName != null && LoginPwd != null)
            {
                selectQuery qs = new selectQuery();
                List<string> datas = qs.SelectIUP(LoginName, LoginPwd);
                for (int i = 0; i < datas.Count; i++)
                {
                    id = datas[0];
                    userName = datas[1];
                    userPWd = datas[2];
                }
                if (userName != LoginName && userPWd != LoginPwd)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Login name and password is incorrect...')", true);
                }
                else if (userName == LoginName)
                {
                    if (userPWd == LoginPwd)
                    {
                        Session["ID"] = id;
                        Response.Redirect("ProfilePage.aspx");
                    }
                    else
                    {
                        psw.Text = "";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Login password is incorrect...')", true);
                    }
                }
                else
                {
                    LName.Text = "";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Login name is incorrect...')", true);
                }
            }

        }
    }
}

