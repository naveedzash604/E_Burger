<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/main_template.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="E_Burger.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="brand_color">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="titlepage">
                        <h2> Login</h2>
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
                        <div class="text-center mb-4">
                        <div class="row">
                            <div class="col-md-6 offset-md-3">

                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                    ControlToValidate="txtEmail" ErrorMessage="Please Enter the Required Email" 
                                    ForeColor="Red" 
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                                <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" class="form-control"></asp:TextBox>
                            </div>
                            <div class="w-100"> 
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtPwd" ErrorMessage="Please Enter the Password" 
                                    ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-6 offset-md-3">
                                <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" placeholder="Password" class="form-control"></asp:TextBox>
                            </div> 
                            <div class="col-md-6 offset-md-3 ">
                                <asp:Button ID="btnLogin" class="send" runat="server" Text="Login"
                                    OnClick="btnLogin_Click"/>
                            </div>
                         </div>
                         </div>
                    </form>
                </div>  
            </div> 
            </div>
        </div>
    <!-- end contact -->
</asp:Content>