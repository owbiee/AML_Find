<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vehicle_Entry.aspx.cs" Inherits="AML_Find.Vehicle_Entry" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AML | Vehicle Entry</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        .header{
            margin: 0 auto;
            height: 400px;
            width: 700px;
            border-radius: 10px;
            background-color: white;
            /*text-align: center;*/
        }
        .tab-center{
            margin: 0 auto;
        }
        body{
            background: url("Container vessel.jpg");
            background-size: cover;
        }
        .button{
            text-align: center;
        }
        .Error{
            text-align: center;
            margin-top: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
             <div class="header">
                <br />
                 <h2 style="text-align: center;">Vehicle: Full Entry</h2>
                 <hr />
                 <%--<asp:DropDownList ID="txtvehmake" runat="server"></asp:DropDownList><br />
                 <asp:DropDownList ID="txtvehmod" runat="server"></asp:DropDownList><br />--%>
                 <table class="tab-center">
                     
                     <tr>
                         <td><h5>Prefix:</h5></td>
                         <td><asp:TextBox ID="txtprefix" runat="server" disabled="disabled" Text="AML" class="col-lg-6"></asp:TextBox></td>
                         <td><h5>Vehicle Code:</h5></td>
                         <td><asp:TextBox ID="txtvehcode" runat="server"></asp:TextBox></td>
                         <td><asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-default" OnClick="btnSearch_Click"/></td>
                     </tr>

                     <tr>
                         <td><h5>Vehicle Make:</h5></td>
                         <td><dx:ASPxComboBox ID="txtvehmke" runat="server" TextField="VEHMKE" Theme="MaterialCompact" OnSelectedIndexChanged="txtvehmke_SelectedIndexChanged" AutoPostBack="true"></dx:ASPxComboBox>
                             <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AMLCARDATAConnectionString %>" SelectCommand="SELECT DISTINCT [VEHMKE] FROM [AMLCARMDLS]"></asp:SqlDataSource>--%>
                         </td>
                         <%--<td><asp:DropDownList runat="server"><asp:ListItem>Select</asp:ListItem></asp:DropDownList></td>--%>
                         <td><h5>Vehicle Model:</h5></td>
                         <%--<td><asp:DropDownList ID="txtvehmdl1" runat="server" ><asp:ListItem>--Select Vehicle Model--</asp:ListItem></asp:DropDownList></td>--%>
                         <td><dx:ASPxComboBox ID="txtvehmdl" runat="server" TextField="VEHMDL" Theme="MaterialCompact"></dx:ASPxComboBox></td>
                     </tr>

                     <tr>
                         <td><h5>Year:</h5></td>
                         <td><asp:TextBox ID="txtvehyear" runat="server"></asp:TextBox></td>

                     </tr>
                     <tr>
                         <td><h5>Clearing Cost:</h5></td>
                         <td><asp:TextBox ID="txtclrprice" runat="server"></asp:TextBox></td>

                     </tr>
                 
                 </table>
                 <br />
                 <div class="button">
                     <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click"/>
                     <asp:Button ID="btnClear" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnClear_Click"/>
                     <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-success" OnClick="btnUpdate_Click"/>
                     <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click"/>
                 </div>

                 <div class="Error">
                     <asp:Label ID="lblerr" runat="server" Text=""></asp:Label>
                 </div>
                 
                 <%--<asp:Label ID="lblFind" runat="server" Text="find" style="color: blue; float: right; margin-right: 20px;"></asp:Label>--%>
                 <%--<asp:HyperLink ID="HyperLink1" runat="server" style="color: blue; float: right; margin-right: 20px;">find</asp:HyperLink>--%>
                 <%--<footer style="text-align: center;">Orbit Technologies</footer>--%>
        </div>
        </ContentTemplate>
       
        </asp:UpdatePanel>
    </form>
</body>
</html>
