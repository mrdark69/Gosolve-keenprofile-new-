<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.User.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderScript" ContentPlaceHolderID="HeaderScript" runat="server">
    <style type="text/css">
       
        .circle{width:80px;height:80px;border-radius:50px;font-size:30px;line-height:80px;text-align:center;background:#fff;
                margin:0 auto;
                color:#000;
                font-weight:bold;
        }
        .divider-wrapper{
            min-height:434px;
        }
        .divider-wrapper p{
            font-size:14px;
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
        
    </style>
 </asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  
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

                                              <a class="btn btn-lg btn-border ripple" style="background-color:#3f51b5;margin:0 auto;color:#fff !important;margin-top: 10px;"   target="_blank" href="Assessmentstep.aspx"> เริ่มทำแบบประเมิน</a>
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
                    <asp:Button ID="btnReport1" runat="server" Text="Dowload Now" CssClass="btn_button" OnClick="btnReport1_Click"  CommandArgument="1"/>
				</div>
			</div>
			<div class="col-md-4 col-sm-6">
				<div class="divider-wrapper divider-two">
					<div class="circle circle-2" style="color:#569888">2</div>
					<h2>Your Current Job & Company Fit Report</h2>
					<p>รายงานแสดงผลความเหมาะสมระหว่างตัวคุณกับงานปัจจุบันและวัฒนธรรมของบริษัทปัจจุบัน คุณควรทำงานนี้ต่อไปหรือไม่?</p>
                     <asp:Button ID="btnReport2" runat="server" Text="Dowload Now" CssClass="btn_button"  OnClick="btnReport1_Click" CommandArgument="2" />
				</div>
			</div>
			<div class="col-md-4 col-sm-12">
				<div class="divider-wrapper divider-three">
					<div class="circle circle-3" style="color:#e9a427">3</div>
					<h2>The Right Job Functions Report</h2>
					<p>รายงานแสดงผลสายงานทั้งหมดที่เหมาะสมกับอัจฉริยภาพและบุคลิกภาพการทำงานของคุณคุณจะไม่หลงทางกับเส้นทางอาชีพอีกต่อไป  <br /><%--<a class="read-more-btn" href="#">อ่านต่อ >></a>--%>  </p>
                     <asp:Button ID="btnReport3" runat="server" Text="Dowload Now" CssClass="btn_button"  OnClick="btnReport1_Click" CommandArgument="3" />
				</div>
			</div>
            
		</div>
        <div class="row" style="margin-top:30px;">
            <div class="col-md-offset-4 col-md-4 col-sm-12">
				<div class="divider-wrapper divider-four">
					<div class="circle circle-4" style="color:#366f9a">4</div>
					<h2>KEENCareer Coaching</h2>
					<p>โค้ชตัวต่อตัวกับผู้เชี่ยวชาญของทางทีมงาน KEEN PROFILE เพื่อทำความเข้าใจเชิงลึกเกี่ยวกับเส้นทางอาชีพที่เหมาะกับอัจฉริยภาพและบุคลิกภาพการทำงานของคุณ <%--<a  class="read-more-btn" href="#">อ่านต่อ >></a> --%> </p>
                     <asp:Button ID="btnReport4" runat="server" Text="Dowload Now" CssClass="btn_button"  OnClick="btnReport1_Click" CommandArgument="4" />
				</div>
			</div>
       </div>
	</div>
</div>
</asp:Content>
<asp:Content ID="FooterScript" ContentPlaceHolderID="ContentFooter" runat="server">
    <script>
        $(document).ready(function(){
            if (window.location.hash) {
                $('html, body').animate({ scrollTop: $(".divider").offset().top}, 500);
            } else {
                // Fragment doesn't exist
            }

        });
    </script>
    </asp:Content>
