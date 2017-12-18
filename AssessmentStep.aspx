<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.User1.Master" AutoEventWireup="true" CodeFile="AssessmentStep.aspx.cs" Inherits="_AssessmentStep" %>

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
    input[type="checkbox"]{
        background-color: transparent !important;
    }
    input[type="checkbox"]:after {
         
        width: 7px !important;
        height: 10px !important;
    }
    .checkitem tr td{
        padding:0 0 0 20px;
    }

    .main_thanksyoublock{
        padding-bottom:57px;
    }

    .t_title{
        font-family:'Kanit' !important;
        color:#fff;
    }

    .t_des{
         font-family:'Kanit' !important;
        color:#fff;
        font-size:16px;
        margin-bottom:30px;
    }
    .main-wrap {
   
    
}
    .intro-detail{
        font-size:18px;
        color:#fff !important;
        padding-top:40px;
    }

    .intro-detail strong{
         color:#fff !important;
    }

    .wizard > .content > .body input[type="radio"] {
    display: inline-block;
    margin-right: 3px;
    margin-top:0px;
}
/* Show the tooltip text when you mouse over the tooltip container */
/*.tooltip:hover .tooltiptext {
    visibility: visible;
}*/
    </style>
    <link href="Content/animate.css" rel="stylesheet" />
  
    <link href="Content/plugins/steps/jquery.steps.css" rel="stylesheet" />
    
    <link href="Content/plugins/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css" rel="stylesheet">
 <%--   <link href="Content/plugins/sweetalert/sweetalert.css" rel="stylesheet" />--%>
    <link href="Theme/css/swal_custom.css" rel="stylesheet" />
      <link href="Content/plugins/iCheck/custom.css" rel="stylesheet" />
   <%--     <link href="css/plugins/iCheck/custom.css" rel="stylesheet">
    <link href="css/plugins/steps/jquery.steps.css" rel="stylesheet">
    <link href="css/animate.css" rel="stylesheet">--%>
 </asp:Content>
  
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  <asp:HiddenField ID="heUserID" runat="server" />
   <section id="about" class="section section-about">
       <div class="banner">
				<div class="wsite-section-elements">
					<h2 class="wsite-content-title" style="text-align:center;color:#fff;text-transform: uppercase;font-family: 'Lato', sans-serif;margin-bottom:20px;"><asp:Literal ID="Maintitle" runat="server"></asp:Literal></h2>

<div class="paragraph" style="text-align:center;"></div>
				</div>
		
					<div class="animate-up animated" id="main_form" runat="server">
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
                                <p class="intro-detail">
                                    <asp:Literal ID="IntroDetail" runat="server"></asp:Literal>
                                </p>
                                    
                                </div>
                            </div>



                            <h1 id="stepprofile_head" runat="server" class="step_count"></h1>
                            <div class="step-content" id="stepprofile" runat="server">
                                <div class="text-center m-t-md">
                                <h2><asp:Literal ID="profiletitle" runat="server"></asp:Literal></h2>
                               
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

                             <%--<h1 id="H1" runat="server" class="step_count"></h1>
                             <div class="step-content" id="Div2" runat="server" data-valid="checkcount">
                                <div class="text-center m-t-md">
                                <h2><asp:Literal ID="fctitle" runat="server"></asp:Literal></h2>
                               
                                    <div class="q-form-bio form-horizontal">
                                        <div class="form-group">

                                            <div class="col-sm-12" style="padding:0 30px 0 30px">
                                                
                                                <asp:Literal ID="checkFC" runat="server"></asp:Literal>
                                      

                                            </div>
                                        </div>
                                        
                                    </div>
                                    
                                </div>
                            </div>--%>

                             <h1 id="stepprofile_CJF" runat="server" class="step_count"></h1>
                             <div class="step-content" id="Div1" runat="server" data-valid="checkcount">
                                <div class="text-center m-t-md">
                                <h2><asp:Literal ID="cjftitle" runat="server"></asp:Literal></h2>
                               
                                    <div class="q-form-bio form-horizontal">
                                        <div class="form-group"><%--<label class="col-sm-2 control-label">Current Job Function name:</label>--%>

                                            <div class="col-sm-12" style="padding:0 30px 0 30px">
                                                
                                                <asp:Literal ID="chckCJF" runat="server"></asp:Literal>
                                           <%-- <asp:CheckBoxList ID="chckCJF" runat="server" CssClass="checkitem" RepeatLayout="Table"  RepeatDirection="Horizontal"></asp:CheckBoxList>--%>

                                            </div>
                                        </div>
                                        
                                    </div>
                                    
                                </div>
                            </div>

                          
                         <asp:Literal ID="Stepcontent" runat="server"></asp:Literal>


                            <h1  class="step_count"></h1>
                            <div class="step-content">
                                <div class="text-center m-t-md">
                                <h2><asp:Literal ID="LastTitle" runat="server"></asp:Literal></h2>
                                <p>
                                    <asp:Literal ID="LastDes" runat="server"> </asp:Literal>
                                </p>
                                    <div class="q-form-bio form-horizontal">
                                        <div class="form-group"><%--<label class="col-sm-2 control-label">Current Job Function name:</label>--%>

                                            <div class="col-sm-12" style="padding:0 30px 0 30px">
                                                
                                         <asp:TextBox ID="txtPhon" runat="server" ClientIDMode="Static" placeholder="###-###-####" CssClass="form-control required customphone" TextMode="Phone"></asp:TextBox>

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
							</div>
							<div class="profile-social" style="height:40px;" >


							</div>
						</div>

					</div>	

                    <div id="main_thanks" class="animate-up animated" runat="server" visible="false">

                        <div class="section-box">
							<div class="profile">
								<div class="row">
									<div class="col-xs-12">
									 <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <%--<h5>Basic Wizzard</h5>--%>
                        <div class="col-md-12">
                             <h2 class="t_title"><asp:Literal ID="ThanksTitle" runat="server"></asp:Literal> </h2>
                        </div>
                        
                    </div>
                    <div class="ibox-content">
                        <div class="main_thanksyoublock col-md-12">
                           
                            <div class="t_des"><asp:Literal ID="ThanksDes" runat="server"></asp:Literal></div>
                            <div class="btn_pan">

                              <%--  <asp:Button ID="btnBackprofile" style="background-color:#3f51b5;margin:0 auto;color:#fff !important;margin-top: 10px;" CssClass="btn btn-lg btn-border ripple" runat="server" OnClick="btnBackprofile_Click" Text="Your profile" />--%>
                                 <asp:Button ID="btnDownload" style="background-color:#3f51b5;margin:0 auto;color:#fff !important;margin-top: 10px;" CssClass="btn btn-lg btn-border ripple" runat="server" OnClick="btnDownload_Click" Text="Next" />
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
		</section>

    
</asp:Content>
<asp:Content ID="FooterScript" ContentPlaceHolderID="ContentFooter" runat="server">
      <!-- Steps -->
    <script src="Scripts/theme/plugins/steps/jquery.steps.min.js"></script>
    <%--<script src="js/plugins/steps/jquery.steps.min.js"></script>--%>

    <!-- Jquery Validate -->
    <script src="Scripts/theme/plugins/validate/jquery.validate.min.js"></script>
    <%--<script src="js/plugins/validate/jquery.validate.min.js"></script>--%>
    <%--<script src="Scripts/theme/plugins/sweetalert/sweetalert.min.js"></script>--%>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
     <script>
         $(document).ready(function () {

             $(document).on('click', '.rank_left_right', function () {

                 var parent = $(this).closest('.q-type-rank-scale-lr');

                 parent.find('.rank_left_right').removeAttr('checked');
                 $(this).prop('checked', true);
             });

             $.validator.setDefaults({
                 onkeyup: function () {
                     var originalKeyUp = $.validator.defaults.onkeyup;
                     var customKeyUp = function (element, event) {
                         if ($("#txtPhon")[0] === element) {

                                   // var v = $(element).val();

                                    //var arv = v.split('');
                                    //if (arv.length == 3 || arv.length == 7) {
                                    //    if (event.keyCode != 46 || event.keyCode != 8) {
                                    //        $(element).val(v + "-");
                                    //    }
                                       
                                    //}
                                    //if (arv.length == 7) {
                                    //    $(element).val(v + "-");
                                    //}

                                    if ((event.keyCode > 47 && event.keyCode < 58) || (event.keyCode < 106 && event.keyCode > 95)) {
                                        var v = $(element).val();
                                        v = v.replace(/(\d{3})(\d{3})(\d{4})\-?/g, '$1-$2-$3');
                                        $(element).val(v);
                                        return true;
                                    }
                                    
                                    //console.log(arv);
                                    //console.log(arv.length);
                                    //return false;
                                    return $(element).valid();
                         }
                         else {
                             return originalKeyUp.call(this, element, event);
                         }
                     }

                     return customKeyUp;
                 }()
             });
             //$("form").validate({
             //    onkeyup: function (ele) {
             //        var v = $(ele).val();

             //        var arv = v.split('');

             //        console.log(arv);
             //        console.log(arv.length);

             //        return false;
             //    }
             //});
             //$('#txtPhon').on('keyup', function () {
               
             //});

             $.validator.addMethod('customphone', function (value, element) {
                 return this.optional(element) || /^\d{3}-\d{3}-\d{4}$/.test(value);
             }, "Please enter a valid phone number");

             //$.validator.addMethod("roles", function (value, elem, param) {
             //    if ($(".roles:checkbox:checked").length > 0) {
             //        return true;
             //    } else {
             //        return false;
             //    }
             //}, "You must select at least one!");

             $.LoadingOverlaySetup({
                 color: "rgba(0, 0, 0, 0.4)",
                 //image: "img/custom_loading.gif",
                 //maxSize: "80px",
                 //minSize: "20px",
                 //resizeInterval: 0,
                 //size: "50%"
             });
            $("#wizard").steps({
                onInit: function (event, currentIndex) {
                    //alert(currentIndex);
                    progress(currentIndex);
                },
              
                labels:
                {
                   
                    finish: "ดำเนินการต่อ",
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
                    var valid = $("#wizard .body.current").data('valid');

                    if (valid == "checkcount") {
                        if ($("#wizard .body.current").find('input[type=radio]:checked').length == 0) {
                            //alert("You must select at least one!");

                            swal({
                                icon: "warning",
                                title: "Alerts",
                                text: "You must select at least one!"
                               
                            });
                            return false;
                        }
                    }

                    if (valid == "check_rank1") {
                        if ($("#wizard .body.current").find('input[type=radio]:checked').length == 0) {
                            //alert("You must select at least one!");
                            swal({
                                icon: "warning",
                                title: "Alerts",
                                text: "You must select at least one!"
                            });
                            return false;
                        }
                    }

                    if (valid == "check_choice") {
                        if ($("#wizard .body.current").find('input[type=radio]:checked').length == 0) {
                            //alert("You must select at least one!");

                            swal({
                                icon: "warning",
                                title: "Alerts",
                                text: "You must select at least one!"
                            });
                            return false;
                        } else {

                            var count = $("#wizard .body.current").data('count');
                            if ($("#wizard .body.current").find('input[type=radio]:checked').length < count) {

                                //alert("กรุณา เลือก ให้ครบ");
                                swal({
                                    icon: "warning",
                                    title: "Alerts",
                                    text: "ท่านยังเลือก คำตอบไม่ครบ"
                                });
                                return false;
                            } else {
                                var radio = $("#wizard .body.current").find('input[type=radio]:checked');
                                var ret = true;
                                $.each(radio, function () {
                                    var _this = $(this);
                                    var check = $.grep(radio, function (data, i) {

                                        if ($(data).attr('name') != _this.attr('name')) {
                                            return $(data).val() == _this.val();
                                        }
                                       
                                    });

                                    if (check.length > 0) {
                                        ret = false;
                                        return false;
                                    }
                                });

                                if (!ret) {
                                    //alert("ท่านเลือก คำตอบ ซ้ำกัน");
                                    swal({
                                        icon: "warning",
                                        title: "Alerts",
                                        text: "ท่านเลือก คำตอบ ซ้ำกัน"
                                    });
                                    return false;
                                }
                            }


                        }
                    }

                   

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
                    $.LoadingOverlay("show");
                    SendData();
                    
                    //form.submit();
                }
            }).validate({
               
                errorPlacement: function (error, element) {
                         if (element.attr("type") == "checkbox") {
                             error.insertAfter($(element).closest('step-content').find('h2'));
                    } else {
                        element.before(error);
                    }
                   
                },
                rules: {
                    ctl00$MainContent$txtPhon: "customphone",
                   
                    confirm: {
                        equalTo: "#password"
                    },
                    chckCJF_form: function (element) {
                        console.log(element);
                    }
                     
                },
                messages: {
                    chckCJF_form: {
                        required: 'กรุณา เลือกอย่างน้อย 1 ข้อ'
                    }
                }
            });
            
         });

        
         function SendData() {
             var post = $("#form1").find("input,textarea,select,hidden").not("#__VIEWSTATE,#__EVENTVALIDATION").serialize();
             $.post("ajax_save_assessment.aspx", post, function (data) {
                 if (data == "True") {
                     window.location.href = "Assessmentstep.aspx?success=done";
                 } else {

                     if (data == "False") {
                         
                     } else {
                         window.location.href = "AssessmentStepCheck.aspx?ts=" + data;
                     }
                    
                 }

                

             });
         }
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
