<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/dashboard_template.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="E_Burger.userprofile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>User Profile</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="brand_color">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="titlepage">
                        <h2>My Profile</h2>
                        <a class="text-danger" href="index.aspx" class="btn-link"> Home Page</a> &nbsp|&nbsp
                        <a class="text-danger" href="dashboard.aspx" class="btn-link"> View My Orders</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
     <br />
     <br />
         <div class="container">
             <div class="row"> 
                 
             <div class="rounded mb-3 bg-primary">
                <asp:Label ID="lblMsg" runat="server" Text="" CssClass="hidden"></asp:Label>
            </div>
                 
               <div class="col-6">
                   <asp:Image ID="imageUser" runat="server" style="height:300px"/>
               </div>
                
             <div class="col-6">
                    <table border="0">
                        <tr>
                           <th>User Image: </th>
                           <td>
                               <div class=" col-md-12">
                                <span class="text-danger">Select Image if need to change image</span>
                                <asp:FileUpload ID="fileItemImage" runat="server" class="form-control"/>
                            </div>
                               <%--<asp:Label ID="lblItemName" runat="server" Text="Cheese Burger"></asp:Label>--%></td>
                       </tr>
                       <tr>
                           <th>First Name: </th>
                           <td>
                               <%--<asp:TextBox ID="txtemail" runat="server"></asp:TextBox>--%>
                               <asp:Label ID="lblfname" runat="server" Text="Your Name"></asp:Label></td>
                       </tr>
                        <tr>
                           <th>Last Name: </th>
                           <td>
                               <%--<asp:TextBox ID="txtemail" runat="server"></asp:TextBox>--%>
                               <asp:Label ID="lbllname" runat="server" Text="Your Name"></asp:Label></td>
                       </tr>
                        <tr>
                           <th>Email: </th>
                           <td>
                               <asp:Label ID="Lblemail" runat="server" Text="Label"></asp:Label>                             
                               <%--<asp:Label ID="lblItemPrice" runat="server" Text="LKR 1000.00"></asp:Label>--%></td>
                       </tr>
                        <tr>
                           <th>Password: </th>
                           <td>
                               
                               <asp:TextBox ID="txtupw" runat="server" TextMode="Password"></asp:TextBox>
                               <%--<asp:Label ID="lblItemDescription" runat="server" Text="Label"></asp:Label>--%>

                           </td>
                       </tr>
                        <tr>
                           <th>Confirm Password: </th>
                           <td>
                               
                               <asp:TextBox ID="txtconupw" runat="server" TextMode="Password"></asp:TextBox> 
                               <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                   ErrorMessage="Password not match" ControlToCompare="txtconupw" 
                                   ControlToValidate="txtupw" ForeColor="Red"></asp:CompareValidator>
                               <%--<asp:Label ID="lblItemDescription" runat="server" Text="Label"></asp:Label>--%>

                           </td>
                       </tr>
                    </table>

                    <asp:Button ID="btnupdate" runat="server" CssClass="btn btn-warning mt-3" 
                        Text="UPDATE INFO" OnClick="btnupdate_Click" />
                    <%--<asp:HyperLink ID="linkOrderItem" runat="server" CssClass="btn btn-warning mt-3">Order Item</asp:HyperLink>--%>

                </div>
            </div>
        </div>
         
</asp:Content>