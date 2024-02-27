<%@ Page Language="C#"  EnableEventValidation="false" MasterPageFile="~/main_template.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="E_Burger.cart1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="brand_color">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="titlepage">
                        <h2>My Cart</h2>
                         <a href="products.aspx" class="btn-link">Back to Products</a>
                    </div>
                </div>
            </div>
        </div>
    </div>

<div class="content">
            <div class="rounded mb-3 bg-primary">
                        <asp:Label ID="lblMsg" runat="server" Text="" CssClass="hidden"></asp:Label>
                    </div>
	 				<div class="row">
	 					<div class="col-md-12 col-lg-8">
	 						<div class="items">
				 				<div class="product">
				 					<div class="row">
					 					<div class="col-md-1">
                                            
					 					</div>
					 					<div class="col-md-8">
					 						<div class="info">
						 						<div class="row">
							 						<div class="col-md-5 product-name">
                                                         <asp:GridView ID="DGcart" class="redTable" runat="server" 
                                                             AutoGenerateColumns="False" ShowFooter="True" Width="700px" 
                                                             DataKeyNames="id" OnRowCancelingEdit="DGcart_RowCancelingEdit" 
                                                             OnRowDeleting="DGcart_RowDeleting" OnRowEditing="DGcart_RowEditing" 
                                                             OnRowUpdating="DGcart_RowUpdating" 
                                                             OnSelectedIndexChanged="DGcart_SelectedIndexChanged">
                                                             <Columns>
                                                                 <asp:BoundField DataField="id" HeaderText="Number" ReadOnly="True" />
                                                                 <asp:ImageField DataImageUrlField="img" HeaderText="Image" ReadOnly="True">
                                                                     <ControlStyle Height="50px" Width="50px" />
                                                                 </asp:ImageField>
                                                                 <asp:BoundField DataField="itemid" HeaderText="Item ID" ReadOnly="True" />
                                                                 <asp:BoundField DataField="pname" HeaderText="Product Name" ReadOnly="True" />
                                                                 <asp:BoundField DataField="Pprice" HeaderText="Product Price" ReadOnly="True" />
                                                                 <asp:BoundField DataField="qty" HeaderText="Quantity" >
                                                                 <ControlStyle Width="50px" />
                                                                 </asp:BoundField>
                                                                 <asp:BoundField DataField="total" HeaderText="Total" ReadOnly="True" />
                                                                 <asp:CommandField ButtonType="Button" ShowEditButton="True" />
                                                                 <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
                                                             </Columns>
                                                         </asp:GridView>
							 						</div>
							 					</div>
							 				</div>
					 					</div>
					 				</div>
				 				</div>
	 						</div>
			 			</div>

			 			<div class="col-md-12 col-lg-4">
			 				<div class="cart">                                 
			 					<div style="border-bottom: 1px solid #eaeaec; padding: 64px 0 0px 1px;" >
                    <h5 class="proNameViewCart">PRICE DETAILS</h5>
                    <div>
                        <label>Cart Total</label>
                        <asp:Label ID="lblprice" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        <label>Delivery Charge</label>
                        <asp:Label ID="lbldelivery" runat="server" Text="LKR. 150"></asp:Label>
                    </div>
                </div>
                <div>
                    <div class="proPriceView">
                        <label>Total</label>
                        <asp:Label ID="lbltotal" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        <asp:Button ID="btnPlaceOrder" CssClass="buyNowBtn" runat="server" Text="Place Order" OnClientClick="btnPlaceOrder" OnClick="btnPlaceOrder_Click"/>
                        </div>
                    </div>
			    </div>
			 	</div>
		 			</div> 
		 		</div>
</asp:Content>