<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reqlist.aspx.cs" Inherits="Requesting_system.reqlist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Page</title>
        <style>

        body{
            background-color:antiquewhite;
        }

        div{
             
             color:mediumpurple;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>All Requests:</h1>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <br />
            <asp:Button ID="back_Button" runat="server" Text="Back" OnClick="back_Button_Click" />
        </div>
    </form>
</body>
</html>
