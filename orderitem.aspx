<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/dashboard_template.Master" AutoEventWireup="true" CodeBehind="orderitem.aspx.cs" Inherits="E_Burger.Admin.orderitem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Order Item</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row mb-5">
            <div class="col-6">
                <br /><br /> <br />
                <table border="1" style="width:100%" class="redTable" padding: 80px 10px 0 20px;>
                       <tr>
                           <th>Item Name: </th>
                           <td>
                               <asp:Label ID="lblitemID" runat="server" Text="Label" Visible="False"></asp:Label>
                               <asp:Label ID="lblItemName" runat="server" Text="Norton Internet Security"></asp:Label></td>
                       </tr>
                        <tr>
                           <th>Item Price: </th>
                           <td>
                              LKR <asp:Label ID="lblItemPrice" runat="server" Text="2000.00"></asp:Label></td>
                       </tr>
                        <tr>
                           <th>Item Description: </th>
                           <td>
                               <asp:Label ID="lblItemDescription" runat="server" Text="Label"></asp:Label>

                           </td>
                       </tr>
                        <tr>
                           <th>Item Qty: </th>
                           <td>
                               <asp:TextBox ID="txtQty" runat="server"  CssClass="w-100" TextMode="Number" 
                                   Text="1" OnTextChanged="txtQty_TextChanged"></asp:TextBox>
                               <asp:Button ID="btnUpdateQty" runat="server" Text="Update" OnClick="btnUpdateQty_Click" OnClientClick="btnUpdateQty" />
                           </td>
                       </tr>
                    </table>

                    
            </div>
            <div class="col-6">
            <br /><br /> <br /><br /><br />
                <h1>Total: LKR <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label></h1>

                <asp:Button ID="btnConfirmOrder" runat="server" Text="Add to Cart" CssClass="btn btn-warning" OnClick="btnConfirmOrder_Click" OnClientClick="btnConfirmOrder" />
            </div>
        </div>
    </div> 
            <br /><br /><br />
</asp:Content>