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
            <table border="1">
                <tr>
                    <th>Request id</th>
                    <th>Priority</th>
                    <th>Desceription</th>
                    <th>Details</th>
                    <th>Employee id</th>
                    <th>Time</th>
                    <th>File Name</th>
                    <th>Request Details</th>
                </tr>
                <asp:Repeater ID="Rptrequest" runat="server">
                    <ItemTemplate>
                       
                        <tr>
                            <td><%# Eval("req_id") %></td>
                            <td><%# Eval("priority") %></td>
                            <td><%# Eval("desceription") %></td>
                            <td><%# Eval("details") %></td>
                            <td><%# Eval("employee_id") %></td>
                            <td><%# Eval("time") %></td>
                            <td><%# Eval("FileName") %></td>
                            <td><asp:Button ID="View_det_btn" runat="server" Text="details" req_id= <%# Eval("req_id") %> OnClick="View" /></td>

                        </tr>
                       
                    </ItemTemplate>
                </asp:Repeater>
                
            </table>
            <br />
            <asp:Button ID="back_Button" runat="server" Text="Back" OnClick="back_Button_Click" />
        </div>
    </form>
</body>
</html>
