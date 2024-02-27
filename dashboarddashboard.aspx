<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/dashboard_template.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="E_Burger.dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Dashboard</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="brand_color">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="titlepage">
                        <h2>Dashboard</h2>
                        <a href="index.aspx" class="btn-link"> Home Page</a> &nbsp|&nbsp
                        <a href="userprofile.aspx" class="btn-link"> View My Account</a>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container">

        <h1><asp:Label ID="lblFilterTitle" runat="server" Text="All Orders"></asp:Label> </h1>
           <div class="row mt-3">
               <a class="btn btn-primary mb-5 ml-2" href="dashboard.aspx">
                   All Orders (<asp:Label ID="lblAllOrders" runat="server" Text="0"></asp:Label>)
               </a>
               <a class="btn btn-primary mb-5 ml-2" href="dashboard.aspx?filter=approved">
                   Approved Orders (<asp:Label ID="lblApprovedOrders" runat="server" Text="0"></asp:Label>)
               </a>
               <a class="btn btn-primary mb-5 ml-2" href="dashboard.aspx?filter=pending">
                   Pending Orders (<asp:Label ID="lblPendingOrders" runat="server" Text="0"></asp:Label>)
               </a>
               <a class="btn btn-primary mb-5 ml-2" href="dashboard.aspx?filter=cancelled">
                   Cancelled Orders (<asp:Label ID="lblCancelledOrders" runat="server" Text="0"></asp:Label>)
               </a>
           </div>           
           <asp:Label ID="lblOrdersTable" runat="server" Text=""></asp:Label>
          
   </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="afterjs" runat="server"></asp:Content>