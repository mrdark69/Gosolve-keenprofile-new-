<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Front.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderScript" ContentPlaceHolderID="HeaderScript" runat="server">
    <style type="text/css">

        body,p,h1,h2,h3,ul,li{
             font-family:'Kanit' !important;
        }
       
        .circle{width:80px;height:80px;border-radius:50px;font-size:30px;line-height:80px;text-align:center;background:#fff;
                margin:0 auto;
                color:#000;
                font-weight:bold;
        }
        .divider-wrapper{
            min-height:434px;
        }
        .divider-wrapper p{
            font-size:16px;
            line-height:22px;
            padding-left:4px;
             padding-right:4px;
        }

        .divider-wrapper p a{
           font-weight: bold !important;
    color: #fff;
        }
         .divider-wrapper input{
             font-weight:bold !important;
         }
        .divider-wrapper h2{
            font-size:24px;
        }
        .divider-four{
            background:rgba(40, 57, 101,0.9);
        }

        .read-more-btn{
    font-size: 11px;
    padding: 3px 8px 3px 8px;
    background: #3f51b5;
    border-radius: 10px;
    color: white;
}
        .btn_r3 {
           background-color: #ffa500 !important;
        }
        .btn_coach{
             background-color: #366f9a !important;
        }

        .btn_button{
            font-family:'Kanit' !important;
            font-size:16px !important;
            font-weight:300 !important;
        }


        .fa-btn-3{
            border:none !important;
            font-size:18px !important;
            position:absolute;
            top:303px;
            left:20px;
        }

        .divider-wrapper a{
            display:block;
            margin-top:10px;
            font-family:'Kanit' !important;

        }
        
    </style>
 </asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">



     <!-- Promo Block -->
    <section class="dzsparallaxer auto-init height-is-based-on-content use-loading mode-scroll loaded dzsprx-readyall " data-options='{direction: "fromtop", animation_duration: 25, direction: "reverse"}'>
      <!-- Parallax Image -->
      <div class="divimage dzsparallaxer--target w-100 g-bg-cover g-bg-size-cover g-bg-pos-top-center g-bg-primary-gradient-opacity-v1--after" style="height: 140%; background-image: url(/ssTheme/fronttheme/assets/img-temp/1920x800/img2.jpg);"></div>
      <!-- End Parallax Image -->

      <!-- Promo Block Content -->
      <div class="container g-color-white text-center g-pos-rel g-z-index-1 g-pt-150 g-pb-200">
        <h3 class="h2 g-font-weight-300 mb-0">KEENCareer Finder</h3>
        <h2 class="g-font-weight-700 g-font-size-65 text-uppercase">เริ่มทำแบบประเมิน</h2>
      </div>
      <!-- Promo Block Content -->
    </section>
    <!-- End Promo Block -->

    <!-- Pricing Plans -->
    <section class="g-bg-gray-light-v5">
      <div class="container-fluid g-pb-100">
        <!-- Pricing Plans -->
        <div class="row g-mt-minus-100 g-mb-70">


          <div class="col-md-3 g-mb-30">
            <!-- Article -->
            <article class="u-shadow-v21 u-shadow-v21--hover g-bg-white text-center g-overflow-hidden g-rounded-4 g-pos-rel g-z-index-2 g-cursor-pointer g-transition-0_3">
              <!-- Article Header -->
              <header class="g-bg-primary g-pos-rel g-px-20 g-py-70">
                <svg class="g-pos-abs g-bottom-0 g-left-0 g-right-0" version="1.1" preserveAspectRatio="none" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="100%" height="70px" viewBox="0 0 300 70">
                  <path d="M30.913,43.944c0,0,42.911-34.464,87.51-14.191c77.31,35.14,113.304-1.952,146.638-4.729
                c48.654-4.056,69.94,16.218,69.94,16.218v54.396H30.913V43.944z" opacity="0.6" fill="#ffffff" />
                  <path d="M-35.667,44.628c0,0,42.91-34.463,87.51-14.191c77.31,35.141,113.304-1.952,146.639-4.729
                c48.653-4.055,69.939,16.218,69.939,16.218v54.396H-35.667V44.628z" opacity="0.6" fill="#ffffff" />
                  <path d="M43.415,98.342c0,0,48.283-68.927,109.133-68.927c65.886,0,97.983,67.914,97.983,67.914v3.716
                H42.401L43.415,98.342z" opacity="0.7" fill="#ffffff" />
                  <path d="M-34.667,62.998c0,0,56-45.667,120.316-27.839C167.484,57.842,197,41.332,232.286,30.428
                c53.07-16.399,104.047,36.903,104.047,36.903l1.333,36.667l-372-2.954L-34.667,62.998z" fill="#ffffff" />
                </svg>
                  <div class="circle circle-4" style="color:#366f9a">1</div>
               <%-- <strong class="d-block g-color-white g-font-size-50 g-line-height-0_7 g-mb-20">
                    
                    <span class="g-valign-top g-font-size-default">$</span>19<span class="g-font-size-default">/ month</span>
                  </strong>--%>
                <h3 class="h6 text-uppercase g-color-white-opacity-0_7 g-letter-spacing-3 g-mb-20">KEENCareer Finder Report</h3>
              </header>
              <!-- End Article Header -->

              <!-- Article Content -->
              <div class="g-px-20 g-py-40">
                  <h2> KEENCareer Finder Report</h2>
                  <p>รายงานแสดงผลอัจฉริยภาพและบุคลิกภาพการทำงานของคุณ คุณจะทราบวิธีการพัฒนาศักยภาพการทำงานที่เหมาะสมกับตัวคุณ </p>

                <a class="btn text-uppercase u-btn-primary g-rounded-50 g-font-size-12 g-font-weight-700 g-pa-15-30 g-mb-10" href="#!">Order Now</a>
              </div>
              <!-- End Article Content -->
            </article>
            <!-- End Article -->
          </div>

          <div class="col-md-3 g-mb-30">
            <!-- Article -->
            <article class="u-shadow-v21 u-shadow-v21--hover g-bg-white text-center g-overflow-hidden g-rounded-4 g-pos-rel g-z-index-2 g-cursor-pointer g-transition-0_3">
              <!-- Article Header -->
              <header class="g-bg-primary g-pos-rel g-px-20 g-py-70">
                <svg class="g-pos-abs g-bottom-0 g-left-0 g-right-0" version="1.1" preserveAspectRatio="none" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="100%" height="70px" viewBox="0 0 300 70">
                  <path d="M30.913,43.944c0,0,42.911-34.464,87.51-14.191c77.31,35.14,113.304-1.952,146.638-4.729
                c48.654-4.056,69.94,16.218,69.94,16.218v54.396H30.913V43.944z" opacity="0.6" fill="#ffffff" />
                  <path d="M-35.667,44.628c0,0,42.91-34.463,87.51-14.191c77.31,35.141,113.304-1.952,146.639-4.729
                c48.653-4.055,69.939,16.218,69.939,16.218v54.396H-35.667V44.628z" opacity="0.6" fill="#ffffff" />
                  <path d="M43.415,98.342c0,0,48.283-68.927,109.133-68.927c65.886,0,97.983,67.914,97.983,67.914v3.716
                H42.401L43.415,98.342z" opacity="0.7" fill="#ffffff" />
                  <path d="M-34.667,62.998c0,0,56-45.667,120.316-27.839C167.484,57.842,197,41.332,232.286,30.428
                c53.07-16.399,104.047,36.903,104.047,36.903l1.333,36.667l-372-2.954L-34.667,62.998z" fill="#ffffff" />
                </svg>
                  <div class="circle circle-4" style="color:#366f9a">2</div>
                <%--<strong class="d-block g-color-white g-font-size-50 g-line-height-0_7 g-mb-20">
                    <span class="g-valign-top g-font-size-default">$</span>49<span class="g-font-size-default">/ month</span>
                  </strong>--%>
                <h3 class="h6 text-uppercase g-color-white-opacity-0_7 g-letter-spacing-3 g-mb-20">Your Current Job & Company Fit Report</h3>
              </header>
              <!-- End Article Header -->

              <!-- Article Content -->
              <div class="g-px-20 g-py-40">
                <h2>Your Current Job & Company Fit Report</h2>
                  <p>รายงานแสดงผลความเหมาะสมระหว่างตัวคุณกับงานปัจจุบันและวัฒนธรรมของบริษัทปัจจุบัน คุณควรทำงานนี้ต่อไปหรือไม่?</p>
                <a class="btn text-uppercase u-btn-primary g-rounded-50 g-font-size-12 g-font-weight-700 g-pa-15-30 g-mb-10" href="#!">Order Now</a>
              </div>
              <!-- End Article Content -->
            </article>
            <!-- End Article -->
          </div>

          <div class="col-md-3 g-mb-30">
            <!-- Article -->
            <article class="u-shadow-v21 u-shadow-v21--hover g-bg-white text-center g-overflow-hidden g-rounded-4 g-pos-rel g-z-index-2 g-cursor-pointer g-transition-0_3">
              <!-- Article Header -->
              <header class="g-bg-primary g-pos-rel g-px-20 g-py-70">
                <svg class="g-pos-abs g-bottom-0 g-left-0 g-right-0" version="1.1" preserveAspectRatio="none" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="100%" height="70px" viewBox="0 0 300 70">
                  <path d="M30.913,43.944c0,0,42.911-34.464,87.51-14.191c77.31,35.14,113.304-1.952,146.638-4.729
                c48.654-4.056,69.94,16.218,69.94,16.218v54.396H30.913V43.944z" opacity="0.6" fill="#ffffff" />
                  <path d="M-35.667,44.628c0,0,42.91-34.463,87.51-14.191c77.31,35.141,113.304-1.952,146.639-4.729
                c48.653-4.055,69.939,16.218,69.939,16.218v54.396H-35.667V44.628z" opacity="0.6" fill="#ffffff" />
                  <path d="M43.415,98.342c0,0,48.283-68.927,109.133-68.927c65.886,0,97.983,67.914,97.983,67.914v3.716
                H42.401L43.415,98.342z" opacity="0.7" fill="#ffffff" />
                  <path d="M-34.667,62.998c0,0,56-45.667,120.316-27.839C167.484,57.842,197,41.332,232.286,30.428
                c53.07-16.399,104.047,36.903,104.047,36.903l1.333,36.667l-372-2.954L-34.667,62.998z" fill="#ffffff" />
                </svg>
                  <div class="circle circle-4" style="color:#366f9a">3</div>
               <%-- <strong class="d-block g-color-white g-font-size-50 g-line-height-0_7 g-mb-20">
                    <span class="g-valign-top g-font-size-default">$</span>99<span class="g-font-size-default">/ month</span>
                  </strong>--%>
                <h3 class="h6 text-uppercase g-color-white-opacity-0_7 g-letter-spacing-3 g-mb-20">The Right Job Functions Report</h3>
              </header>
              <!-- End Article Header -->

              <!-- Article Content -->
              <div class="g-px-20 g-py-40">
                 <h2>The Right Job Functions Report</h2>
                  <p>รายงานแสดงผลสายงานทั้งหมดที่เหมาะสมกับอัจฉริยภาพและบุคลิกภาพการทำงานของคุณคุณจะไม่หลงทางกับเส้นทางอาชีพอีกต่อไป </p>
                <a class="btn text-uppercase u-btn-primary g-rounded-50 g-font-size-12 g-font-weight-700 g-pa-15-30 g-mb-10" href="#!">Order Now</a>
              </div>
              <!-- End Article Content -->
            </article>
            <!-- End Article -->
          </div>

            <div class="col-md-3 g-mb-30">
            <!-- Article -->
            <article class="u-shadow-v21 u-shadow-v21--hover g-bg-white text-center g-overflow-hidden g-rounded-4 g-pos-rel g-z-index-2 g-cursor-pointer g-transition-0_3">
              <!-- Article Header -->
              <header class="g-bg-primary g-pos-rel g-px-20 g-py-70">
                <svg class="g-pos-abs g-bottom-0 g-left-0 g-right-0" version="1.1" preserveAspectRatio="none" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="100%" height="70px" viewBox="0 0 300 70">
                  <path d="M30.913,43.944c0,0,42.911-34.464,87.51-14.191c77.31,35.14,113.304-1.952,146.638-4.729
                c48.654-4.056,69.94,16.218,69.94,16.218v54.396H30.913V43.944z" opacity="0.6" fill="#ffffff" />
                  <path d="M-35.667,44.628c0,0,42.91-34.463,87.51-14.191c77.31,35.141,113.304-1.952,146.639-4.729
                c48.653-4.055,69.939,16.218,69.939,16.218v54.396H-35.667V44.628z" opacity="0.6" fill="#ffffff" />
                  <path d="M43.415,98.342c0,0,48.283-68.927,109.133-68.927c65.886,0,97.983,67.914,97.983,67.914v3.716
                H42.401L43.415,98.342z" opacity="0.7" fill="#ffffff" />
                  <path d="M-34.667,62.998c0,0,56-45.667,120.316-27.839C167.484,57.842,197,41.332,232.286,30.428
                c53.07-16.399,104.047,36.903,104.047,36.903l1.333,36.667l-372-2.954L-34.667,62.998z" fill="#ffffff" />
                </svg>
                  <div class="circle circle-4" style="color:#366f9a">4</div>
             <%--   <strong class="d-block g-color-white g-font-size-50 g-line-height-0_7 g-mb-20">
                    <span class="g-valign-top g-font-size-default">$</span>99<span class="g-font-size-default">/ month</span>
                  </strong>--%>
                <h3 class="h6 text-uppercase g-color-white-opacity-0_7 g-letter-spacing-3 g-mb-20">KEENCareer Coaching</h3>
              </header>
              <!-- End Article Header -->

              <!-- Article Content -->
              <div class="g-px-20 g-py-40">
                <h2>KEENCareer Coaching</h2>
                  <p>โค้ชตัวต่อตัวกับผู้เชี่ยวชาญของทางทีมงาน KEEN PROFILE เพื่อทำความเข้าใจเชิงลึกเกี่ยวกับเส้นทางอาชีพที่เหมาะกับอัจฉริยภาพและบุคลิกภาพการทำงานของคุณ</p>
                <a class="btn text-uppercase u-btn-primary g-rounded-50 g-font-size-12 g-font-weight-700 g-pa-15-30 g-mb-10" href="#!">Order Now</a>
              </div>
              <!-- End Article Content -->
            </article>
            <!-- End Article -->
          </div>
        </div>
        <!-- End Pricing Plans -->

        <h2 class="h5 g-font-weight-700 text-center text-uppercase mb-5">Why Unify?</h2>

        <!-- Icons Block -->
        <div class="row no-gutters justify-content-center">
          <div class="col-md-5 col-lg-4">
            <!-- Icon Blocks -->
            <div class="u-shadow-v20 g-brd-right--md g-brd-gray-light-v5 g-bg-white text-center g-rounded-left-5 g-px-20 g-py-40">
              <span class="u-icon-v1 u-icon-size--lg g-color-black g-mb-10">
                  <i class="icon-education-087 u-line-icon-pro"></i>
                </span>
              <h3 class="h5 mb-2">Creative ideas</h3>
              <p class="g-color-gray-dark-v5">This is where we sit down, grab a cup of coffee and dial in the details.</p>
            </div>
            <!-- End Icon Blocks -->
          </div>

          <div class="col-md-5 col-lg-4">
            <!-- Icon Blocks -->
            <div class="u-shadow-v20 g-bg-white text-center g-rounded-right-5 g-px-20 g-py-40">
              <span class="u-icon-v1 u-icon-size--lg g-color-black g-mb-10">
                  <i class="icon-education-035 u-line-icon-pro"></i>
                </span>
              <h3 class="h5 mb-2">Excellent features</h3>
              <p class="g-color-gray-dark-v5">This is where we sit down, grab a cup of coffee and dial in the details.</p>
            </div>
            <!-- End Icon Blocks -->
          </div>
        </div>
        <!-- End Icons Block -->
      </div>
    </section>
    <!-- End Pricing Plans -->
  
   <section id="about" class="section section-about">
					<div class="animate-up animated">
						<div class="section-box">
							<div class="profile">
								<div class="row">
									<div class="col-xs-5">
										<div class="profile-photo">
                                            <h1>KEENCareer Finder</h1>
                                            <p>

                                                 แบบประเมินแรกของโลกที่สามารถระบุอัจฉริยภาพและบุคลิกภาพการทำงานของคุณ เพื่อบ่งบอกว่าประเภทสายงานและวัฒนธรรมบริษัทที่เหมาะกับตัวคุณ
                                                งานที่คุณทำอยู่ปัจจุบันเหมาะกับคุณจริงๆ หรือไม่
                                                สายงานอะไรและบริษัทแบบไหนที่คุณสามารถเติบโตได้อย่างมีประสิทธิภาพ
                                                หาคำตอบได้เลย
                                                 
                                            </p>
<%--                                            <img src="http://rscard.px-lab.com/img/uploads/rs-photo-v1.jpg" alt="Robert Smith">--%>

                                              <a runat="server" id="Do_assessment" class="btn btn-lg btn-border ripple" style="background-color:#3f51b5;margin:0 auto;color:#fff !important;margin-top: 10px;"   target="_blank" href="Assessmentstep.aspx"> เริ่มทำแบบประเมิน</a>
										</div>
									</div>
									<div class="col-xs-7">
										<div class="profile-info">
											<div class="profile-preword"><span>Hello</span></div>
											<h1 class="profile-title"><%--<span>I'm </span>--%> <asp:Literal ID="name" runat="server"></asp:Literal> </h1>
                                              <a class="btn btn-lg btn-border ripple" style="float:right;top:-20px;font-size:11px;    background-color: #fff;
    padding: 5px;"  href="ProfileUpdate">Update Profile </a>
											<%--<h2 class="profile-position"><asp:Literal ID="cjf" runat="server"></asp:Literal></h2></div>--%>
                                      
                                            <ul class="profile-list">
                                                <li class="clearfix">
                                                    <strong class="title">Date of Birth</strong>
                                                    <span class="cont"><asp:Literal ID="dob" runat="server"></asp:Literal></span>
                                                </li>
                                                <li class="clearfix">
                                                    <strong class="title">Gender</strong>
                                                    <span class="cont"> <asp:Literal ID="gender" runat="server"></asp:Literal> </span>
                                                </li>
                                                <li class="clearfix">
                                                    <strong class="title">Nationality</strong>
                                                    <span class="cont"><% Response.Write(UserActive.NationalityTitle); %></span>
                                                </li>
                                                <li class="clearfix">
                                                    <strong class="title">E-mail</strong>
                                                    <span class="cont"><a href="<% Response.Write(UserActive.Email); %>"><% Response.Write(UserActive.Email); %></a></span>
                                                </li>
                                                <li class="clearfix">
                                                    <strong class="title">Phone</strong>
                                                    <span class="cont"><a href="tel:<% Response.Write(UserActive.MobileNumber); %>"><% Response.Write(UserActive.MobileNumber); %></a></span>
                                                </li>
                                                <%--<li class="clearfix">
                                                    <strong class="title" >Functional Competencies</strong>
                                                    <span class="cont"><asp:Literal ID="fc" runat="server"></asp:Literal></span>
                                                </li>--%>
                                            <%--     <li class="clearfix">
                                                    <strong class="title">Current Job Function</strong>
                                                    <span class="cont">till April 15, 2016</span>
                                                </li>--%>
                                                
                                                <%--<li class="clearfix">
                                                    <strong class="title"><span class="button">On Vacation</span></strong>
                                                    <span class="cont"><i class="rsicon rsicon-calendar"></i>till March 25, 2016</span>
                                                </li>--%>
                                            </ul>
									</div>
								</div>
							</div>
							<div class="profile-social" style="height:40px;" >


<%--                                 <a href="Logout.aspx">logout</a>--%>
								<%--<ul class="social">
									<li><a class="ripple-centered" href="https://www.facebook.com" target="_blank"><i class="rsicon rsicon-facebook"></i></a></li>
									<li><a class="ripple-centered" href="https://twitter.com" target="_blank"><i class="rsicon rsicon-twitter"></i></a></li>
									<li><a class="ripple-centered" href="https://www.linkedin.com" target="_blank"><i class="rsicon rsicon-linkedin"></i></a></li>
									<li><a class="ripple-centered" href="https://plus.google.com" target="_blank"><i class="rsicon rsicon-google-plus"></i></a></li>
									<li><a class="ripple-centered" href="https://dribbble.com" target="_blank"><i class="rsicon rsicon-dribbble"></i></a></li>
									<li><a class="ripple-centered" href="https://www.instagram.com" target="_blank"><i class="rsicon rsicon-instagram"></i></a></li>
								</ul>--%>
							</div>
						</div>

                        <%--<div class="section-txt-btn">
                            <p><a class="btn btn-lg btn-border ripple" target="_blank" href="http://dev.novembit.com/rs_card/wp-content/uploads/2015/11/test-1.pdf">Download Resume</a></p>
                            <p>Hello! I’m Robert Smith. Senior Web Developer specializing in front end development. Experienced with all stages of the development cycle for dynamic web projects. Well-versed in numerous programming languages including JavaScript, SQL, and C. Stng background in project management and customer relations.</p>
                        </div>--%>
					</div>	
                        </div>
				</section>

    <div class="divider">
	<div class="container">
		<div class="row">
			<div class="col-md-4 col-sm-6">
				<div class="divider-wrapper divider-one">
					<div class="circle circle-1" style="color:#a84209">1</div>
					<h2>KEENCareer Finder Report</h2>
					<p>รายงานแสดงผลอัจฉริยภาพและบุคลิกภาพการทำงานของคุณ คุณจะทราบวิธีการพัฒนาศักยภาพการทำงานที่เหมาะสมกับตัวคุณ <br /><%--<a  class="read-more-btn" href="#">อ่านต่อ >></a>--%></p>
                    <i class="fa fa-download fa-btn-3" runat="server" id="fa_r1" aria-hidden="true"></i>
                    <asp:Button ID="btnReport1" runat="server" Text="Dowload Now" CssClass="btn_button" OnClick="btnReport1_Click"  CommandArgument="1"/>
                    <asp:HyperLink ID="sample_r1" runat="server" Target="_blank" >ตัวอย่าง Report</asp:HyperLink>
				</div>
			</div>
			<div class="col-md-4 col-sm-6">
				<div class="divider-wrapper divider-two">
					<div class="circle circle-2" style="color:#569888">2</div>
					<h2>Your Current Job & Company Fit Report</h2>
					<p>รายงานแสดงผลความเหมาะสมระหว่างตัวคุณกับงานปัจจุบันและวัฒนธรรมของบริษัทปัจจุบัน คุณควรทำงานนี้ต่อไปหรือไม่?</p>
                    <i class="fa fa-download fa-btn-3" runat="server" id="fa_r2" aria-hidden="true"></i>
                     <asp:Button ID="btnReport2" runat="server" Text="Dowload Now" CssClass="btn_button"  OnClick="btnReport1_Click" CommandArgument="2" />
                     <asp:HyperLink ID="sample_r2" runat="server" Target="_blank">ตัวอย่าง Report</asp:HyperLink>
				</div>
			</div>
			<div class="col-md-4 col-sm-12">
				<div class="divider-wrapper divider-three">
					<div class="circle circle-3" style="color:#e9a427">3</div>
					<h2>The Right Job Functions Report</h2>
					<p>รายงานแสดงผลสายงานทั้งหมดที่เหมาะสมกับอัจฉริยภาพและบุคลิกภาพการทำงานของคุณคุณจะไม่หลงทางกับเส้นทางอาชีพอีกต่อไป  <br /><%--<a class="read-more-btn" href="#">อ่านต่อ >></a>--%>  </p>
                    <i class="fa fa-cog fa-spin fa-3x fa-fw fa-btn-3"  runat="server" id="fa_r3_2"></i>
                   <%-- <i class="fa fa-shopping-cart fa-btn-3" runat="server" id="fa_r3_2" aria-hidden="true"></i>--%>
                     <i class="fa fa-download fa-btn-3" runat="server" id="fa_r3_1"  visible="false" aria-hidden="true"></i>
                     <asp:Button ID="btnReport3" runat="server" Text="Dowload Now" CssClass="btn_button"  OnClick="btnReport1_Click" CommandArgument="3" />

                    <asp:HyperLink ID="sample_r3" runat="server" Target="_blank" >ตัวอย่าง Report</asp:HyperLink>
				</div>
			</div>
            
		</div>
        <div class="row" style="margin-top:30px;">
            <div class="col-md-offset-4 col-md-4 col-sm-12">
				<div class="divider-wrapper divider-four">
					<div class="circle circle-4" style="color:#366f9a">4</div>
					<h2>KEENCareer Coaching</h2>
					<p>โค้ชตัวต่อตัวกับผู้เชี่ยวชาญของทางทีมงาน KEEN PROFILE เพื่อทำความเข้าใจเชิงลึกเกี่ยวกับเส้นทางอาชีพที่เหมาะกับอัจฉริยภาพและบุคลิกภาพการทำงานของคุณ <%--<a  class="read-more-btn" href="#">อ่านต่อ >></a> --%> </p>
                    <i class="fa fa-users fa-btn-3" runat="server" id="fa_r4_1" style="top:300px !important;" aria-hidden="true"></i>
              

                    <i class="fa fa-clock-o fa-btn-3" runat="server" id="fa_r4_2" style="top:300px !important;left:31px !important;" visible="false"  aria-hidden="true"></i>
                     <asp:Button ID="btnReport4" runat="server" Text="Dowload Now"  CssClass="btn_button"  OnClick="btnReport1_Click" CommandArgument="4" />
				</div>
			</div>
       </div>
	</div>
</div>
</asp:Content>
<asp:Content ID="FooterScript" ContentPlaceHolderID="ContentFooter" runat="server">
      <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script>
        $(document).ready(function(){
            if (window.location.hash) {
                $('html, body').animate({ scrollTop: $(".divider").offset().top}, 500);
            } else {
                // Fragment doesn't exist
            }

        });


        function ShowAlert(e) {

            e.preventDefault();
            swal({
                icon: "warning",
                title: "Warning",
                text: "Your account is not verify please check your email which you registerd"
            });
            return false;
        }
    </script>
    </asp:Content>
