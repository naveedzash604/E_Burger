<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/main_template.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="E_Burger.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>E-Burger - Home</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <!-- end header -->

    <div class="container">
          <div class="row mb-2">
                <div class="col-md-6"> 
                  <div class="card flex-md-row mb-4 box-shadow h-md-250"> <span id="timerLabel" runat="server"></span>
                      <div class="card-body d-flex flex-column align-items-start">
                       <img class="first-slide" src="images/banner1.jpg" alt="First slide"> 
                          <br />
                          <p class="font-weight-bold">Join Royal Perks - it's better than ever!</p>
                          <p class="font-weight-normal">Exclusive Delivery offer at E- Burger</p>
                          <asp:Button ID="btn1" runat="server" class="btn btn-outline-danger" 
                              Text="Sign Up Now" OnClick="btn1_Click" />
                          </div>
                      </div>
                </div>

              <div class="col-md-6">
                  <div class="card flex-md-row mb-4 box-shadow h-md-250">
                    <div class="card-body d-flex flex-column align-items-start">
                        <img class="first-slide" src="images/banner.jpg" alt="First slide">
                          <br />
                          <p class="font-weight-bold">Join Royal Perks - it's better than ever!</p>
                          <p class="font-weight-normal">Exclusive Delivery offer at E- Burger</p>
                        <asp:Button ID="btn2" runat="server" class="btn btn-outline-danger" 
                            Text="Order Now" OnClick="btn2_Click" />
                    </div>
                    </div>
                </div>

                <div class="col-md-6">
                  <div class="card flex-md-row mb-4 box-shadow h-md-250">
                      <div class="card-body d-flex flex-column align-items-start">
                       <img class="first-slide" src="images/banner.jpg" alt="First slide">
                          <br />
                          <p class="font-weight-bold">Join Royal Perks - it's better than ever!</p>
                          <p class="font-weight-normal">Exclusive Delivery offer at E- Burger</p>
                          <asp:Button ID="btn3" runat="server" class="btn btn-outline-danger" 
                              Text="Order Now" OnClick="btn3_Click" />
                          </div>
                      </div>
                </div>

              <div class="col-md-6">
                  <div class="card flex-md-row mb-4 box-shadow h-md-250">
                    <div class="card-body d-flex flex-column align-items-start">
                        <img class="first-slide" src="images/banner2.jpg" alt="First slide"> 
                          <br />
                          <p class="font-weight-bold">Join Royal Perks - it's better than ever!</p>
                          <p class="font-weight-normal">Exclusive Delivery offer at E- Burger</p>
                          <asp:Button ID="btn4" runat="server" class="btn btn-outline-danger" 
                            Text="Join Now" OnClick="btn4_Click" />
                    </div>
                    </div>
                </div>
            </div>

              <hr class="featurette-divider">

        <%--<div class="row">
            <div class="col-12">
                <h2 class="title">MOST OF POPULER</h2>
            </div>
        </div>

        <div class="row">
            <div class="col-md-3">
                <div class="text-center category">
                    <img class="img-fluid" src="images/386487547cheese burger.jpg" />
                </div>
            </div>
            <div class="col-md-3">
                <div class="text-center category">
                    <img class="img-fluid" src="images/584496264cheese burger with chicken.png" />
                </div>
            </div>
            <div class="col-md-3">
                <div class="text-center category">
                    <img class="img-fluid" src="images/386487547cheese burger.jpg" />
                </div>
            </div>
            <div class="col-md-3">
                <div class="text-center category">
                    <img class="img-fluid" src="images/584496264cheese burger with chicken.png" />
                </div>
            </div>
            <div class=" col-md-12 mb-5 ">
                <a href="products.aspx" class="send" Text="LOAD MORE"></a>
           </div> </div>--%>
        </div>

</asp:Content>