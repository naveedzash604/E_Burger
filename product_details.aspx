<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/main_template.Master" AutoEventWireup="true" CodeBehind="product_details.aspx.cs" Inherits="E_Burger.product_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Product</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <!-- our product -->


         <div class="product-bg-white">
         <div class="container">
            <div class="row">
               <div class="col-6">
                   <asp:Image ID="imageItem" runat="server" style="height:300px"/>
               </div>
                <div class="col-6">
                    <table border="1" class="redTable">
                       <tr>
                           <th>Item Name: </th>
                           <td>
                               <asp:Label ID="lblItemName" runat="server" Text="Cheese Burger"></asp:Label></td>
                       </tr>
                        <tr>
                           <th>Item Price: </th>
                           <td>
                               <asp:Label ID="lblItemPrice" runat="server" Text="LKR 1000.00"></asp:Label></td>
                       </tr>
                        <tr>
                           <th>Item Description: </th>
                           <td>
                               <asp:Label ID="lblItemDescription" runat="server" Text="Label"></asp:Label>

                           </td>
                       </tr>
                    </table>

                    <asp:HyperLink ID="linkOrderItem" runat="server" CssClass="btn btn-warning mt-3">Order Item</asp:HyperLink>

                </div>
            </div>
          </div>
         </div>
         
</asp:Content>