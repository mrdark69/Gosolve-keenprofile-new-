<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.User1.Master" AutoEventWireup="true" CodeFile="Thankyou.aspx.cs" Inherits="_Orders" %>

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

    label.error {
    color: #8a1f11;
    display: inline-block;
    margin-left: 1.5em;
}

 label.error {
    float: left;
    color: red !important;
    font-weight: normal !important;
    font-size: 12px !important;
}

/*.wizard > .content > .body label {
    display: inline-block;*/
    /*margin-bottom: 0.5em;*/
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
  <asp:HiddenField ID="heUserID" runat="server" />
   <section id="about" class="section section-about">
       <div class="banner">
				<div class="wsite-section-elements">
					<h2 class="wsite-content-title" style="text-align:center;color:#fff;text-transform: uppercase;font-family: 'Lato', sans-serif;margin-bottom:20px;"><asp:Literal ID="Maintitle" runat="server"></asp:Literal></h2>

<div class="paragraph" style="text-align:center;"></div>
				</div>
		
						

                    <div id="main_thanks" class="animate-up animated" runat="server" >

                        <div class="section-box">
							<div class="profile" style="padding-top:0px;">
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
                                               <h2  class="t_title"> <asp:Literal ID="lbldes" runat="server"></asp:Literal> 
</h2>
                                              <%-- <p class="t_title">ท่านสามารถชำระ ค่าบริการผ่านช่องทาง ด้านล่างนี้</p>--%>
                                             
                                               <div class="btn_pan">

                              <%--  <asp:Button ID="btnBackprofile" style="background-color:#3f51b5;margin:0 auto;color:#fff !important;margin-top: 10px;" CssClass="btn btn-lg btn-border ripple" runat="server" OnClick="btnBackprofile_Click" Text="Your profile" />--%>
                                 <asp:Button ID="btnDownload" style="background-color:#3f51b5;margin:0 auto;color:#fff !important;margin-top: 10px;float:right" CssClass="btn btn-lg btn-border ripple" runat="server" OnClick="btnDownload_Click"  Text="คลิ๊กเพื่อกลับไปหน้า ดาวโหลด" />
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


     <script>
         $(document).ready(function () {


             $.validator.setDefaults({
                 onkeyup: function () {
                     var originalKeyUp = $.validator.defaults.onkeyup;
                     var customKeyUp = function (element, event) {
                         if ($("#txtPhon")[0] === element) {

                                   
                                    if ((event.keyCode > 47 && event.keyCode < 58) || (event.keyCode < 106 && event.keyCode > 95)) {
                                        var v = $(element).val();
                                        v = v.replace(/(\d{3})(\d{3})(\d{4})\-?/g, '$1-$2-$3');
                                        $(element).val(v);
                                        return true;
                                    }
                                    
                                    return $(element).valid();
                         }
                         else {
                             return originalKeyUp.call(this, element, event);
                         }
                     }

                     return customKeyUp;
                 }()
             });


             $.validator.addMethod('customphone', function (value, element) {
                 return this.optional(element) || /^\d{3}-\d{3}-\d{4}$/.test(value);
             }, "Please enter a valid phone number");


             $("form").validate({

                 errorPlacement: function (error, element) {
                     element.after(error);
                 },
                 rules: {
                     ctl00$MainContent$txtPhon: "customphone",
                     ctl00$MainContent$txtEmail: {
                         email: true
                     },
                     confirm: {
                         equalTo: "#password"
                     }
                 }
             });
           
            
         });


         function submitbtn() {

             var form = $("form");

             var chckFC_form = $('input[name="chckFC_form"]');

             var chckCJF_form = $('input[name="chckCJF_form"]');

             //if (chckFC_form) {
             //    if ($('input[name=chckFC_form]:checked').length == 0) {
             //        alert("You must select Functional Competencies at least one!");
             //        return false;
             //    }
             //}

             if (chckCJF_form) {
                 if ($('input[name=chckCJF_form]:checked').length == 0) {
                     alert("You must select Current Job Function  at least one!");
                     return false;
                 }
             }



             return form.valid();
             //return form.valid();
         }
        
    </script>
    </asp:Content>
