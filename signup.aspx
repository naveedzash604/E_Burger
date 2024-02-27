<%@ Page Language="C#" MasterPageFile="~/main_template.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="E_Burger.signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>E-Burger - Sign Up</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="brand_color">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="titlepage">
                        <h2>Create Account</h2>
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
                                <asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator1" runat="server" 
                                    ErrorMessage="First Name is Required" ControlToValidate="txtFName" 
                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtFName" runat="server" placeholder="First Name" class="form-control" ></asp:TextBox>
                            </div>
                            <div class="col-6 col-sm-6">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txtLName" ErrorMessage="Last Name is Required" 
                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtLName" runat="server" placeholder="Last Name" class="form-control"></asp:TextBox>
                            </div>
                            </div>
                            <div class="row">
                            <div class="col-6 col-sm-6">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                    ErrorMessage="Phone Number is Required" ControlToValidate="txtContact" 
                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtContact" runat="server" placeholder="Contact Number" class="form-control"></asp:TextBox>
                            </div>
                                
                            <div class="col-6 col-sm-6">
                                
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="txtAddress" ErrorMessage="Address  is Required" 
                                    ForeColor="Red"></asp:RequiredFieldValidator>                                
                                <asp:TextBox ID="txtAddress" runat="server" placeholder="Address" class="form-control"></asp:TextBox>
                            </div>
                            </div>
                         <div class="row">                            
                            <div class="col-6 col-sm-6"> 
                                <asp:RegularExpressionValidator
                                    ID="RegularExpressionValidator1" runat="server" 
                                    ErrorMessage="Email Address  is Required" ControlToValidate="txtEmail" 
                                    ForeColor="Red" 
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" class="form-control"  txtMode="Email"></asp:TextBox>
                            </div>                               

                            <div class="col-6 col-sm-6">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                    ErrorMessage="Please Enter the Password" ControlToValidate="txtPwd" 
                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" placeholder="User Password" class="form-control"></asp:TextBox>
                            </div>
                             </div>
                       <div class="row">
                            <div class=" col-md-12 mb-5 ">

                                <asp:Button ID="btnSave" class="send" runat="server" Text="Register" OnClick="btnSave_Click" />
                            </div>
                        </div>
                                </div>
                            </div>
                    </form>
                </div>
            </div>
    <!-- end contact -->
</asp:Content>