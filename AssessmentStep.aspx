<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.User.Master" AutoEventWireup="true" CodeFile="AssessmentStep.aspx.cs" Inherits="_AssessmentStep" %>

<asp:Content ID="HeaderScript" ContentPlaceHolderID="HeaderScript" runat="server">
    <style type="text/css">
        /* Tooltip container */


/* Tooltip text */
.progress-bar{
    transition:none !important;
}
.progress-bar .tooltiptext {
    /*visibility: hidden;*/
    width: 120px;
    background-color: rgb(17, 97, 238);
    color: #fff;
    text-align: center;
    padding: 5px 0;
    border-radius: 6px;
 
    /* Position the tooltip text - see examples below! */
    position: absolute;
    z-index: 1;
    top:-39px;
        margin-left: -21px;
}
.progress-bar .tooltip-top::after {
    content: "";
    position: absolute;
    top: 100%;
    left: 50%;
    margin-left: -5px;
    border-width: 5px;
    border-style: solid;
    border-color: rgb(17, 97, 238) transparent transparent transparent;
}

/* Show the tooltip text when you mouse over the tooltip container */
/*.tooltip:hover .tooltiptext {
    visibility: visible;
}*/
    </style>
    <link href="Content/animate.css" rel="stylesheet" />
    <link href="Content/plugins/iCheck/custom.css" rel="stylesheet" />
    <link href="Content/plugins/steps/jquery.steps.css" rel="stylesheet" />
    
    <link href="Content/plugins/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css" rel="stylesheet">
   <%--     <link href="css/plugins/iCheck/custom.css" rel="stylesheet">
    <link href="css/plugins/steps/jquery.steps.css" rel="stylesheet">
    <link href="css/animate.css" rel="stylesheet">--%>
 </asp:Content>
  
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  
   <section id="about" class="section section-about">
       <div class="banner">
				<div class="wsite-section-elements">
					<h2 class="wsite-content-title" style="text-align:center;color:#fff;text-transform: uppercase;font-family: 'Lato', sans-serif;margin-bottom:20px;"><asp:Literal ID="Maintitle" runat="server"></asp:Literal></h2>

<div class="paragraph" style="text-align:center;"></div>
				</div>
		
					<div class="animate-up animated">
						<div class="section-box">
							<div class="profile">
								<div class="row">
									<div class="col-xs-12">
									 <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <%--<h5>Basic Wizzard</h5>--%>
                        
                    </div>
                    <div class="ibox-content">
                        <%--<p>
                            This is basic example of Step
                        </p>--%>
                        <div class="p_percent">
                            <div style="float:left"> <span></span>
                            <p>0%</p></div>
                            <div style="float:right"> <span></span>
                            <p>100%</p></div>
                        </div>
                        <div class="progress">
                                <div id="progress_bar_per" style="width: 0%;background-color:#1161ee" aria-valuemax="100" aria-valuemin="0" aria-valuenow="35" role="progressbar" class="progress-bar" >
                                    <span class="tooltiptext tooltip-top">Tooltip text</span>
                                   <%-- <span class="sr-only">35% Complete (success)</span>--%>
                                </div>
                            </div>
                        <div id="wizard">

                           
                            <h1  class="step_count"></h1>
                            <div class="step-content">
                                <div class="text-center m-t-md">
                                <h2><asp:Literal ID="IntroTitle" runat="server"></asp:Literal></h2>
                                <p>
                                    <asp:Literal ID="IntroDetail" runat="server"></asp:Literal>
                                </p>
                                    
                                </div>
                            </div>


                       
                            <h1 id="stepprofile_head" runat="server" class="step_count"></h1>
                            <div class="step-content" id="stepprofile" runat="server">
                                <div class="text-center m-t-md">
                                <h2>ขอต้อนรับสู่ Assessment ของทาง Keen Profile</h2>
                               
                                    <div class="q-form-bio form-horizontal">
                                        <div class="form-group"><label class="col-sm-2 control-label">First name:</label>

                                            <div class="col-sm-10">
                                                <asp:TextBox ID="firstName" runat="server" CssClass="form-control required"></asp:TextBox>
                                          

                                            </div>
                                        </div>
                                        <div class="form-group"><label class="col-sm-2 control-label">Last name:</label>

                                            <div class="col-sm-10">
                                                    <asp:TextBox ID="LastName" runat="server" CssClass="form-control required"></asp:TextBox>
                                               

                                            </div>
                                        </div>
                                        <div class="form-group"><label class="col-sm-2 control-label">Gender:</label>

                                            <div class="col-sm-10">
                                                <asp:DropDownList ID="dropGender" CssClass="form-control" runat="server">
                                                    <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                                                </asp:DropDownList>
                                                
                                            </div>
                                        </div>
                                        <div class="form-group"><label class="col-sm-2 control-label">Nationality:</label>

                                            <div class="col-sm-10">
                                                <asp:DropDownList ID="dropNation" CssClass="form-control" runat="server"></asp:DropDownList>
                                             
                                            </div>
                                        </div>
                                        <div class="form-group"><label class="col-sm-2 control-label">Date of birth:</label>

                                            <div class="col-sm-10" style="text-align:left">
                                                <asp:TextBox ID="day" runat="server" MaxLengt="2" TextMode="Date" placeholder="Day" CssClass="form-control dob required"></asp:TextBox>
                                                 

                                            </div>
                                        </div>
                                    </div>
                                    
                                </div>
                            </div>

                          
                         <asp:Literal ID="Stepcontent" runat="server"></asp:Literal>


                            <h1  class="step_count"></h1>
                            <div class="step-content">
                                <div class="text-center m-t-md">
                                <h2><asp:Literal ID="LastTitle" runat="server">Congratuation</asp:Literal></h2>
                                <p>
                                    <asp:Literal ID="LastDes" runat="server">คุณได้ทํา The Career Pillar Assessment ของทาง Keen Profile ครบทุกข้อแล้ว โปรดคลิก “ส่ง” เพื่อส่งแบบสอบถาม </asp:Literal>
                                </p>
                                    
                                </div>
                            </div>

                           <%-- <h1></h1>
                            <div class="step-content">
                                <div class="text-center m-t-md">
                                    <h2>Working Geniuses Assessment</h2>
                                    <p>
                                        ขอให้คุณอ่านข้อคำถามแต่ละข้อต่อไปนี้ <br />
                                        แล้วตอบโดยใช้คะแนนตั้งแต่ 0 - 10 <br />
                                        เมื่อ 0 หมายถึง <strong>"ไม่ใช่ตัวตนของฉันเลย"</strong> และ 10 หมายถึง <strong>"เป็นตัวตนของฉันมากที่สุด"</strong> <br />
                                    </p>
                                </div>
                            </div>

                            <h1></h1>
                            <div class="step-content">
                                <div class="text-center m-t-md">
                                    <h2>ไอเดียมากมายพรั่งพรูเข้ามาในหัวของฉันโดยที่ฉันไม่ได้ตั้งใจ </h2>
                                    <div class="question-type q-type-scale">
                                        <div class="col-md-3 left-ele" >ไม่ใช่ตัวตน ของฉันเลย </div>
                                          <div class="col-md-6 choice-ele">
                                              <table>
                                                  <tr>
                                                      <td>0</td> <td>1</td> <td>2</td> <td>3</td> <td>4</td> <td>5</td><td>6</td><td>7</td><td>8</td><td>9</td><td>10</td>
                                                  </tr>
                                                  <tr>
                                                      <td><input type="radio"  name="1ss" /></td>
                                                      <td><input type="radio"  name="1ss" /></td>
                                                      <td><input type="radio"  name="1ss" /></td>
                                                      <td><input type="radio"  name="1ss" /></td>
                                                      <td><input type="radio"  name="1ss" /></td>
                                                      <td><input type="radio"  name="1ss" /></td>
                                                      <td><input type="radio"  name="1ss" /></td>
                                                      <td><input type="radio"  name="1ss" /></td>
                                                      <td><input type="radio"  name="1ss" /></td>
                                                      <td><input type="radio"  name="1ss" /></td>
                                                      <td><input type="radio"  name="1ss" /></td>
                                                     
                                                  </tr>
                                              </table>
                                          </div>
                                          <div class="col-md-3 right-ele"> เป็นตัวตนของ ฉันมากที่สุด </div>

                                    </div>
                                        
                                   
                                </div>
                            </div>
                           
                            <h1></h1>
                            <div class="step-content">
                                <div class="text-center m-t-md">
                                    <h2>ระดมสมองกับคนอื่นอยู่บ่อยๆ เพื่อคิดค้นไอเดียใหม่ๆ ให้กับงาน</h2>
                                   <div class="question-type q-type-scale">
                                        <div class="col-md-3 left-ele" >ไม่ได้ทํางานแบบนี้เลย  0% </div>
                                          <div class="col-md-6 choice-ele">
                                              <table>
                                                  <tr>
                                                    <td>1</td> <td>2</td> <td>3</td> <td>4</td> <td>5</td>
                                                  </tr>
                                                  <tr>
                                                      <td><input type="radio"  name="1ss" /></td>
                                                      <td><input type="radio"  name="1ss" /></td>
                                                      <td><input type="radio"  name="1ss" /></td>
                                                      <td><input type="radio"  name="1ss" /></td>
                                                     <td><input type="radio"  name="1ss" /></td>
                                                     
                                                  </tr>
                                              </table>
                                          </div>
                                          <div class="col-md-3 right-ele"> ทํางานแบบนี้ ทุกวัน  100%</div>

                                    </div>
                                </div>
                            </div>



                            <h1></h1>
                            <div class="step-content">
                                <div class="text-center m-t-md">
                                    <h2>ความสามารถแบบใดที่อธิบายตัวคุณได้ดีที่สุด </h2>
                                   <div class="question-type q-type-rank-scale-choice">
                                        <div class="col-md-12 tbl-rank-scale"   >

                                            <table>
                                                  <tr>
                                                      <td class="question"></td>
                                                    <td class="choice">1<br /><span>เห็นด้วยน้อยที่สุด</span></td>
                                                      <td class="choice">2</td>
                                                      <td class="choice">3</td> 
                                                      <td class="choice"> 4 <br /> <span>เห็นด้วยมากที่สุด</span>  </td>
                                                  </tr>
                                                  <tr>
                                                      <td class="question">1. คนที่สามารถสร้างสิ่งต่างๆมากมายที่มีความหมายเพื่อผู้คนรอบข้าง </td>
                                                      <td  class="choice"><input type="radio"  name="1ss" /></td>
                                                      <td class="choice"><input type="radio"  name="1ss" /></td>
                                                      <td class="choice"><input type="radio"  name="1ss" /></td>
                                                      <td class="choice"><input type="radio"  name="1ss" /></td>
                                                  
                                                     
                                                  </tr>
                                                  <tr>
                                                      <td class="question">2. คนที่สามารถทําให้ผู้้คนมองเห็นคุณค่าและความ  อัศจรรย์ในทุกสิ่งทุกอย่างตามที่คุณต้องการ  </td>
                                                      <td  class="choice"><input type="radio"  name="1ss" /></td>
                                                      <td class="choice"><input type="radio"  name="1ss" /></td>
                                                      <td class="choice"><input type="radio"  name="1ss" /></td>
                                                      <td class="choice"><input type="radio"  name="1ss" /></td>
                                                  
                                                     
                                                  </tr>
                                                  <tr>
                                                      <td class="question">3. คนที่สามารถเปลี่ยนสิ่งธรรมดาให้กลายเป็นสิ่งที่พิเศษได้ </td>
                                                      <td  class="choice"><input type="radio"  name="1ss" /></td>
                                                      <td class="choice"><input type="radio"  name="1ss" /></td>
                                                      <td class="choice"><input type="radio"  name="1ss" /></td>
                                                      <td class="choice"><input type="radio"  name="1ss" /></td>
                                                  
                                                     
                                                  </tr>
                                                 <tr>
                                                      <td class="question">4. คนที่สามารถควบคุมผู้คนเพื่อพาพวกเขาบรรลุเป้าหมายที่ท้าทายได้  </td>
                                                      <td  class="choice"><input type="radio"  name="1ss" /></td>
                                                      <td class="choice"><input type="radio"  name="1ss" /></td>
                                                      <td class="choice"><input type="radio"  name="1ss" /></td>
                                                      <td class="choice"><input type="radio"  name="1ss" /></td>
                                                  
                                                     
                                                  </tr>
                                              </table>

                                        </div>
                                       
                                        

                                    </div>
                                </div>
                            </div>



                             <h1></h1>
                            <div class="step-content">
                                <div class="text-center m-t-md">
                                    <h2>ความสามารถแบบใดที่อธิบายตัวคุณได้ดีที่สุด </h2>
                                   <div class="question-type q-type-rank-scale-lr">
                                        <div class="col-md-5 tbl-rank-scale-lr"   >

                                            <table>
                                                <tr><td colspan="5" class="question left">ทุ่มเททํางาน อย่างหนัก </td></tr>
                                                <tr><td class="choice">1</td><td class="choice">2</td><td class="choice">3</td><td class="choice">4</td>
                                                    <td class="choice">5</td></tr>
                                                 <tr>
                                                     <td class="choice"><input type="radio" name="le" /></td>
                                                     <td class="choice"><input type="radio" name="le" /></td>
                                                     <td class="choice"><input type="radio" name="le" /></td>
                                                     <td class="choice"><input type="radio" name="le" /></td>
                                                     <td class="choice"><input type="radio" name="le" /></td>
                                                 </tr>
                                            </table>

                                        </div>

                                          <div class="col-md-2"></div>
                                       <div class="col-md-5 tbl-rank-scale-lr"   >

                                            <table>
                                                <tr><td colspan="5" class="question right">ทุ่มเททํางาน อย่างหนัก </td></tr>
                                                <tr><td class="choice">1</td><td class="choice">2</td><td class="choice">3</td><td class="choice">4</td>
                                                    <td class="choice">5</td></tr>
                                                 <tr>
                                                     <td class="choice"><input type="radio" name="le" /></td>
                                                     <td class="choice"><input type="radio" name="le" /></td>
                                                     <td class="choice"><input type="radio" name="le" /></td>
                                                     <td class="choice"><input type="radio" name="le" /></td>
                                                     <td class="choice"><input type="radio" name="le" /></td>
                                                 </tr>
                                            </table>

                                        </div>
                                        
                                            

                                        </div>

                                    </div>
                                </div>
                            </div>--%>


                        </div>

                    </div>
                                    </div>
									</div>
								
								</div>
							</div>
							<div class="profile-social" style="height:40px;" >


							</div>
						</div>

					</div>	
           </div>
		</section>

    
</asp:Content>
<asp:Content ID="FooterScript" ContentPlaceHolderID="ContentFooter" runat="server">
      <!-- Steps -->
    <script src="Scripts/theme/plugins/steps/jquery.steps.min.js"></script>
    <%--<script src="js/plugins/steps/jquery.steps.min.js"></script>--%>

    <!-- Jquery Validate -->
    <script src="Scripts/theme/plugins/validate/jquery.validate.min.js"></script>
    <%--<script src="js/plugins/validate/jquery.validate.min.js"></script>--%>


     <script>
         $(document).ready(function () {
            
            $("#wizard").steps({
                onInit: function (event, currentIndex) {
                    //alert(currentIndex);
                    progress(currentIndex);
                },
                onStepChanging: function (event, currentIndex, newIndex) {

                    if (currentIndex > newIndex) {
                        return true;
                    }

                    // Forbid suppressing "Warning" step if the user is to young
                    ////if (newIndex === 3 && Number($("#age").val()) < 18) {
                    ////    return false;
                    ////}

                    var form = $("form");

                    // Clean up if user went backward before
                    if (currentIndex < newIndex) {
                        // To remove error styles
                        $(".body:eq(" + newIndex + ") label.error", form).remove();
                        $(".body:eq(" + newIndex + ") .error", form).removeClass("error");
                    }

                    // Disable validation on fields that are disabled or hidden.
                    form.validate().settings.ignore = ":disabled,:hidden";

                    // Start validation; Prevent going forward if false
                    return form.valid();
                },
                onStepChanged: function (event, currentIndex, priorIndex) {

                    //var total_step = $(".step_count").length;
                    //alert(currentIndex);
                    //var pro = $("#progress_bar_per");

                    progress(currentIndex);

                    //// Suppress (skip) "Warning" step if the user is old enough.
                    //if (currentIndex === 2 && Number($("#age").val()) >= 18) {
                    //    $(this).steps("next");
                    //}

                    //// Suppress (skip) "Warning" step if the user is old enough and wants to the previous step.
                    //if (currentIndex === 2 && priorIndex === 3) {
                    //    $(this).steps("previous");
                    //}
                },
                onFinishing: function (event, currentIndex) {
                    var form = $("form");

                    // Disable validation on fields that are disabled.
                    // At this point it's recommended to do an overall check (mean ignoring only disabled fields)
                    form.validate().settings.ignore = ":disabled";

                    // Start validation; Prevent form submission if false
                    return form.valid();
                },
                onFinished: function (event, currentIndex) {
                    var form = $("form");

                    // Submit form input
                    form.submit();
                }
            }).validate({
                errorPlacement: function (error, element) {
                    element.before(error);
                },
                rules: {
                    confirm: {
                        equalTo: "#password"
                    }
                }
            });
            
         });

         function progress(current) {
             var total = $(".step_count").length;

             var percent = ((current + 1) * 100) / total;

             var percent_format = numeral(percent).format('0');
            

            
             $("#progress_bar_per").css("width", percent + "%");
             $('.tooltiptext').css("left", $('#progress_bar_per').width() + "px");
             //setTimeout(function () {
             //    $('.tooltiptext').css("left", $('#progress_bar_per').width() + "px");
             //}, 2000);

             //var w = $('#progress_bar_per').width();
             console.log(current);
             //console.log(w);

             //var f = $('#progress_bar_per').offset();
             //$("#example").animate({ width: 250 }, 200);
            // $('.tooltiptext').animate({ left: $('#progress_bar_per').width() }, 0);
            // $("#progress_bar_per").animate({ width: percent + "%" }, 0);
             var text = percent_format + "% Complete";
             if (percent_format >= 100) {
                 text = "Done!!";
             }
             $('.tooltiptext').html(text);
            
         }
    </script>
    </asp:Content>
