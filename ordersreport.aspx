<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/dashboard_template.Master" AutoEventWireup="true" CodeBehind="ordersreport.aspx.cs" Inherits="E_Burger.Admin.ordersreport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Reports</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="brand_color">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="titlepage">
                        <h2>Orders Report</h2>
                         <a href="dashboard_admin.aspx" class="btn-link">Back to Dashboard</a>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <div class="container">

        <h1><asp:Label ID="lblFilterTitle" runat="server" Text="All Orders"></asp:Label> </h1>
           
           <asp:Label ID="lblOrdersTable" runat="server" Text=""></asp:Label>  
          
   </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="afterjs" runat="server">
    <script>
			$(document).ready(function () {
                $("#reportTable").DataTable({
				// bFilter: false,
				dom: "Bfrtip",
				buttons: ["copy", "csv", "excel", "pdf", "print"],
				});
			});
    </script>
</asp:Content>