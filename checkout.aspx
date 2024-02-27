<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" MasterPageFile="~/dashboard_template.Master" CodeBehind="checkout.aspx.cs" Inherits="E_Burger.checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>E-Burger - Check Out</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="brand_color">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="titlepage">
                        <h2>Delivery Details</h2>
                        <a href="cart.aspx" class="btn-link">Back to Cart</a>
                    </div>
                </div>
            </div>
        </div>

    </div>
            
    <!-- contact -->
    <div class="contact">
        <div class="container">
            <div class="rounded mb-3 bg-primary">
                <asp:Label ID="lblMsg" runat="server" Text="" CssClass="hidden"></asp:Label>
            </div>

            <div class="row">
                <div class="col-md-6 offset-md-3">

                    <form class="main_form">
                        <div class="row">
                            <div class="col-6 col-sm-6">
                                <asp:Label ID="lblfname" runat="server" Text="First Name"></asp:Label>
                            </div>
                            <div class="col-6 col-sm-6">
                                <asp:Label ID="lbllname" runat="server" Text="Last Name"></asp:Label>
                            </div>
                            </div>
                            <div class="row">

                            <div class="col-6 col-sm-6">
                                <asp:Label ID="lblcontact" runat="server" Text="Mobile Number"></asp:Label>
                            </div>
                                
                            <div class="col-6 col-sm-6">
                                <asp:Label ID="lbladdress" runat="server" Text="Address"></asp:Label>
                            </div>
                            </div>
                            </div>
                             </div>
                       <div class="row">
                            <div class=" col-md-12 mb-5 ">

                                <asp:Button ID="btnSave" class="send" runat="server" Text="Compleat Order" OnClick="btnSave_Click" />
                            </div>
                        </div>
                                </div>
                            </div>
                    </form>
    <!-- end contact -->
</asp:Content>