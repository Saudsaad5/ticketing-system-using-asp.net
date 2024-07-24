<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Det_page.aspx.cs" Inherits="Requesting_system.Det_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Details page</title>
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
            <h1>Details</h1>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <asp:Button ID="Button1" runat="server" Text="Back" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
