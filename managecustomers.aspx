<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/dashboard_template.Master" AutoEventWireup="true" CodeBehind="managecustomers.aspx.cs" Inherits="E_Burger.Admin.managecustomers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Customers</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="brand_color">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="titlepage">
                        <h2>Customers</h2>
                        <a href="dashboard_admin.aspx" class="btn-link">Back to Dashboard</a>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <div class="container">

        <h1><asp:Label ID="lblFilterTitle" runat="server" Text="All Customers"></asp:Label> </h1>
           <div class="row mt-3">

           </div>
           
           <asp:Label ID="lblCustomersTable" runat="server" Text=""></asp:Label>  
          
   </div>
</asp:Content>