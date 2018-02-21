<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Userlogin.Master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Login" %>
<asp:Content ID="HeaderScript" ContentPlaceHolderID="HeaderScript" runat="server">
    
    </asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">



     <!-- Login -->
        <section class="dzsparallaxer auto-init height-is-based-on-content use-loading mode-scroll loaded dzsprx-readyall" data-options="{direction: 'reverse', settings_mode_oneelement_max_offset: '150'}">
            <!-- Parallax Image -->
            <div class="divimage dzsparallaxer--target w-100 u-bg-overlay g-bg-size-cover g-bg-bluegray-opacity-0_3--after keen-bg-img" style="height: 140%; background-image: url(Theme/fronttheme/assets/KeenImg/Skyscrapers.jpg);"></div>
            <!-- End Parallax Image -->
            <div class="container g-py-30 g-py-100--lg">

                <div class="row justify-content-center text-center mb-5">
                    <div class="col-lg-8">
                        <!-- Heading -->
                        <h1 class="g-color-white text-uppercase mb-4 keen-txt">Login or register an account</h1>
                        <div class="d-inline-block g-width-60 g-height-2 mb-4 keen-bg-blue"></div>
                        <p class="lead g-color-white keen-txt">The time has come to bring those ideas and plans to life. This is where we really begin to visualize your napkin sketches and make them into beautiful pixels.</p>
                        <!-- End Heading -->
                    </div>
                </div>
                <div class="row justify-content-center">
                    <div class="col-sm-8 col-lg-6 ">
                        <div class="u-shadow-v21  rounded g-pa-50 keen-form-bg keen-style">
                            <header class="text-center mb-4">
                                <h2 class="h2 g-color-black g-font-weight-600 keen-cw">Login</h2>
                            </header>

                            <!-- Form -->
                            <div class="g-py-15">
                                <button class="btn btn-block u-btn-facebook rounded text-uppercase g-py-13 g-mb-15 " type="button">
                                            <i class="mr-3 fa fa-facebook"></i>
                                            <span class="g-hidden-xs-down keen-cw">เข้าสู่ระบบผ่าน</span> Facebook
                                          </button>
                                <button class="btn btn-block u-btn-linkedin rounded text-uppercase g-py-13 g-mb-30" type="button">
                                            <i class="mr-3 fa fa-linkedin"></i>
                                            <span class="g-hidden-xs-down keen-cw">เข้าสู่ระบบผ่าน</span> Linkedin
                                          </button>
                                <div class="d-flex justify-content-center text-center g-mb-30">
                                    <div class="d-inline-block align-self-center g-width-50 g-height-1 g-bg-gray-light-v1"></div>
                                    <span class="align-self-center g-color-gray-dark-v3 mx-4">OR</span>
                                    <div class="d-inline-block align-self-center g-width-50 g-height-1 g-bg-gray-light-v1"></div>
                                </div>
                                <div class="mb-4">
                                    <label class="g-color-gray-dark-v2 g-font-weight-600 g-font-size-13">อีเมล์:</label>
                                    <input class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v4 g-brd-primary--hover rounded g-py-15 g-px-15" type="email" placeholder="johndoe@gmail.com">
                                </div>

                                <div class="g-mb-35">
                                    <label class="g-color-gray-dark-v2 g-font-weight-600 g-font-size-13">รหัสผ่าน:</label>
                                    <input class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v4 g-brd-primary--hover rounded g-py-15 g-px-15 mb-3" type="password" placeholder="Password">
                                    <div class="row justify-content-between">
                                        <div class="col align-self-center">
                                            
                                        </div>
                                        <div class="col align-self-center text-right ">
                                            <a class="g-font-size-12 " href="#!">ลืมรหัสผ่าน?</a>
                                        </div>
                                    </div>
                                </div>

                                <div class="mb-4">
                                    <button class="btn btn-md btn-block u-btn-primary rounded g-py-13 keen-btn-primary" type="button">เข้าสู่ระบบ</button>
                                </div>


                            </div>
                            <!-- End Form -->

                            <footer class="text-center">
                                <p class="g-color-gray-dark-v5 g-font-size-13 mb-0">ท่านยังไม่ได้เป็นสมาชิก KeenProfile? <a class="g-font-weight-600 " href="page-signup-2.html">สมัครสมาชิก</a>
                                </p>
                            </footer>
                        </div>
                    </div>
                </div>
            </div>

        </section>
        <!-- End Login -->
     
   
   <%-- <asp:Button ID="Button1" CssClass="button" runat="server" OnClick="btnSignup_Click" Text="Sign Up" />--%>
</asp:Content>
