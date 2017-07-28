<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.User.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderScript" ContentPlaceHolderID="HeaderScript" runat="server">
    <style type="text/css">
       

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
                                            <h1>Lorem Ipsum is simply dummy text of the printing and</h1>
                                            <p>

                                                 typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.
                                            </p>
<%--                                            <img src="http://rscard.px-lab.com/img/uploads/rs-photo-v1.jpg" alt="Robert Smith">--%>

                                              <a class="btn btn-lg btn-border ripple" style="background-color:#3f51b5;margin:0 auto;color:#fff !important;margin-top: 10px;"   target="_blank" href="Assessmentstep.aspx"> Download Now</a>
										</div>
									</div>
									<div class="col-xs-7">
										<div class="profile-info">
											<div class="profile-preword"><span>Hello</span></div>
											<h1 class="profile-title"><span>I'm</span> Robert Smith</h1>
                                              <a class="btn btn-lg btn-border ripple" style="float:right;top:-20px;font-size:11px;    background-color: #fff;
    padding: 5px;" target="_blank" href="#">Update Profile </a>
											<h2 class="profile-position">Developer and businessman</h2></div>
                                      
                                            <ul class="profile-list">
                                                <li class="clearfix">
                                                    <strong class="title">Date of Birth</strong>
                                                    <span class="cont">29</span>
                                                </li>
                                                <li class="clearfix">
                                                    <strong class="title">Gender</strong>
                                                    <span class="cont">29</span>
                                                </li>
                                                <li class="clearfix">
                                                    <strong class="title">Nationality</strong>
                                                    <span class="cont">24058, Belgium, Brussels, Liutte 27, BE</span>
                                                </li>
                                                <li class="clearfix">
                                                    <strong class="title">E-mail</strong>
                                                    <span class="cont"><a href="mailto:robertsmith@company.com">robertsmith@company.com</a></span>
                                                </li>
                                                <li class="clearfix">
                                                    <strong class="title">Phone</strong>
                                                    <span class="cont"><a href="tel:+12562548456">+1 256 254 84 56</a></span>
                                                </li>
                                                <li class="clearfix">
                                                    <strong class="title" >Functional Competencies</strong>
                                                    <span class="cont">till April 15, 2016</span>
                                                </li>
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
				</section>

    <div class="divider">
	<div class="container">
		<div class="row">
			<div class="col-md-4 col-sm-6">
				<div class="divider-wrapper divider-one">
					<i class="fa fa-star-o"></i>
					<h2>The Career Pillar Calculation</h2>
					<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet.</p>
                    <asp:Button ID="btnReport1" runat="server" Text="Dowload Now" CssClass="btn_button" />
				</div>
			</div>
			<div class="col-md-4 col-sm-6">
				<div class="divider-wrapper divider-two">
					<i class="fa fa-star-half-o"></i>
					<h2>The Career Pillar Calculation</h2>
					<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet.</p>
                     <asp:Button ID="btnReport2" runat="server" Text="Dowload Now" CssClass="btn_button" />
				</div>
			</div>
			<div class="col-md-4 col-sm-12">
				<div class="divider-wrapper divider-three">
					<i class="fa fa-star"></i>
					<h2>The Career Pillar Calculation</h2>
					<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet.</p>
                     <asp:Button ID="btnReport3" runat="server" Text="Dowload Now" CssClass="btn_button" />
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
