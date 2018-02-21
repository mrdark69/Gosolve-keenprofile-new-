<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Userlogin.Master" AutoEventWireup="true" CodeFile="Signup.aspx.cs" Inherits="_Signup" %>
<asp:Content ID="HeaderScript" ContentPlaceHolderID="HeaderScript" runat="server">
     <link rel="stylesheet" href="Theme/fronttheme/assets/vendor/bootstrap-select/css/bootstrap-select.min.css">
   
    </asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
       <!-- Login -->
        <section class="dzsparallaxer auto-init height-is-based-on-content use-loading mode-scroll loaded dzsprx-readyall" data-options="{direction: 'reverse', settings_mode_oneelement_max_offset: '150'}">
            <!-- Parallax Image -->
            <div class="divimage dzsparallaxer--target w-100 u-bg-overlay g-bg-size-cover g-bg-bluegray-opacity-0_3--after keen-bg-img" style="height: 140%; background-image: url(Theme/fronttheme/assets/KeenImg/Skyscrapers.jpg);"></div>
            <!-- End Parallax Image -->

            <div class="container g-pt-100 g-pb-20">
                <div class="row justify-content-between ">
                    <div class="col-md-6 col-lg-6 flex-md-unordered align-self-center g-mb-80">
                        <div class="u-shadow-v21  rounded g-pa-50 keen-form-bg keen-style">
                            <header class="text-center mb-4">
                                <h2 class="h2 g-color-black g-font-weight-600 keen-cw">Signup</h2>
                            </header>
                            <button class="btn btn-block u-btn-facebook rounded text-uppercase g-py-13 g-mb-15 " type="button">
                                    <i class="mr-3 fa fa-facebook"></i>
                                    <span class="g-hidden-xs-down keen-cw">สมัครผ่าน</span> Facebook
                                  </button>
                            <button class="btn btn-block u-btn-linkedin rounded text-uppercase g-py-13 g-mb-30" type="button">
                                    <i class="mr-3 fa fa-linkedin"></i>
                                    <span class="g-hidden-xs-down keen-cw">สมัครผ่าน</span> Linkedin
                                  </button>
                            <div class="d-flex justify-content-center text-center g-mb-30">
                                <div class="d-inline-block align-self-center g-width-50 g-height-1 g-bg-gray-light-v1"></div>
                                <span class="align-self-center g-color-gray-dark-v3 mx-4">OR</span>
                                <div class="d-inline-block align-self-center g-width-50 g-height-1 g-bg-gray-light-v1"></div>
                            </div>
                            <!-- Form -->
                            <div class="g-py-15">
                                <div class="row">
                                    <div class="col g-mb-20">
                                        <input class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v3 rounded g-py-15 g-px-15" type="text" placeholder="ชื่อ">
                                    </div>

                                    <div class="col g-mb-20">
                                        <input class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v3 rounded g-py-15 g-px-15" type="text" placeholder="นามสกุล">
                                    </div>
                                </div>

                                <div class="form-group g-mb-20">
                                   <%-- <select class="js-custom-select u-select-v1 g-brd-gray-light-v3 g-color-gray-dark-v5 rounded g-py-12" style="width: 100%;" data-placeholder="Gender" data-open-icon="fa fa-angle-down" data-close-icon="fa fa-angle-up">
                                    <option></option>
                                    <option value="First Option">Male</option>
                                    <option value="Second Option">Female</option>
                                    <option value="Third Option">Other</option>
                                  </select>--%>

                                    <div class="form-group  g-pos-rel  g-rounded-4 mb-0 keen-no-boder">
                                      <select class="js-select u-select--v3-select u-sibling w-100" required="required" title="เพศ" style="display: none;">
                                        <option value="1" data-content='<span class="d-flex align-items-center w-100"><i class="hs-admin-rocket g-font-size-18 g-mr-15"></i><span>Male</span></span>'>Male
                                        </option>
                                        <option value="2" data-content='<span class="d-flex align-items-center w-100"><i class="hs-admin-headphone-alt g-font-size-18 g-mr-15"></i><span>Female</span></span>'>Female
                                        </option>
                                        <option value="3" data-content='<span class="d-flex align-items-center w-100"><i class="hs-admin-shift-right g-font-size-18 g-mr-15"></i><span>Other</span></span>'>Other
                                        </option>
                                       
                                      </select>

                                      <div class="d-flex align-items-center g-absolute-centered--y g-right-0 g-color-gray-light-v6 g-color-lightblue-v9--sibling-opened g-mr-15">
                                        <i class="hs-admin-angle-down"></i>
                                      </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-sm-6 col-md-12 col-lg-6 g-mb-20">
                                    


                                         <div class="form-group  g-pos-rel  g-rounded-4 mb-0 keen-no-boder">
                                      <select class="js-select u-select--v3-select u-sibling w-100" required="required" title="เดือนเกิด" style="display: none;">
                                        <option value="1" data-content='January'>January</option>
                                        <option value="2" data-content='February'>February</option>
                                          <option value="3" data-content='March'>March</option>
                                          <option value="4" data-content='April'>April</option>
                                          <option value="5" data-content='May'>May</option>
                                          <option value="6" data-content='June'>June</option>
                                          <option value="7" data-content='July'>July</option>
                                          <option value="8" data-content='August'>August</option>
                                          <option value="9" data-content='September'>September</option>
                                          <option value="10" data-content='October'>October</option>
                                          <option value="11" data-content='November'>November</option>
                                          <option value="12" data-content='December'>December</option>
                                       
                                      </select>

                                      <div class="d-flex align-items-center g-absolute-centered--y g-right-0 g-color-gray-light-v6 g-color-lightblue-v9--sibling-opened g-mr-15">
                                        <i class="hs-admin-angle-down"></i>
                                      </div>
                                    </div>
                                    </div>

                                    <div class="col g-mb-20">
                                      <div class="form-group  g-pos-rel  g-rounded-4 mb-0 keen-no-boder">
                                      <select class="js-select u-select--v3-select u-sibling w-100" required="required" title="วันเกิด" style="display: none;">
                                        <option value="1" data-content='1'>1</option>
                                        <option value="2" data-content='2'>2</option>
                                          <option value="3" data-content='3'>3</option>
                                          <option value="4" data-content='4'>4</option>
                                          <option value="5" data-content='5'>5</option>
                                          <option value="6" data-content='6'>6</option>
                                          <option value="7" data-content='7'>7</option>
                                          <option value="8" data-content='8'>8</option>
                                          <option value="9" data-content='9'>9</option>
                                          <option value="10" data-content='10'>10</option>
                                          <option value="11" data-content='11'>1</option>
                                          <option value="12" data-content='12'>12</option>
                                       <option value="12" data-content='12'>12</option>
                                          <option value="13" data-content='13'>13</option>
                                          <option value="14" data-content='14'>14</option>
                                          <option value="15" data-content='15'>15</option>
                                          <option value="16" data-content='16'>16</option>
                                          <option value="17" data-content='17'>17</option>
                                          <option value="18" data-content='18'>18</option>
                                          <option value="19" data-content='19'>19</option>
                                          <option value="20" data-content='20'>20</option>
                                          <option value="21" data-content='21'>21</option>
                                          <option value="22" data-content='22'>22</option>
                                          <option value="23" data-content='23'>23</option>
                                          <option value="24" data-content='24'>24</option>
                                          <option value="25" data-content='25'>25</option>
                                          <option value="26" data-content='26'>26</option>
                                          <option value="27" data-content='27'>27</option>
                                          <option value="28" data-content='28'>28</option>
                                          <option value="29" data-content='29'>29</option>
                                          <option value="30" data-content='30'>30</option>
                                          <option value="31" data-content='31'>31</option>
                                      </select>

                                      <div class="d-flex align-items-center g-absolute-centered--y g-right-0 g-color-gray-light-v6 g-color-lightblue-v9--sibling-opened g-mr-15">
                                        <i class="hs-admin-angle-down"></i>
                                      </div>
                                    </div>
                                    </div>

                                    <div class="col g-mb-20">
                                         <div class="form-group  g-pos-rel  g-rounded-4 mb-0 keen-no-boder">
                                      <select class="js-select u-select--v3-select u-sibling w-100" required="required" title="ปีเกิด" style="display: none;">
                                          <asp:Literal ID="yearlist" runat="server"></asp:Literal>
                                       
                                       
                                      </select>

                                      <div class="d-flex align-items-center g-absolute-centered--y g-right-0 g-color-gray-light-v6 g-color-lightblue-v9--sibling-opened g-mr-15">
                                        <i class="hs-admin-angle-down"></i>
                                      </div>
                                    </div>
                                    </div>
                                </div>


                                <div class="g-mb-20">
                                    <input class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v3 rounded g-py-15 g-px-15" type="text" placeholder="อีเมล์ address">
                                </div>

                                <div class="g-mb-20">
                                    <input class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v3 rounded g-py-15 g-px-15" type="text" placeholder="รัหสผ่าน">
                                </div>

                                <div class="g-mb-20">
                                    <input class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v3 rounded g-py-15 g-px-15" type="text" placeholder="ยืนยัน รหัสผ่าน">
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

                               

                                <button class="btn btn-block u-btn-primary rounded g-py-13 keen-btn-primary" type="button">Signup</button>
                            </div>
                            <!-- End Form -->

                            <footer class="text-center">
                                <p class="g-color-gray-dark-v5 mb-0">เป็นสมาชิก KeenProfile อยู่แล้ว? <a class="g-font-weight-600" href="http://member.keenprofile.com/Login">เข้าสู่ระบบ</a>
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
<asp:Content ID="FooterScript" ContentPlaceHolderID="ContentFooter" runat="server">
     <script src="Theme/fronttheme/assets/vendor/bootstrap-select/js/bootstrap-select.min.js"></script>
      <script>
    $(document).on('ready', function () {
      // initialization of custom select
      $('.js-select').selectpicker();
  
      
    });
  </script>
 </asp:Content>

