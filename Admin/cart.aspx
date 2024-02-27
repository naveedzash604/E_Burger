<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/dashboard_template.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="E_Burger.cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>E-Burger - Cart</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <div class="brand_color">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="titlepage">
                        <h2>Cart</h2>
                        <a href="index.aspx" class="btn-link"> Home Page</a> &nbsp<%--|&nbsp
                        <a href="userprofile.aspx" class="btn-link"> View My Account</a>--%>
<%--                        <a href="dashboard_admin.aspx" class="btn-link">Back to Dashboard</a>--%>
                    </div>
                </div>
            </div>
        </div>
        </div>

    <div class="row">
        <div class="container">

     <div class="col-md-9 pt-5" runat="server" >
                <div style="border-bottom: 1px solid #eaeaec;">
                    <h5 class="proNameViewCart">PRICE DETAILS</h5>
                    <div>
                        <label>Cart Total</label>
                        <span class="float-right priceGray" runat="server"></span>
                    </div>
                    <div>
                        <label>Cart Discount</label>
                        <span class="float-right priceGreen"  runat="server"></span>
                    </div>
                </div>
                <div>
                    <div class="proPriceView">
                        <label>Total</label>
                        <span class="float-right"  runat="server"></span>
                    </div>
                    <div>
                        <asp:Button CssClass="buyNowBtn" runat="server" 
                            Text="Place Order" OnClick="btnPlaceOrder_Click" />
                    </div>
                </div>
            </div>

        <div class="col-md-3 pt-5" runat="server" id="divPriceDetails">
                <div style="border-bottom: 1px solid #eaeaec;">
                    <h5 class="proNameViewCart">PRICE DETAILS</h5>
                    <div>
                        <label>Cart Total</label>
                        <span class="float-right priceGray" id="spanCartTotal" runat="server"></span>
                    </div>
                    <div>
                        <label>Cart Discount</label>
                        <span class="float-right priceGreen" id="spanDiscount" runat="server"></span>
                    </div>
                </div>
                <div>
                    <div class="proPriceView">
                        <label>Total</label>
                        <span class="float-right" id="spanTotal" runat="server"></span>
                    </div>
                    <div>
                        <asp:Button ID="btnPlaceOrder" CssClass="buyNowBtn" runat="server" 
                            Text="Place Order" OnClick="btnPlaceOrder_Click" />
                    </div>
                </div>
            </div>              
        </div>
    </div>
           <asp:Label ID="lblCartTable" runat="server" Text=""></asp:Label>
</asp:Content>