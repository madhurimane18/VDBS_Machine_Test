<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyView.aspx.cs" Inherits="VDBS_TEST.CompanyView" %>

<!DOCTYPE html>


<head runat="server">
    <title>Company View</title>
       <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" /> 
 </head>

<body>
  
    <form id="form1" runat="server">
         <h2 style="color:#534686;text-align:center">Company View</h2>
        <div class="container">
            <div class="col-md-offset-10 col-md-2">
                 <asp:Button ID="Btn" runat="server" Text="Back-To-Company-Master" OnClick="Btn_Click" CssClass="btn btn-success" BorderStyle="None" />
          </div>
        </div>
        <div class="container">
            <asp:GridView ID="Companymaster" CssClass="table table-bordered table-hover table-responsive" runat="server" AutoGenerateColumns="False" OnRowCommand="Companymaster_RowCommand" OnRowDataBound="OnRowDataBound" HeaderStyle-HorizontalAlign="Center">
                <Columns>
                   <%-- <asp:BoundField DataField="ID" HeaderText="ID" />--%>
                    <asp:BoundField DataField="Status" HeaderText="Status" />

                     <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                           <%-- <asp:LinkButton ID="lnkshow" Text="Show" runat="server" CommandArgument='<%# Eval("ID") %>' data-toggle="modal" data-target="#myModal" ></asp:LinkButton>--%>
                             <asp:LinkButton ID="lnkshow" Text="Show" runat="server"  Enabled='<%# Eval("Status").ToString() == "0" ? false : true %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                
                     <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            &nbsp;&nbsp;<asp:LinkButton ID="LinkButton1" Text="Approve" runat="server" CommandName="Select" OnClick="LinkButton1_Click"  CommandArgument="<%# Container.DataItemIndex %>" Enabled='<%# Eval("Status").ToString() == "0" ? false : true %>'></asp:LinkButton>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                             &nbsp;&nbsp;<asp:LinkButton ID="LinkButton2" Text="DisApprove" runat="server" CommandName="DisApprove" OnClick="LinkButton2_Click" CommandArgument="<%# Container.DataItemIndex %>" Enabled='<%# Eval("Status").ToString() == "0" ? false : true %>'></asp:LinkButton>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </ItemTemplate>
                    </asp:TemplateField>
                   </Columns>
                <HeaderStyle  HorizontalAlign="Center" cssclass="table table-dark"/>
            </asp:GridView>

             <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>

