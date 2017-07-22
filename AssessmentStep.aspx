<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.User.Master" AutoEventWireup="true" CodeFile="AssessmentStep.aspx.cs" Inherits="_AssessmentStep" %>

<asp:Content ID="HeaderScript" ContentPlaceHolderID="HeaderScript" runat="server">
    <style type="text/css">
        
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
					<h2 class="wsite-content-title" style="text-align:center;color:#fff;text-transform: uppercase;font-family: 'Lato', sans-serif;margin-bottom:20px;">Working Geniuses & Current Job Assessment</h2>

<div class="paragraph" style="text-align:center;"></div>
				</div>
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

                        <div class="progress">
                                <div style="width: 35%;background-color:#1161ee" aria-valuemax="100" aria-valuemin="0" aria-valuenow="35" role="progressbar" class="progress-bar " >
                                    <span class="sr-only">35% Complete (success)</span>
                                </div>
                            </div>
                        <div id="wizard">
                            <h1></h1>
                            <div class="step-content">
                                <div class="text-center m-t-md">
                                <h2>ขอต้อนรับสู่ Assessment ของทาง Keen Profile</h2>
                                <p>
                                    ขอให้คุณใช้เวลาประมาณ 20 นาที เพื่อตอบคำถามในแบบสอบถามนี้ 
                                    เพื่อที่ทางทีมงานจะสามารถนำข้อมูลที่ได้ไปทำการวิเคราะห์และให้คำปรึกษาแก่คุณในด้านต่างๆ ในลำดับต่อไป
                                </p>
                                    
                                </div>
                            </div>

                            <h1></h1>
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
        $(document).ready(function(){
            $("#wizard").steps({
                onStepChanging: function (event, currentIndex, newIndex) {

                    return true;
                },
                onStepChanged: function (event, currentIndex, priorIndex) {
                    return true;
                },
                onFinishing: function (event, currentIndex) {
                    return true;
                },
                onFinished: function (event, currentIndex) {
                    return true;
                }
            });
            
       });
    </script>
    </asp:Content>
