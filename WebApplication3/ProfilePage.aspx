<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="WebApplication3.ProfilePage" %>

<!DOCTYPE html>
<meta http-equiv="refresh" content="600">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            background-color: blueviolet;
            color: white;
        }

        td {
            padding: 10px;
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
<body>
    <form id="form1" runat="server">
        <div class="container">
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
            <h1>Profile Page</h1>
            <table>
                <tr>
                    <td>
                        <label for="LName"><b>Login Name</b></label></td>
                    <td>
                        <asp:TextBox ID="LName" runat="server" placeholder="Enter Login Name" Style="width: 300px;" /></td>
                </tr>
                <tr>
                    <td>
                        <label for="psw"><b>Password</b></label></td>
                    <td>
                        <asp:TextBox ID="psw" runat="server" type="Password" placeholder="Enter Password" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}" title="Must contain at least one number and one uppercase and lowercase letter, and at least 8 or more characters" Style="width: 300px;" /></td>
                </tr>
                <td>
                    <label for="RName"><b>Real Name</b></label></td>
                <td>
                    <asp:TextBox ID="RName" runat="server" placeholder="Enter Real Name" Style="width: 300px;" /></td>
                </tr>
                <tr>
                    <td>
                        <label for="Dpt"><b>Department </b></label>
                    </td>
                    <td>
                        <asp:TextBox ID="DName" runat="server" placeholder="Enter Department" Style="width: 300px" /></td>
                </tr>
                <tr>
                    <td>
                        <label for="DOB"><b>Date of Birth</b></label></td>
                    <td>
                        <asp:TextBox ID="DOB" runat="server" placeholder="Enter Date of birth" Style="width: 300px" /></td>
                </tr>
            </table>
            <br />
            <hr />
            <asp:Button ID="Button1" runat="server" Text="Update" OnClick="GotoUpdateProfilePage" />
        </div>
        <br />
        <div>
            <asp:Button ID="Button2" runat="server" Text="Logout" OnClick="GotoUpdateLoginPage" />

        </div>
    </form>
</body>
</html>
