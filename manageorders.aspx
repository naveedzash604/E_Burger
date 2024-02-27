<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/dashboard_template.Master" AutoEventWireup="true" CodeBehind="manageorders.aspx.cs" Inherits="E_Burger.Admin.manageorders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Manage orders</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <div class="brand_color">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="titlepage">
                        <h2>Manage Orders</h2>
                        <a href="dashboard_admin.aspx" class="btn-link">Back to Dashboard</a>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <div class="container">

        <h1><asp:Label ID="lblFilterTitle" runat="server" Text="All Orders"></asp:Label> </h1>
           <div class="row mt-3">
               <a class="btn btn-primary mb-5 ml-2" href="manageorders.aspx">All Orders</a>
               <a class="btn btn-primary mb-5 ml-2" href="manageorders.aspx?filter=approved">Approved Orders</a>
               <a class="btn btn-primary mb-5 ml-2" href="manageorders.aspx?filter=pending">Pending Orders</a>
               <a class="btn btn-primary mb-5 ml-2" href="manageorders.aspx?filter=cancelled">Cancelled Orders</a>
           </div>
           
           <asp:Label ID="lblOrdersTable" runat="server" Text=""></asp:Label>  
          
   </div>

</asp:Content>