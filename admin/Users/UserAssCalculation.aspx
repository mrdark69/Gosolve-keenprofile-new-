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
                            <h5>User Calculation <%--<small>With custom checbox and radion elements.</small>--%></h5>
                          
                        </div>
                         <div class="ibox-content">
                       
                            <asp:Label ID="lblError" runat="server" style="color: red;text-align: center;margin: 0 auto;display: block;"></asp:Label>
                            <div class="q-form-bio form-horizontal">
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