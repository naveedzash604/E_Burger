<%@ Page Language="C#" MasterPageFile="~/dashboard_template.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="~/dashboard_admin.aspx.cs" Inherits="E_Burger.Admin.dashboard_admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Dashboard</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       
       <div class="brand_color">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="titlepage">
                        <h2>Dashboard</h2>
                    </div>
                </div>
            </div>
        </div>
    </div>
      <!-- cards --> 
      <div class="service">
         <div class="container">
            <div class="row">
               <div class="col-xl-4 col-lg-4 col-md-4 col-sm-12">
                  <div class="service-box">
                     <h3>Total Profit</h3>
                     <p>LKR <asp:Label ID="lblTotalProfit" runat="server" Text="0"></asp:Label></p>
                      <hr />
                      <%--<a class="btn-link" href="manageorders.aspx">View all Orders</a>--%>
                  </div>
               </div>
               <div class="col-xl-4 col-lg-4 col-md-4 col-sm-12">
                  <div class="service-box">
                     <h3>Total Orders</h3>
                     <p><asp:Label ID="lblTotalOrders" runat="server" Text="0"></asp:Label></p>
                      <hr />
                      <a class="btn-link" href="manageorders.aspx">View all Orders</a>
                  </div>
               </div>
               <div class="col-xl-4 col-lg-4 col-md-4 col-sm-12">
                  <div class="service-box">
                     <h3>Pending Orders</h3>
                     <p><asp:Label ID="lblPendingOrders" runat="server" Text="0"></asp:Label></p>
                      <hr />
                      <a class="btn-link" href="manageorders.aspx?filter=pending">View Pending Orders</a>
                  </div>
               </div>
               <div class="col-xl-4 col-lg-4 col-md-4 col-sm-12">
                  <div class="service-box">
                     <h3>Approved Orders</h3>
                     <p><asp:Label ID="lblApprovedOrders" runat="server" Text="0"></asp:Label></p>
                      <hr />
                      <a class="btn-link" href="manageorders.aspx?filter=approved">View Approved Orders</a>
                  </div>
               </div>
                <div class="col-xl-4 col-lg-4 col-md-4 col-sm-12">
                  <div class="service-box">
                      <a class="btn-link" href="manageorders.aspx">Manage Orders</a>
                      <hr />
                      <a class="btn-link" href="manageitems.aspx">Manage Items</a>
                      <hr />
                      <a class="btn-link" href="managecustomers.aspx">Manage Customers</a>
                  </div>
               </div>

                <div class="col-xl-4 col-lg-4 col-md-4 col-sm-12">
                  <div class="service-box">
                      <a class="btn-link" href="ordersreport.aspx">Total Orders Report</a>
                      <hr />
                      <a class="btn-link" href="ordersreport.aspx?filter=pending">Pending Orders Report</a>
                      <hr />
                      <a class="btn-link" href="incomereport.aspx"> Income Report </a>
                  </div>
               </div>

            </div>
         </div>
      </div>
      <!-- end cards -->

</asp:Content>