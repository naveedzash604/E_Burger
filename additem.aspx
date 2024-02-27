<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/dashboard_template.Master" AutoEventWireup="true" CodeBehind="additem.aspx.cs" Inherits="E_Burger.Admin.additem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>E-Burger - Add Item</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="brand_color">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="titlepage">
                        <h2>Add Item</h2>
                        <a href="manageitems.aspx" class="btn-link">Back to Manage Items</a>
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
                <div class="col-md-12">

                    <form class="main_form">
                        <div class="row">
                            
                            <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ErrorMessage="Please Enter an Item Name" ControlToValidate="txtItemNames" 
                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtItemNames" runat="server" placeholder="Item Name" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ErrorMessage="Please Enter the Item Price" ControlToValidate="txtItemPrice" 
                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtItemPrice" runat="server" TextMode="Number" placeholder="Item Price" class="form-control"></asp:TextBox>
                            </div>
                            <div class=" col-md-12">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ErrorMessage="Please Enter the Item Descripition" 
                                    ControlToValidate="txtDescription" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtDescription" runat="server" placeholder="Description" class="form-control"></asp:TextBox>
                            </div>

                            <div class=" col-md-12">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                    ErrorMessage="Please Uploade an Item Image" ControlToValidate="fileItemImage" 
                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:FileUpload ID="fileItemImage" runat="server" class="form-control"/>
                            </div>
                            <div class=" col-md-12 mb-5 ">
                                <asp:Button ID="btnSave" class="send" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClick="btnSave" />
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <!-- end contact -->

</asp:Content>