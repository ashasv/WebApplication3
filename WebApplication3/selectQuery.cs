using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WebApplication3
{
    public class selectQuery
    {
        List<string> data = new List<string>();
        List<string> datas = new List<string>();
        DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-05U2J61\\SQLEXPRESS;Initial Catalog=UserLoginDetails;Integrated Security=True");

        public List<string> SelectAll(string id)
        {
            if (id != null)
            {
                con.Open();
                string sqlquery = "SELECT [ID],[Login Name],[Password],[Real Name],[Department],CONVERT(VARCHAR(10), [Date of Birth], 111) AS [Date of Birth] FROM [dbo].[useraccount] WHERE [ID] ='" + id + "'";
                SqlCommand cmd = new SqlCommand(sqlquery, con);
                SqlDataReader sReader;
                cmd.Parameters.Clear();
                sReader = cmd.ExecuteReader();
                while (sReader.Read())
                {
                    data.Add(sReader["Login Name"].ToString());
                    data.Add(sReader["Password"].ToString());
                    data.Add(sReader["Real Name"].ToString());
                    data.Add(sReader["Department"].ToString());
                    data.Add(sReader["Date of Birth"].ToString());
                    data.Add(sReader["ID"].ToString());

                }
                con.Close();
            }
            return data;
        }
        public List<string> SelectIUP(string LoginName, string LoginPwd)
        {
            if (LoginName != null && LoginPwd != null)
            {
                con.Open();
                string sqlquery = "SELECT [ID],[Login Name],[Password] FROM [dbo].[useraccount] WHERE [Login Name] = '" + LoginName + "' or [Password] = '" + LoginPwd + "'";
                SqlCommand cmd = new SqlCommand(sqlquery, con);
                SqlDataReader sReader;
                cmd.Parameters.Clear();
                sReader = cmd.ExecuteReader();
                while (sReader.Read())
                {
                    datas.Add(sReader["ID"].ToString());
                    datas.Add(sReader["Login Name"].ToString());
                    datas.Add(sReader["Password"].ToString());
                }
                con.Close();
            }
            return datas;
        }
        public DataTable SelectAllinTable(string id)
        {
            con.Open();
            string sqlquery = "SELECT [Login Name],[Password],[Real Name],[Department],CONVERT(VARCHAR(10), [Date of Birth], 111) FROM [dbo].[useraccount] WHERE [ID] ='" + id + "'";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    con.Close();
                    return dt;
                }
            }
        }
    }
}