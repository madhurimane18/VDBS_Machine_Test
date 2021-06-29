<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComapnyMaster.aspx.cs" Inherits="VDBS_TEST.ComapnyMaster" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Company Master</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" /> 
</head>
<body>
    <form id="form1" runat="server">
 
        <h2 style="color:#534686;text-align:center">Company Master</h2>
         <div class="container">
            <div class="col-md-offset-10 col-md-2">
                 <asp:Button ID="Button1" runat="server" Text="Next-To-Company-View" OnClick="Button1_Click" CssClass="btn btn-success" BorderStyle="None" />
          </div>
        </div>

        <div class="col-md-8 col-md-offset-2">
           <table class="table">
             <tr>
                 <th>Company Name</th>
                 <td><asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox></td>
             </tr>
             <tr>
                   <th>Upload Files</th>
                   <td><asp:FileUpload ID="FileUpload1" AllowMultiple="true" runat="server" CssClass="form-control" /></td>
             </tr>

               <tr>
                   <td><asp:Button ID="Btn" runat="server" Text="Submit" OnClick="Btn_Click" CssClass="btn btn-success" /></td>
                 <%--  <td><asp:Button ID="Btncancel" runat="server" Text="Cancel" OnClick="Btncancel_Click" CssClass="btn btn-danger" /></td>--%>
               </tr>

               
              
           </table>

         </div>
    </form>
</body>
</html>

