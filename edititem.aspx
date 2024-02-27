<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/dashboard_template.Master" AutoEventWireup="true" CodeBehind="edititem.aspx.cs" Inherits="E_Burger.Admin.edititem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Edit Item</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="brand_color">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="titlepage">
                        <h2>Edit Item</h2>
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
                                <asp:TextBox ID="txtItemNames" runat="server" placeholder="Item Name" class="form-control" required="true"></asp:TextBox>
                            </div>
                            <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6">
                                <asp:TextBox ID="txtItemPrice" runat="server" TextMode="Number" placeholder="Item Price" class="form-control" required="true"></asp:TextBox>
                            </div>
                            <div class=" col-md-12">
                                <asp:TextBox ID="txtDescription" runat="server" placeholder="Description" class="form-control" required="true"></asp:TextBox>
                            </div>

                            <div class=" col-md-12">
                                <span class="text-danger">Select Image if need to change image</span>
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