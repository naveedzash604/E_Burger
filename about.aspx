<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/main_template.Master" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="E_Burger.about" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>E-Burger - About</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">\
    
    <div class="brand_color">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="titlepage">
                        <h2>About</h2>
                    </div>
                </div>
            </div>
        </div>

    </div>


<div class="about">
   <div class="container">
      <div class="row">
         <dir class="col-xl-6 col-lg-6 col-md-12 col-sm-12">
            <div class="about_box">
               <figure><img src="images/banner5.jpg"/></figure>
            </div>
         </dir>
          <dir class="col-xl-6 col-lg-6 col-md-12 col-sm-12">
            <div class="about_box">
               <h3>Who is E - Burger</h3>
               <p>The origin of hamburger is unknown, but the hamburger patty and sandwich were probably brought by 19th-century German immigrants to the United States, where in a matter of decades the hamburger came to be considered an archetypal American food. The importance of the hamburger in American popular culture is indicated by its virtual ubiquity at backyard barbecues and on fast-food restaurant menus and by the proliferation of so-called hamburger stands and restaurants. Some chains, such as McDonald’s, Burger King, and Wendy’s, proliferated worldwide.</p>
            </div>
         </dir> 
      </div>
   </div>
</div>      
</asp:Content>