<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Userlogin.Master" AutoEventWireup="true" CodeFile="Signup.aspx.cs" Inherits="_Signup" %>
<asp:Content ID="HeaderScript" ContentPlaceHolderID="HeaderScript" runat="server">
     <link rel="stylesheet" href="Theme/fronttheme/assets/vendor/bootstrap-select/css/bootstrap-select.min.css">
   <link rel="stylesheet" href="Scripts/vendor/telinput/css/intlTelInput.css">
    </asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div id="fb-root"></div>
       <!-- Login -->
        <section class="dzsparallaxer auto-init height-is-based-on-content use-loading mode-scroll loaded dzsprx-readyall" data-options="{direction: 'reverse', settings_mode_oneelement_max_offset: '150'}">
            <!-- Parallax Image -->
            <div class="divimage dzsparallaxer--target w-100 u-bg-overlay g-bg-size-cover g-bg-bluegray-opacity-0_3--after keen-bg-img" style="height: 140%; background-image: url(Theme/fronttheme/assets/KeenImg/Skyscrapers.jpg);"></div>
            <!-- End Parallax Image -->

            <div class="container g-pt-100 g-pb-20">
                <div id="notify" class="noty_bar noty_type__info noty_theme__unify--v1--dark noty_close_with_click noty_close_with_button g-mb-25" style="display:none;">
                    <div class="noty_body">
                      <div class="g-mr-20">
                        <div class="noty_body__icon">
                          <i class="hs-admin-info"></i>
                        </div>
                      </div>

                      <div id="er-message">Hi, welcome to Unify. This is example of Toastr notification box.</div>
                    </div>

                   
                </div>
                <div class="row justify-content-between ">
                    <div class="col-md-6 col-lg-6 flex-md-unordered align-self-center g-mb-80">
                        <div class="u-shadow-v21  rounded g-pa-50--lg keen-form-bg keen-style g-pa-30">
                            <header class="text-center mb-4">
                                <h2 class="h2 g-color-black g-font-weight-600 keen-cw">Signup</h2>
                            </header>
                            <button onclick="loginByFacebook();"  class="btn btn-block u-btn-facebook rounded text-uppercase g-py-13 g-mb-15 " type="button">
                                    <i class="mr-3 fa fa-facebook"></i>
                                    <span class="g-hidden-xs-down keen-cw">สมัครผ่าน</span> Facebook
                                  </button>
                            <a class="btn btn-block u-btn-linkedin rounded text-uppercase g-py-13 g-mb-30"  href="//www.linkedin.com/oauth/v2/authorization?response_type=code&client_id=81h1zat2gc50un&redirect_uri=https%3A%2F%2Fmember-stg.keenprofile.com%2Fhook_api%2Fsignin-linkedin.aspx">
                                    <i class="mr-3 fa fa-linkedin"></i>
                                    <span class="g-hidden-xs-down keen-cw">สมัครผ่าน</span> Linkedin
                                  </a>
                            <div class="d-flex justify-content-center text-center g-mb-30">
                                <div class="d-inline-block align-self-center g-width-50 g-height-1 g-bg-gray-light-v1"></div>
                                <span class="align-self-center g-color-gray-dark-v3 mx-4">OR</span>
                                <div class="d-inline-block align-self-center g-width-50 g-height-1 g-bg-gray-light-v1"></div>
                            </div>
                            <!-- Form -->
                            <div class="g-py-15">
                                <div class="row">
                                    <div class="g-mb-20 col-sm-12 col-lg-6 keen-form-block">
                                        <input class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v3 rounded g-py-15 g-px-15 keen-required" type="text" placeholder="ชื่อ">
                                        <p class="text-validate" >กรุณากรอกชื่อของท่าน</p>
                                    </div>

                                    <div class="g-mb-20 col-sm-12 col-lg-6 keen-form-block">
                                        <input class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v3 rounded g-py-15 g-px-15 keen-required" type="text" placeholder="นามสกุล">
                                        <p class="text-validate" >กรุณากรอกนามสกุลของท่าน</p>
                                    </div>
                                </div>

                                <div class="form-group g-mb-20">
                                   <%-- <select class="js-custom-select u-select-v1 g-brd-gray-light-v3 g-color-gray-dark-v5 rounded g-py-12" style="width: 100%;" data-placeholder="Gender" data-open-icon="fa fa-angle-down" data-close-icon="fa fa-angle-up">
                                    <option></option>
                                    <option value="First Option">Male</option>
                                    <option value="Second Option">Female</option>
                                    <option value="Third Option">Other</option>
                                  </select>--%>

                                    <div class="form-group  g-pos-rel  g-rounded-4 mb-0 keen-no-boder  keen-form-block">
                                      <select id="usergender" runat="server" class="js-select u-select--v3-select u-sibling w-100 keen-required" data-validtype="select" required="required" title="เพศ" style="display: none;">
                                       
                                        <option value="1" data-content='<span class="d-flex align-items-center w-100"><span>ชาย</span></span>'>ชาย
                                        </option>
                                        <option value="2" data-content='<span class="d-flex align-items-center w-100"><span>หญิง</span></span>'>หญิง
                                        </option>
                                        <option value="3" data-content='<span class="d-flex align-items-center w-100"><span>ไม่ระบุ</span></span>'>ไม่ระบุ
                                        </option>
                                       
                                      </select>

                                      <div class="d-flex align-items-center g-absolute-centered--y g-right-0 g-color-gray-light-v6 g-color-lightblue-v9--sibling-opened g-mr-15">
                                        <i class="hs-admin-angle-down"></i>
                                      </div>
                                           <p class="text-validate" >กรุณาระบุเพศ ของท่าน</p>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-sm-6 col-md-12 col-lg-6 g-mb-20 keen-form-block keen-form-block">
                                        <div class="form-group  g-pos-rel  g-rounded-4 mb-0 keen-no-boder">
                                              <select id="usermonth" runat="server" class="js-select u-select--v3-select u-sibling w-100 keen-required" data-validtype="select" required="required"  title="เดือนเกิด" style="display: none;">
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
                                               <p class="text-validate" >กรุณาเลือกเดือนเกิด</p>
                                    </div>
                                    <div class="col g-mb-20 keen-form-block">
                                      <input id="userday" runat="server" class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v3 rounded g-py-15 g-px-15 keen-required" data-validtype="number,date"  maxlength="2"  type="text" placeholder="วันเกิด">
                                               <p class="text-validate" >กรุณากรอกวันที่ เป็นตัวเลข 2 หลัก</p>
                                    </div>
                                   <div class="col g-mb-20  keen-form-block">
                                    <input id="useryear" runat="server" class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v3 rounded g-py-15 g-px-15 keen-required" type="text" placeholder="ปีเกิด ค.ศ."  maxlength="4"  data-validtype="number,year">
                                              <p class="text-validate" >กรุณากรอกปีเกิด เป็น ค.ศ. เช่น 1982</p>
                                    </div>

                             
                                </div>


                                <div class="g-mb-20 keen-form-block">
                                    <input id="signup_email" runat="server" class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v3 rounded g-py-15 g-px-15 keen-required" type="text" data-validtype="email" placeholder="อีเมล์">
                                       <p class="text-validate" >อีเมล์ไม่ถูกต้อง</p>
                                </div>

                                <div class="g-mb-20 keen-form-block">
                                    <input id="userpassword"  runat="server" class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v3 rounded g-py-15 g-px-15 keen-required" type="password" placeholder="รหัสผ่าน 8-15 ตัวอักษรมีและอย่างน้อย 1 ตัวอักษรตัวใหญ่"  data-validtype="password">
                                       <p class="text-validate" >กรุณาใส่รหัสผ่าน 8-15 ตัวอักษรและมีอักษรตัวใหญ่ อย่างน้อย 1 ตัวอักษร</p>
                                </div>

                                <div class="g-mb-20 keen-form-block">
                                    <input class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v3 rounded g-py-15 g-px-15 keen-required" type="password" placeholder="ยืนยัน รหัสผ่าน" data-validtype="equal-password" data-equal="MainContent_userpassword">
                                       <p class="text-validate" >กรุณายืนยันรหัสผ่านให้ถูกต้อง</p>
                                </div>

                                 <div class="g-mb-20 keen-form-block">
                                    <input name="userlocation" id="userlocation" class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v3 rounded g-py-15 g-px-15 keen-required" type="text" placeholder="เมืองและประเทศปัจจุบัน">
                                     <input type="hidden" name="country_code" id="country_code"  runat="server" value="" class="keen-required" data-validtype="hidden">

                                       <input type="hidden" name="area_location" id="area_location" runat="server" value="" class="keen-required" data-validtype="hidden">
                                      <input type="hidden" name="area_location2" id="area_location2" runat="server" value="" >

                                        <p class="text-validate" >กรุณาเลือก เมืองและประเทศปัจจุบันของท่าน</p>
                                </div>

                                 <div class="g-mb-20 keen-form-block">
                                    <input name="userphone" id="userphone" runat="server" maxlength="12"  class="keen-input-phone form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v3 rounded g-py-15 g-px-15 keen-required" type="text" placeholder="เบอร์ติดต่อ" data-validtype="phone">
                                     <p class="text-validate" >เบอร์โทรศัพท์ไม่ถูกต้อง</p>
                                </div>

                                <div class="mb-1 keen-form-block">
                                    <label class="form-check-inline u-check g-color-gray-dark-v5 g-font-size-13 g-pl-25 mb-2">
                                        <input class="g-hidden-xs-up g-pos-abs g-top-0 g-left-0 keen-required" type="checkbox" checked="checked" data-validtype="checkbox">
                                        <div class="u-check-icon-checkbox-v6 g-absolute-centered--y g-left-0">
                                          <i class="fa" data-check-icon="&#xf00c"></i>
                                        </div>
                                        I accept the <a href="http://www.keenprofile.com/terms-and-conditions/" target="_blank">Terms and Conditions</a>
                                      </label>
                                       <p class="text-validate" >กรุณา check เพื่อยอมรับเงื่อนไข</p>
                                </div>

                               <asp:Button ID="btn_submit" runat="server" OnClientClick="return KeenValidate()" OnClick="btnSignup_Click" CssClass="btn btn-md btn-block u-btn-primary rounded g-py-13 keen-btn-primary" Text="สมัครสมาชิก" ></asp:Button>

<%--                                <button onclick="return KeenValidate();" class="btn btn-block u-btn-primary rounded g-py-13 keen-btn-primary" type="button">สมัครสมาชิก</button>--%>
                            </div>
                            <!-- End Form -->

                            <footer class="text-center">
                                <p class="g-color-gray-dark-v5 mb-0">เป็นสมาชิก KeenProfile อยู่แล้ว? <a class="g-font-weight-600" href="/Login">เข้าสู่ระบบ</a>
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
      <script  src="Scripts/vendor/telinput/js/intlTelInput.min.js" type="text/javascript"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCZIk2xiS6rpx3P_Yf09edwDC3CKc6gKcY&libraries=places&callback=initAutocomplete&language=en" sync="" defer=""></script>
     <script id="google.map.api" src="Scripts/vendor/googlelocation/keen.google.map.api.js" type="text/javascript" auto-location="true" ></script>
     <script  src="Scripts/vendor/keenprofile/keen.validate.js" type="text/javascript"  ></script>
     <script src=//js.maxmind.com/js/apis/geoip2/v2.1/geoip2.js type=text/javascript></script>
      <script  type="text/javascript">

          window.fbAsyncInit = function () {
              FB.init({
                  appId: '358756381252009',
                  status: true, // check login status
                  cookie: true, // enable cookies to allow the server to access the session
                  xfbml: true, // parse XFBML
                  oauth: true // enable OAuth 2.0
              });
          };
          (function () {
              var e = document.createElement('script'); e.async = true;
              e.src = document.location.protocol +
                  '//connect.facebook.net/en_US/all.js';
              $('#fb-root').prepend(e);
              // document.getElementById('fb-root').appendChild(e);
          }());

          function loginByFacebook() {
              FB.login(function (response) {
                  if (response.authResponse) {
                      FacebookLoggedIn(response);
                  } else {
                      console.log('User cancelled login or did not fully authorize.');
                  }
              }, { scope: 'public_profile,user_friends,email' });
          }

          function FacebookLoggedIn(response) {
              var loc = '/hook_api/facebookcallback.aspx';
              if (loc.indexOf('?') > -1)
                  window.location = loc + '&authprv=facebook&access_token=' + response.authResponse.accessToken;
              else
                  window.location = loc + '?authprv=facebook&access_token=' + response.authResponse.accessToken;
          }

    $(document).on('ready', function () {
      // initialization of custom select
      $('.js-select').selectpicker();
  
          $("#MainContent_userphone").intlTelInput({
              initialCountry: "auto",
              geoIpLookup: function (i) {
                  $.get("https://ipinfo.io", function () { }, "jsonp").always(function (n) {
                      var t = n && n.country ? n.country : "";
                      i(t)
                  })
              },
              utilsScript: "Scripts/vendor/telinput/js/utils.js",
              nationalMode: !1
          });
          //var CURR_DISPLAY = "th"



        //err response
          var error = getParameterByName('loginfailed');
          var social = getParameterByName('s');

          var ele = $('#er-message');

          if (error) {


              if (error == "already") {
                  ele.html("อีเมล์ที่ท่านใช้สมัคร ได้ถูกใช้งานแล้ว การสามารถคลิ๊กที่ <a href=\"Login\">เข้าสู่ระบบ</a> หากท่านจำรหัสผ่านไม่ได้ คลิ๊ก <a href=\"Forgot\">ลืมรหัสผ่าน</a>");
              }

              if (error == "sociallogin") {
                  if (social) {
                      switch (social) {

                          case "facebook":
                              ele.html("บัญชีของท่าน ลงทะเบียนโดย Facebook ท่านสามารถกดปุ่ม \"เข่าสู่ระบบผ่าน Facebook\" เพ่ื่อเข้าสู่ระบบ หากท่านต้องการ เพื่อเข้าระบบแบบปกติ คลิ๊ก <a href=\"Forgot\">เปลี่ยนรหัสผ่าน</a> ");

                              break;
                          case "google":
                              ele.html("บัญชีของท่าน ลงทะเบียนโดย Google ท่านสามารถกดปุ่ม \"เข่าสู่ระบบผ่าน Facebook\" เพ่ื่อเข้าสู่ระบบ หากท่านต้องการ เพื่อเข้าระบบแบบปกติ คลิ๊ก <a href=\"Forgot\">เปลี่ยนรหัสผ่าน</a> ");

                              break;
                          case "linkedin":
                              ele.html("บัญชีของท่าน ลงทะเบียนโดย LinkedIn ท่านสามารถกดปุ่ม \"เข่าสู่ระบบผ่าน Facebook\" เพ่ื่อเข้าสู่ระบบ หากท่านต้องการ เพื่อเข้าระบบแบบปกติ คลิ๊ก <a href=\"Forgot\"เปลี่ยนรหัสผ่าน</a> ");

                              break;
                      }
                  }
              }

              $('#notify').show();

              return false;
          }

          });

         
  </script>

   
 </asp:Content>

