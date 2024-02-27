<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/dashboard_template.Master" AutoEventWireup="true" CodeBehind="manageitems.aspx.cs" Inherits="E_Burger.Admin.manageitems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>E-Burger - Manage Items</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="brand_color">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="titlepage">
                        <h2>Manage Items</h2>
                        <a href="dashboard_admin.aspx" class="btn-link">Back to Dashboard</a>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <div class="container">
           <div class="row mt-3">
               <a class="btn btn-primary mb-5" href="additem.aspx">Add Items</a>
           </div>
           
           <asp:Label ID="lblItemsTable" runat="server" Text=""></asp:Label>  
          
   </div>
   
</asp:Content>