<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="UserDetail.aspx.cs" Inherits="Users_UserDetail" %>
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
                            <h5>User Profile <%--<small>With custom checbox and radion elements.</small>--%></h5>
                          
                        </div>
                         <div class="ibox-content">
                       
                            <asp:Label ID="lblError" runat="server" style="color: red;text-align: center;margin: 0 auto;display: block;"></asp:Label>
                            <div class="q-form-bio form-horizontal">
                                        <div class="form-group"><label class="col-sm-2 control-label">First name:</label>

                                            <div class="col-sm-10">
                                                <asp:TextBox ID="firstName" runat="server" CssClass="form-control required"></asp:TextBox>
                                               
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Last name:</label>

                                            <div class="col-sm-10">
                                                    <asp:TextBox ID="LastName" runat="server" CssClass="form-control required"></asp:TextBox>
                                               
                                            </div>
                                        </div>

                                     <div class="form-group">
                                            <label class="col-sm-2 control-label">Email:</label>

                                            <div class="col-sm-10">
                                                    <asp:TextBox TextMode="Email" ID="txtEmail" runat="server" CssClass="form-control required"></asp:TextBox>
                                               
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
                                <div class="form-group"><label class="col-sm-2 control-label">Mobile Phone:</label>

                                            <div class="col-sm-10" style="padding:0 0px 0 15px">
                                                
                                         <asp:TextBox ID="txtPhon" runat="server" ClientIDMode="Static" placeholder="###-###-####" CssClass="form-control required customphone" TextMode="Phone"></asp:TextBox>

                                            </div>
                                        </div>
                                 <div class="form-group"><label class="col-sm-2 control-label">Functional Competencies:</label>

                                            <div class="col-sm-10" style="padding:0 0px 0 0px">
                                                
                                                <asp:Literal ID="checkFC" runat="server"></asp:Literal>
                                     

                                            </div>
                                        </div>
                                 <div class="form-group"><label class="col-sm-2 control-label">Current Job Function name:</label>

                                            <div class="col-sm-10" style="padding:0 0px 0 0px">
                                                
                                                <asp:Literal ID="chckCJF" runat="server"></asp:Literal>
                                        

                                            </div>
                                        </div>

                                <div class="form-group">
                                    <label class="col-sm-2 control-label"></label>
                                    <div class="col-sm-10" style="padding:0 0px 0 0px">
                                      <asp:Button ID="btnDownload"  CssClass="btn btn-w-m btn-success" runat="server" OnClientClick="return submitbtn();" OnClick="btnDownload_Click"  Text="Update Now" />
                                        </div>
                                </div>          

                                    </div>
                           
                        

                               
                          
                 
                        
                        </div>
                    </div>
                </div>
            </div>

                <div class="row">
                     <div class="col-lg-12">
                        <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>Transaction List <%--<small>With custom checbox and radion elements.</small>--%></h5>
                          
                        </div>
                         <div class="ibox-content">
                             <div class="form-group">
                            
                                 <div class="col-md-12">
                                  
                                <div class="table-responsive">
                                        <table class="table table-striped">
                                            <thead>
                                            <tr>
                                                  <th> TSID </th>
                                                    <th> Date</th>
                                             
                                                <th>Download Count </th>
                                                
                                               
                                                <th>Status </th>
                                                <th>Action</th>
                                            </tr>
                                            </thead>
                                            <tbody id="body_list">
                                         
                                    
                                            </tbody>
                                        </table>
                                    </div>
                                     </div>
                                <div style="clear:both"></div>
                            </div>

                             <div style="clear:both"></div>
                         </div>
                        </div>
                    </div>
                </div>
        </div>
</asp:Content>
<asp:Content ID="FooterScript" ContentPlaceHolderID="ContentFooter" runat="server">



    <script type="text/javascript">

        
        $(document).ready(function () {

            getList();

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

        function getList() {

            var url = "<%= ResolveUrl("/admin/Users/ajax_webmethod_user.aspx/GetTsByUserID") %>";
            
            var uid = getParameterByName('s');

             //store.set('Paging_now', s);
            // var offset = (s - 1) * ps;
            // var PagingParam = { Start: offset, Length: ps, CustomSearchList: CustomSearchList, Order: Order };
             var data = { UserID: uid };
             var param = JSON.stringify({ parameters: data });

             AjaxPost(url, param, function () {

             }, function (data) {

                 //  console.log(data);
                 var h = GenlistAll(data);
                 $('#body_list').html(h);
                 //var totalS = data[0].TotalRows;
                 //$('<input type="hidden" id="hd_listTotal" value="' + totalS + '" />').appendTo("body");
                 //paging(data);
             });
        }

        function GenlistAll(data) {
            var ret = "";
            for (var i in data) {
                var gender = "<i class=\"fa fa-male\"></i>";
                var verify = "<span class=\"badge\">Wating</span>";
                var paid = "<span class=\"badge badge-warning\">free user</span>";

                if (data[i].EmailVerify) {
                    verify = "<span class=\"badge badge-success\">Success</span>";
                }

                if (data[i].Ispaid) {
                    paid = "<span class=\"badge badge-primary\">Paid user</span>";
                }

                if (data[i].Gender == 2) {
                    gender = "<i class=\"fa fa-female\"></i>";
                }


                //<i class="fa fa-female"></i>
                //
                var txt = 'Active';
                var bage = 'primary'
                if (!data[i].Status) { txt = 'Inactive'; bage = 'default'; }
                var day = moment(data[i].DateSubmit).format('DD-MMM-YYYY HH:mm');
                ret += '<tr>';
                ret += '   <td>TS' + data[i].TransactionID + '</td>';
                ret += '   <td>' + day + '</td>';
                //ret += '   <td><input type="checkbox" checked class="i-checks" name="input[]"></td>';
                //ret += '   <td>' + gender + ' ' + (data[i].FirstName == null ? 'XXXX' : data[i].FirstName) + ' ' + (data[i].LastName == null ? 'XXXX' : data[i].LastName) + '</td>';
                //ret += '   <td>' + (data[i].MobileNumber == null ? 'XXX-XXX-XXXX' : data[i].MobileNumber) + '</td>';
                //ret += '   <td>' + data[i].Email + '</td>';

                ret += '   <td style="text-align:left">' + data[i].DownloadCount + '</td>';

                //ret += '   <td>' + paid + '</td>';
                ret += '   <td style="text-align:left"><span class="label label-' + bage + '">' + txt + '</span></td>';
                //ret += '   <td>' + verify +'</td>';
                //ret += '   <td><span class="label label-primary">' + data[i].UserRoleName +'</span></td>';
                ret += '   <td><a href="UserAssDetail?ts=' + data[i].TransactionID + '"><i class="fa fa-pencil"></i> view </a></td>';
                ret += '   </tr >';
            }




            return ret;
        }

        function submitbtn() {

            var form = $("form");

            var chckFC_form = $('input[name="chckFC_form"]');

            var chckCJF_form = $('input[name="chckCJF_form"]');

            if (chckFC_form) {
                if ($('input[name=chckFC_form]:checked').length == 0) {
                    alert("You must select Functional Competencies at least one!");
                    return false;
                }
            }

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