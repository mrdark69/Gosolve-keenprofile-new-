<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="UserAssCalculation.aspx.cs" Inherits="Users_UserAssCalculation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderScript" runat="server">
    <style>
      th.dt-center,td.dt-center{
           text-align:center;
       }
      tr.selected, tr.selected:hover{
          background-color:rgb(204, 231, 226)!important;
         
      }
      
      .table-hover tbody tr.selected:hover td, .table-hover tbody tr.selected:hover th {
        background-color: rgb(204, 231, 226)!important;
    }
      .table-hover tbody tr.selected.odd:hover td, .table-hover tbody tr.selected.odd:hover th {
        background-color: rgb(204, 231, 226)!important;
    }
      .dt-buttons.btn-group{
          float:right;
          margin-left:1px;
      }
      .app-feature-sel{
          margin-bottom:20px;
      }
       .app-feature-sel ul li{
           list-style:none;
           padding:3px;
           font-weight:bold;
       }
       .app-sec-lev{
           margin-left:20px;
           
       }
       .app-sec-lev li{
           margin-bottom:0px !important;
       }
       .pagination{
           margin:0;
       }

       div.checkitem div.item {
            display: inline-block;
            margin-left: 20px;
            padding: 5px;
        }
       div.checkitem {
            width: 95%;
            text-align: left;
        }
   </style>
 </asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
            <div class="row">
                <div class="col-lg-12">

                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>User Calculation</h5>
                            
                        </div>
                        <div class="ibox-content">
                            <div class="panel-body">
                                <div class="panel-group" id="accordion">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <h5 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="false" class="collapsed">[T1] - Working Philosophies
</a>
                                            </h5>
                                        </div>
                                        <div id="collapseOne" class="panel-collapse collapse" aria-expanded="false" style="height: 0px;">
                                            <div class="panel-body">
                                             <div>
                                                    <h1>" F" Section Result</h1>
                                                     <asp:Literal ID="data" runat="server"></asp:Literal>
                                                </div>

                                                <div>
                                                    <h1>"H" Section Result</h1>
                                                     <asp:Literal ID="datah2" runat="server"></asp:Literal>
                                                </div>

                                                 <div>
                                                      <h1>"T1" Section Result</h1>
                                                      <asp:Literal ID="dataf2" runat="server"></asp:Literal>  
                                                 </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <h4 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" class="collapsed" aria-expanded="false">[T2] - Working Traits 
</a>
                                            </h4>
                                        </div>
                                        <div id="collapseTwo" class="panel-collapse collapse" aria-expanded="false" style="height: 0px;">
                                            <div class="panel-body">
                                              <div>
                                                    <h1>"D" Section Result</h1>
                                                     <asp:Literal ID="dataD" runat="server"></asp:Literal>
                                                </div>

                                                <div>
                                                    <h1>"E" Section Result</h1>
                                                     <asp:Literal ID="DAtaE" runat="server"></asp:Literal>
                                                </div>

                                                 <div>
                                                      <h1>"T2" Section Result</h1>
                                                      <asp:Literal ID="dataT2" runat="server"></asp:Literal>  
                                                 </div> 
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <h4 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseThree" class="collapsed" aria-expanded="false">[T3] - Working Geniuses
</a>
                                            </h4>
                                        </div>
                                        <div id="collapseThree" class="panel-collapse collapse" aria-expanded="false" style="height: 0px;">
                                            <div class="panel-body">
                                                <div>
                                                    <h1>"B" Section Result</h1>
                                                     <asp:Literal ID="datab1" runat="server"></asp:Literal>
                                                </div>

                                                <div>
                                                    <h1>"B" Summary Section Result</h1>
                                                     <asp:Literal ID="datab2" runat="server"></asp:Literal>
                                                </div>

                                                 <div>
                                                      <h1>"T3" Section Result</h1>
                                                      <asp:Literal ID="datab3" runat="server"></asp:Literal>  
                                                 </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>



                                 <div class="form-group">
                                    <%--<label class="col-sm-2 control-label"></label>--%>
                                    <div class="col-sm-12" style="padding:0 0px 0 15px">
                                      <asp:Button ID="btnRecal"  CssClass="btn btn-w-m btn-success" runat="server" OnClick="btnRecal_Click"  Text="Re Calculate" />
                                        </div>
                                </div>  

                            </div>
                        </div>
                    </div>





                </div>
            </div>

                
        </div>
</asp:Content>
<asp:Content ID="FooterScript" ContentPlaceHolderID="ContentFooter" runat="server">



    <script type="text/javascript">

        
        $(document).ready(function () {

            $('.check_focus').on('click', function () {

                if ($(this).is(':checked')) {
                    var f = $('tr.focuss');
                    var d = $(this).val();
                    $.each(f, function () {
                        if ($(this).data('fo') == d) {
                            $(this).css('background-color', '#f1f442');
                        }
                    });
                } else {
                    $.each(f, function () {
                        if ($(this).data('fo') == d) {
                            $(this).removeAttr('style');
                        }
                    });
                }
            })
           
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


        function getParameterByName(name, url) {
            if (!url) url = window.location.href;
            name = name.replace(/[\[\]]/g, "\\$&");
            var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
                results = regex.exec(url);
            if (!results) return null;
            if (!results[2]) return '';
            return decodeURIComponent(results[2].replace(/\+/g, " "));
        }

       
        

    </script>

</asp:Content>