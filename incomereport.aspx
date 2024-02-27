<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/dashboard_template.Master" AutoEventWireup="true" CodeBehind="incomereport.aspx.cs" Inherits="E_Burger.Admin.incomereport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Income Report</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="brand_color">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="titlepage">
                        <h2>Income Report</h2>
                         <a href="dashboard_admin.aspx" class="btn-link">Back to Dashboard</a>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <div class="container">

        <h1><asp:Label ID="lblFilterTitle" runat="server" Text="Income Report"></asp:Label> </h1>

        <div class="row">

            <div class="col-4">
                <asp:TextBox ID="txtFromDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-4">
                <asp:TextBox ID="txtToDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-2"> <br /> <br />
                <asp:Button ID="btnFilter" runat="server" Text="Filter" CssClass="btn btn-primary w-100 h-80" OnClientClick="btnFilter" />
            </div>
            <div class="col-2">  <br /> <br />
                <a href="incomereport.aspx" class="btn btn-info w-100 h-80">Reset</a>
            </div>

            
            
            
        </div>
           
           <asp:Label ID="lblIncomeTable" runat="server" Text=""></asp:Label>  
          
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