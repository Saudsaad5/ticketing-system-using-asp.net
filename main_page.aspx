<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main_page.aspx.cs" Inherits="Requesting_system.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Requests page</title>
    <style>

        body{
            background-color:antiquewhite;
        }

        div{
             margin-left: 35%;
             margin-top: 120px;
             color:mediumpurple;
        }
      .red{
            color:red;
            
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="text-container">
            <h1 ">Enter Your Request:</h1>
           <table>
               <tr>
                    <td>Employee ID:</td>
                          <td><asp:TextBox ID="id_Box" runat="server"></asp:TextBox>
                          <asp:Label CssClass="red" Visible="false" ID="id_Label" runat="server" Text="Please enter your id."></asp:Label>
                              
                    </td>
                </tr>
                 <tr>
                     <td>
                         <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                         <asp:ListItem Value="Select Priority">Select Priority:</asp:ListItem>
                         <asp:ListItem Value="High Priority">High Priority</asp:ListItem>
                         <asp:ListItem Value="Medium Priority">Medium Priority</asp:ListItem>
                         <asp:ListItem Value="Low Priority">Low Priority</asp:ListItem>
                         </asp:DropDownList>
                         <asp:Label CssClass="red" Visible="false" ID="priority_Label" runat="server" Text="Please select a priority."></asp:Label>
                    </td>
                 </tr>

               <tr>
                   <td runat ="server" visible ="false" id="des_text">Desceription:</td>
                   <td><asp:TextBox Visible="false" ID="des_Box" runat="server"></asp:TextBox>
                       <asp:Label CssClass="red" Visible="false" ID="des_Label" runat="server" Text="Please enter a desceription."></asp:Label>
                   </td>
               </tr>

               <tr>
                   <td>Details:</td>
                   <td><asp:TextBox ID="det_Box" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
                       <asp:Label CssClass="red" Visible="false" ID="det_Label" runat="server" Text="Please enter your request details."></asp:Label>
                   </td>
               </tr>

               <tr>
                   <td>
                       <asp:FileUpload ID="FileUpload1" runat="server" AutoPostBack="True"/></td>
               </tr>

               <tr>
                   <td colspan="2" align="center">
                       <asp:Button ID="save_Button" runat="server" Text="Save" OnClick="save_Button_Click" />
                       <asp:Button ID="View" runat="server" Text="View" OnClick="View_Click" />
                   </td>
               </tr>
           </table>
        </div>
    </form>
</body>
</html>
