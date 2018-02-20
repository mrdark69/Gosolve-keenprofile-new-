<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Userlogin.Master" AutoEventWireup="true" CodeFile="Signup.aspx.cs" Inherits="_Signup" %>
<asp:Content ID="HeaderScript" ContentPlaceHolderID="HeaderScript" runat="server">
    
    </asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
       <!-- Login -->
        <section class="dzsparallaxer auto-init height-is-based-on-content use-loading mode-scroll loaded dzsprx-readyall" data-options="{direction: 'reverse', settings_mode_oneelement_max_offset: '150'}">
            <!-- Parallax Image -->
            <div class="divimage dzsparallaxer--target w-100 u-bg-overlay g-bg-size-cover g-bg-bluegray-opacity-0_3--after keen-bg-img" style="height: 140%; background-image: url(Theme/frontheme/assets/KeenImg/Skyscrapers.jpg);"></div>
            <!-- End Parallax Image -->

            <div class="container g-pt-100 g-pb-20">
                <div class="row justify-content-between ">
                    <div class="col-md-6 col-lg-6 flex-md-unordered align-self-center g-mb-80">
                        <div class="u-shadow-v21 g-bg-white rounded g-pa-50 keen-form-bg keen-style">
                            <header class="text-center mb-4">
                                <h2 class="h2 g-color-black g-font-weight-600 keen-cw">Signup</h2>
                            </header>
                            <button class="btn btn-block u-btn-facebook rounded text-uppercase g-py-13 g-mb-15 " type="button">
                                    <i class="mr-3 fa fa-facebook"></i>
                                    <span class="g-hidden-xs-down keen-cw">Login with</span> Facebook
                                  </button>
                            <button class="btn btn-block u-btn-linkedin rounded text-uppercase g-py-13 g-mb-30" type="button">
                                    <i class="mr-3 fa fa-linkedin"></i>
                                    <span class="g-hidden-xs-down keen-cw">Login with</span> Twitter
                                  </button>
                            <div class="d-flex justify-content-center text-center g-mb-30">
                                <div class="d-inline-block align-self-center g-width-50 g-height-1 g-bg-gray-light-v1"></div>
                                <span class="align-self-center g-color-gray-dark-v3 mx-4">OR</span>
                                <div class="d-inline-block align-self-center g-width-50 g-height-1 g-bg-gray-light-v1"></div>
                            </div>
                            <!-- Form -->
                            <form class="g-py-15">
                                <div class="row">
                                    <div class="col g-mb-20">
                                        <input class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v3 rounded g-py-15 g-px-15" type="text" placeholder="First name">
                                    </div>

                                    <div class="col g-mb-20">
                                        <input class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v3 rounded g-py-15 g-px-15" type="text" placeholder="Last name">
                                    </div>
                                </div>

                                <div class="form-group g-mb-20">
                                    <select class="js-custom-select u-select-v1 g-brd-gray-light-v3 g-color-gray-dark-v5 rounded g-py-12" style="width: 100%;" data-placeholder="Gender" data-open-icon="fa fa-angle-down" data-close-icon="fa fa-angle-up">
                        <option></option>
                        <option value="First Option">Male</option>
                        <option value="Second Option">Female</option>
                        <option value="Third Option">Other</option>
                      </select>
                                </div>

                                <div class="row">
                                    <div class="col-sm-6 col-md-12 col-lg-6 g-mb-20">
                                        <select class="js-custom-select u-select-v1 g-brd-gray-light-v3 g-color-gray-dark-v5 rounded g-py-12" style="width: 100%;" data-placeholder="Month" data-open-icon="fa fa-angle-down" data-close-icon="fa fa-angle-up">
                          <option></option>
                          <option value="First Option">January</option>
                          <option value="Second Option">February</option>
                          <option value="Third Option">March</option>
                          <option value="Fourth Option">April</option>
                          <option value="Fifth Option">May</option>
                          <option value="Sixth Option">June</option>
                          <option value="Seventh Option">July</option>
                          <option value="Eighth Option">August</option>
                          <option value="Ninth Option">September</option>
                          <option value="Tenth Option">October</option>
                          <option value="Eleventh Option">November</option>
                          <option value="Twelfth Option">December</option>
                        </select>
                                    </div>

                                    <div class="col g-mb-20">
                                        <input class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v3 rounded g-py-15 g-px-15" type="text" placeholder="Day">
                                    </div>

                                    <div class="col g-mb-20">
                                        <input class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v3 rounded g-py-15 g-px-15" type="text" placeholder="Year">
                                    </div>
                                </div>

                                <div class="g-mb-20">
                                    <input class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v3 rounded g-py-15 g-px-15" type="text" placeholder="Username">
                                </div>

                                <div class="g-mb-20">
                                    <input class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v3 rounded g-py-15 g-px-15" type="text" placeholder="Email address">
                                </div>

                                <div class="g-mb-20">
                                    <input class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v3 rounded g-py-15 g-px-15" type="text" placeholder="Password">
                                </div>

                                <div class="g-mb-20">
                                    <input class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v3 rounded g-py-15 g-px-15" type="text" placeholder="Confirm password">
                                </div>

                                <div class="mb-1">
                                    <label class="form-check-inline u-check g-color-gray-dark-v5 g-font-size-13 g-pl-25 mb-2">
                        <input class="g-hidden-xs-up g-pos-abs g-top-0 g-left-0" type="checkbox">
                        <div class="u-check-icon-checkbox-v6 g-absolute-centered--y g-left-0">
                          <i class="fa" data-check-icon="&#xf00c"></i>
                        </div>
                        I accept the <a href="#!">Terms and Conditions</a>
                      </label>
                                </div>

                                <div class="mb-3">
                                    <label class="form-check-inline u-check g-color-gray-dark-v5 g-font-size-13 g-pl-25 mb-2">
                        <input class="g-hidden-xs-up g-pos-abs g-top-0 g-left-0" type="checkbox">
                        <div class="u-check-icon-checkbox-v6 g-absolute-centered--y g-left-0">
                          <i class="fa" data-check-icon="&#xf00c"></i>
                        </div>
                        Subscribe to our newsletter
                      </label>
                                </div>

                                <button class="btn btn-block u-btn-primary rounded g-py-13 keen-btn-primary" type="button">Signup</button>
                            </form>
                            <!-- End Form -->

                            <footer class="text-center">
                                <p class="g-color-gray-dark-v5 mb-0">Already have an account? <a class="g-font-weight-600" href="page-login-8.html">signin</a>
                                </p>
                            </footer>
                        </div>
                    </div>

                    <div class="col-md-6 flex-md-first g-mt-30--lg g-mb-80 g-hidden-xs-down">
                        <div class="mb-5">
                            <h1 class="h3 g-color-white g-font-weight-600 mb-3">Profitable contracts,<br>invoices &amp; payments for the best cases!</h1>
                            <p class="g-color-white-opacity-0_8 g-font-size-12 text-uppercase">Trusted by 31,000+ users globally</p>
                        </div>

                        <div class="row">
                            <div class="col-md-11 col-lg-9">
                                <!-- Icon Blocks -->
                                <div class="media mb-4">
                                    <div class="d-flex mr-4">
                                        <span class="align-self-center u-icon-v1 u-icon-size--lg g-color-primary">
                            <i class="icon-finance-168 u-line-icon-pro"></i>
                          </span>
                                    </div>
                                    <div class="media-body align-self-center">
                                        <p class="g-color-white mb-0">Reliable contracts, multifanctionality &amp; best usage of Unify template</p>
                                    </div>
                                </div>
                                <!-- End Icon Blocks -->

                                <!-- Icon Blocks -->
                                <div class="media mb-5">
                                    <div class="d-flex mr-4">
                                        <span class="align-self-center u-icon-v1 u-icon-size--lg g-color-primary">
                            <i class="icon-finance-193 u-line-icon-pro"></i>
                          </span>
                                    </div>
                                    <div class="media-body align-self-center">
                                        <p class="g-color-white mb-0">Secure &amp; integrated options to create individual &amp; business websites</p>
                                    </div>
                                </div>
                                <!-- End Icon Blocks -->

                                <!-- Testimonials -->
                                <blockquote class="u-blockquote-v1 g-color-main rounded g-pl-60 g-pr-30 g-py-25 g-mb-40">Look no further you came to the right place. Unify offers everything you have dreamed of in one package.</blockquote>
                                <div class="media">
                                    <img class="d-flex align-self-center rounded-circle g-width-40 g-height-40 mr-3" src="Theme/fronttheme/assets/img-temp/100x100/img12.jpg" alt="Image Description">
                                    <div class="media-body align-self-center">
                                        <h4 class="h6 g-color-primary g-font-weight-600 g-mb-0">Alex Pottorf</h4>
                                        <em class="g-color-white g-font-style-normal g-font-size-12">Web Developer</em>
                                    </div>
                                </div>
                                <!-- End Testimonials -->
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!-- End Login -->
   
</asp:Content>


