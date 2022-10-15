<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="WebApplication3.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Submit1 {
            width: 183px;
            margin-left: 145px;
        }

        body {
            background-color: blueviolet;
            color: white;
        }

        td {
            padding: 10px;
        }

        a {
            color: white;
        }

        #color {
            width: 150px;
            margin-left: 1300px;
        }

        #ct {
            margin-left: 1310px;
        }
    </style>

</head>

<body id="bodyID" runat="server">
    <form id="form1" runat="server">
        <div>
            <label id="ct">Change Theme</label>
            <%--<input type="color" id="color" />--%>
            <asp:DropDownList ID="color" runat="server">
                <asp:ListItem>Select Theme</asp:ListItem>
                <asp:ListItem>Black</asp:ListItem>
                <asp:ListItem>Orange</asp:ListItem>
                <asp:ListItem>Blue</asp:ListItem>
            </asp:DropDownList>
            <hr />
            <script>
                let color = document.getElementById("color");
                color.onchange = function () {
                    document.body.style.backgroundColor = this.value;
                }
            </script>
            <h1>Login Page</h1>
        </div>
        <table>
            <tr>
                <td>
                    <label for="LName"><b>Login Name</b></label></td>
                <td>
                    <asp:TextBox ID="LName" runat="server" placeholder="Enter Login Name" required="required" Style="width: 300px;" />
                </td>
            </tr>
            <tr>
                <td>
                    <label for="psw"><b>Password</b></label></td>
                <td>
                    <asp:TextBox ID="psw" runat="server" type="Password" placeholder="Enter Password" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}" title="Must contain at least one number and one uppercase and lowercase letter, and at least 8 or more characters" required="required" Style="width: 300px;" />
                </td>
            </tr>
        </table>
        <br />
        <hr />
        <asp:Button ID="Button1" runat="server" OnClick="GotoProfilePage" Text="Login" />
    </form>
    <p>
        New user? click on <a href="RegisterPage.aspx">Register</a>
    </p>

</body>
</html>
