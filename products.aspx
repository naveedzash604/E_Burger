<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/main_template.Master"  AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="E_Burger.products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>E-Burger - Products</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <div class="brand_color">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="titlepage">
                        <h2>Our product</h2>
                    </div>
                </div>
            </div>
        </div>

    </div>
      <!-- our product -->
      <div class="product">
         <div class="container">
            <div class="row">
               <div class="col-md-12">
                  <div class="title pb-1">
                      
                      <div class="row mt-3">
                          <div class="col-10">
                              <asp:TextBox ID="txtSearch" runat="server" placeholder="Search" class="form-control h-75"></asp:TextBox>
                          </div>
                          <div class="col-2">
                              <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-warning w-100 h-75" OnClick="btnSearch_Click"/>
                          </div>
                      </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
        <div class="input-group">

    <style>
        .product-box {
            width: 20%!important;
            margin-left: 0;
            margin-right: 5%;
            margin-right: 2.5%;
            margin-left: 2.5%;
            display:inline-block;
            
        }
    </style>

      <div class="product-bg">
         <div class="product-bg-white">
         
                <asp:Label ID="lblProductsList" runat="server" Text="" CssClass="inline"></asp:Label>
  
            </div>
         </div>
         </div>
         
</asp:Content>