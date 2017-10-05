<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="JobFitScoreContent.aspx.cs" Inherits="_JobFitScoreContent" %>
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
        input[type=checkbox],input[type=radio]{
margin-right:5px;
}
   </style>
 </asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
           <div class="row" >
                <div class="col-lg-12">
                    <div class="tabs-container">
                        <ul class="nav nav-tabs">
                            <li class="active" id="li_tab1" runat="server"><a href="JobFitScoreContent" id="tab1" runat="server" aria-expanded="true">JobFit Score Rule</a></li>
                            <li class="" id="li_tab2" runat="server"><a href="JobFitScoreContent?tab=2" id="tab2" runat="server" aria-expanded="false">Ideal Score</a></li>
                            <li class="" id="li_tab3" runat="server"><a href="JobFitScoreContent?tab=3" id="tab3" runat="server" aria-expanded="false">Job Fit Score Explanation</a></li>
                            <li class="" id="li_tab4" runat="server"><a href="JobFitScoreContent?tab=4" id="tab4" runat="server" aria-expanded="false">Job Fit Score Result</a></li>
                           
                        </ul>
                        <div class="tab-content">
                            <div id="tab_content1" runat="server" class="tab-pane active">
                                <div class="panel-body">
                                    <table class="table table-strip">
                                         <tr>
                                            <th></th>
                                            <th></th>
                                            <th colspan="5">Current Job Requirement</th>
                                            <th></th>
                                            <th></th>
                                            <th></th>
                                            <th></th>
                                        
                                        </tr>
                                        <tr>
                                         
                                            <th style="width:40%"></th>
                                            <th style="width:10%;text-align:center">score</th>
                                            <th style="width:10%;text-align:center">1</th>
                                            <th style="width:10%;text-align:center">2</th>
                                            <th style="width:10%;text-align:center">3</th>
                                            <th style="width:10%;text-align:center">4</th>
                                            <th style="width:10%;text-align:center">5</th>
                                        </tr>
                                        <tr>
                                            <td><asp:TextBox ID="txtRuleTitle1" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td><asp:TextBox ID="txtRuleScore1" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td><asp:TextBox ID="txtr1_1" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td><asp:TextBox ID="txtr1_2" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td><asp:TextBox ID="txtr1_3" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td><asp:TextBox ID="txtr1_4" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td><asp:TextBox ID="txtr1_5" runat="server" CssClass="form-control"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td><asp:TextBox ID="txtRuleTitle2" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td><asp:TextBox ID="txtRuleScore2" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td><asp:TextBox ID="txtr2_1" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td><asp:TextBox ID="txtr2_2" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td><asp:TextBox ID="txtr2_3" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td><asp:TextBox ID="txtr2_4" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td><asp:TextBox ID="txtr2_5" runat="server" CssClass="form-control"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td><asp:TextBox ID="txtRuleTitle3" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td><asp:TextBox ID="txtRuleScore3" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td><asp:TextBox ID="txtr3_1" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td><asp:TextBox ID="txtr3_2" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td><asp:TextBox ID="txtr3_3" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td><asp:TextBox ID="txtr3_4" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td><asp:TextBox ID="txtr3_5" runat="server" CssClass="form-control"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td><asp:TextBox ID="txtRuleTitle4" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td><asp:TextBox ID="txtRuleScore4" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td><asp:TextBox ID="txtr4_1" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td><asp:TextBox ID="txtr4_2" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td><asp:TextBox ID="txtr4_3" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td><asp:TextBox ID="txtr4_4" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td><asp:TextBox ID="txtr4_5" runat="server" CssClass="form-control"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td><asp:TextBox ID="txtRuleTitle5" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td><asp:TextBox ID="txtRuleScore5" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td><asp:TextBox ID="txtr5_1" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td><asp:TextBox ID="txtr5_2" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td><asp:TextBox ID="txtr5_3" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td><asp:TextBox ID="txtr5_4" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td><asp:TextBox ID="txtr5_5" runat="server" CssClass="form-control"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                    </div>
                            </div>

                            <div id="tab_content2" runat="server" class="tab-pane active">
                                 <div class="panel-body">
                                      <table class="table table-strip">
                                          <tr>
                                              <th>Score</th>
                                              <th>Value</th>
                                          </tr>
                                          <tr>
                                             <td><asp:TextBox ID="ideal_socore_1" runat="server" CssClass="form-control"></asp:TextBox></td>
                                               <td><asp:TextBox ID="ideal_value_1" runat="server" CssClass="form-control"></asp:TextBox></td>
                                              
                                          </tr>
                                           <tr>
                                            <td><asp:TextBox ID="ideal_socore_2" runat="server" CssClass="form-control"></asp:TextBox></td>
                                               <td><asp:TextBox ID="ideal_value_2" runat="server" CssClass="form-control"></asp:TextBox></td>
                                              
                                          </tr>
                                           <tr>
                                            <td><asp:TextBox ID="ideal_socore_3" runat="server" CssClass="form-control"></asp:TextBox></td>
                                               <td><asp:TextBox ID="ideal_value_3" runat="server" CssClass="form-control"></asp:TextBox></td>
                                              
                                          </tr>
                                           <tr>
                                            <td><asp:TextBox ID="ideal_socore_4" runat="server" CssClass="form-control"></asp:TextBox></td>
                                               <td><asp:TextBox ID="ideal_value_4" runat="server" CssClass="form-control"></asp:TextBox></td>
                                              
                                          </tr>
                                           <tr>
                                            <td><asp:TextBox ID="ideal_socore_5" runat="server" CssClass="form-control"></asp:TextBox></td>
                                               <td><asp:TextBox ID="ideal_value_5" runat="server" CssClass="form-control"></asp:TextBox></td>
                                              
                                          </tr>
                                          </table>
                                     </div>
                            </div>

                              <div id="tab_content3" runat="server" class="tab-pane active">
                                 <div class="panel-body">
                                     <table class="table table-strip">
                                          <tr>
                                              <th style="width:10%">From</th>
                                              <th style="width:10%">To</th>
                                              <th style="width:80%">Explanation</th>
                                            
                                          </tr>
                                          <tr>
                                             <td><asp:TextBox ID="exp_from_1" runat="server" CssClass="form-control"></asp:TextBox></td>
                                               <td><asp:TextBox ID="exp_to_1" runat="server" CssClass="form-control"></asp:TextBox></td>
                                              <td><asp:TextBox ID="exp_des_1" TextMode="MultiLine" Rows="5" runat="server" CssClass="form-control"></asp:TextBox></td>
                                              
                                          </tr>
                                           <tr>
                                         <td><asp:TextBox ID="exp_from_2" runat="server" CssClass="form-control"></asp:TextBox></td>
                                               <td><asp:TextBox ID="exp_to_2" runat="server" CssClass="form-control"></asp:TextBox></td>
                                              <td><asp:TextBox ID="exp_des_2" TextMode="MultiLine" Rows="5" runat="server" CssClass="form-control"></asp:TextBox></td>
                                             
                                              
                                          </tr>
                                           <tr>
                                            <td><asp:TextBox ID="exp_from_3" runat="server" CssClass="form-control"></asp:TextBox></td>
                                               <td><asp:TextBox ID="exp_to_3" runat="server" CssClass="form-control"></asp:TextBox></td>
                                              <td><asp:TextBox ID="exp_des_3" TextMode="MultiLine" Rows="5" runat="server" CssClass="form-control"></asp:TextBox></td>
                                         
                                              
                                          </tr>
                                           <tr>
                                            <td><asp:TextBox ID="exp_from_4" runat="server" CssClass="form-control"></asp:TextBox></td>
                                               <td><asp:TextBox ID="exp_to_4" runat="server" CssClass="form-control"></asp:TextBox></td>
                                              <td><asp:TextBox ID="exp_des_4" TextMode="MultiLine" Rows="5" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            
                                          </tr>
                                          <tr>
                                            <td><asp:TextBox ID="exp_from_5" runat="server" CssClass="form-control"></asp:TextBox></td>
                                               <td><asp:TextBox ID="exp_to_5" runat="server" CssClass="form-control"></asp:TextBox></td>
                                              <td><asp:TextBox ID="exp_des_5" TextMode="MultiLine" Rows="5" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            
                                          </tr>
                                          <tr>
                                            <td><asp:TextBox ID="exp_from_6" runat="server" CssClass="form-control"></asp:TextBox></td>
                                               <td><asp:TextBox ID="exp_to_6" runat="server" CssClass="form-control"></asp:TextBox></td>
                                              <td><asp:TextBox ID="exp_des_6" TextMode="MultiLine" Rows="5" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            
                                          </tr>
                                          <tr>
                                            <td><asp:TextBox ID="exp_from_7" runat="server" CssClass="form-control"></asp:TextBox></td>
                                               <td><asp:TextBox ID="exp_to_7" runat="server" CssClass="form-control"></asp:TextBox></td>
                                              <td><asp:TextBox ID="exp_des_7" TextMode="MultiLine" Rows="5" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            
                                          </tr>
                                          </table>
                                     </div>
                            </div>
                             <div id="tab_content4" runat="server" class="tab-pane active">
                                 <div class="panel-body">
                                      <table class="table table-strip">
                                          <tr>
                                              <th>From</th>
                                              <th>To</th>
                                              <th>Top 7</th>
                                              <th>other</th>
                                              <th>Bottom 4</th>
                                          </tr>
                                          <tr>
                                             <td><asp:TextBox ID="result_from_1" runat="server" CssClass="form-control"></asp:TextBox></td>
                                               <td><asp:TextBox ID="result_to_1" runat="server" CssClass="form-control"></asp:TextBox></td>
                                              <td><asp:TextBox ID="result_top7_1" runat="server" CssClass="form-control"></asp:TextBox></td>
                                               <td><asp:TextBox ID="result_other_1" runat="server" CssClass="form-control"></asp:TextBox></td>
                                               <td><asp:TextBox ID="result_bottom4_1" runat="server" CssClass="form-control"></asp:TextBox></td>
                                          </tr>
                                           <tr>
                                         <td><asp:TextBox ID="result_from_2" runat="server" CssClass="form-control"></asp:TextBox></td>
                                               <td><asp:TextBox ID="result_to_2" runat="server" CssClass="form-control"></asp:TextBox></td>
                                              <td><asp:TextBox ID="result_top7_2" runat="server" CssClass="form-control"></asp:TextBox></td>
                                               <td><asp:TextBox ID="result_other_2" runat="server" CssClass="form-control"></asp:TextBox></td>
                                               <td><asp:TextBox ID="result_bottom4_2" runat="server" CssClass="form-control"></asp:TextBox></td>
                                              
                                          </tr>
                                           <tr>
                                            <td><asp:TextBox ID="result_from_3" runat="server" CssClass="form-control"></asp:TextBox></td>
                                               <td><asp:TextBox ID="result_to_3" runat="server" CssClass="form-control"></asp:TextBox></td>
                                              <td><asp:TextBox ID="result_top7_3" runat="server" CssClass="form-control"></asp:TextBox></td>
                                               <td><asp:TextBox ID="result_other_3" runat="server" CssClass="form-control"></asp:TextBox></td>
                                               <td><asp:TextBox ID="result_bottom4_3" runat="server" CssClass="form-control"></asp:TextBox></td>
                                              
                                          </tr>
                                           <tr>
                                            <td><asp:TextBox ID="result_from_4" runat="server" CssClass="form-control"></asp:TextBox></td>
                                               <td><asp:TextBox ID="result_to_4" runat="server" CssClass="form-control"></asp:TextBox></td>
                                              <td><asp:TextBox ID="result_top7_4" runat="server" CssClass="form-control"></asp:TextBox></td>
                                               <td><asp:TextBox ID="result_other_4" runat="server" CssClass="form-control"></asp:TextBox></td>
                                               <td><asp:TextBox ID="result_bottom4_4" runat="server" CssClass="form-control"></asp:TextBox></td>
                                          </tr>
                                          </table>
                                     </div>
                            </div>
                            
                        </div>

                        <asp:Button CssClass="btn btn-w-m btn-primary" Text="Save" OnClick="Unnamed_Click"  runat="server" ID="save"/>
                    </div>
                    
                </div>

            </div>
        </div>
</asp:Content>
<asp:Content ID="FooterScript" ContentPlaceHolderID="ContentFooter" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            getList();
            getSectionList();
          

           

            $('#dropsection2').on('change', function () {

           
                getSectionList();
            });
        });


        function getList() {

            $('.main-data').toggleClass('sk-loading');

            var url = "<%= ResolveUrl("/admin/Content/ajax_webmethod_assessment.aspx/GetReportSectionAll") %>";
            var v = 0;
            //if (!v) { v = 0 }
            var data = { UsersRoleId: v };
            var param = JSON.stringify({ parameters: data });

            AjaxPost(url, param, function () {

            }, function (data) {

                //  console.log(data);
                var h = GenlistAll(data);
                $('#body_list').html(h);
                $('.main-data').toggleClass('sk-loading');
            });
        }

        function getSectionList() {
            $('.main-data').toggleClass('sk-loading');
            var v = $('#dropsection2').val();
            var url = "<%= ResolveUrl("/admin/Content/ajax_webmethod_assessment.aspx/GetReportSectionItemAll") %>";

             if (!v) { v = 0 }
             var data = { ResultSectionID: v };
             var param = JSON.stringify({ parameters: data });

             AjaxPost(url, param, function () {

             }, function (data) {

                 //  console.log(data);
                 var h = GenSectionlistAll(data);
                 $('#body_section_list').html(h);
                 $('.main-data').toggleClass('sk-loading');
             });
        }

        

        function GenSectionlistAll(data) {
            var ret = "";
            for (var i in data) {

                ret += '<tr>';
                //ret += '   <td><input type="checkbox" checked class="i-checks" name="input[]"></td>';
                ret += '   <td><a href="ReportContent?tab=2&subsection=' + data[i].ResultItemID + '&section=' + data[i].ResultSectionID +'">' + data[i].Code + '</a></td>';
                ret += '   <td><a href="ReportContent?tab=2&subsection=' + data[i].ResultItemID + '&section=' + data[i].ResultSectionID +'">' + data[i].Title + '</a></td>';
                ret += '   <td style="text-align:center">' + data[i].SectionTitle + '</td>';
                //ret += '   <td style="text-align:center">' + data[i].Priority + '</td>';
                //ret += '   <td>' + data[i].LastName + '</td>';
                //ret += '   <td>' + data[i].UserName + '</td>';
                var txt = 'Active';
                var bage = 'primary'
                if (!data[i].Status) { txt = 'Inactive'; bage = 'default'; }
                ret += '   <td style="text-align:center"><span class="label label-' + bage + '">' + txt + '</span></td>';
               // ret += '   <td style="text-align:center"><a href="Assessmentoptionaddedit?tab=2&subsection=' + data[i].SUCID + '"><i class="fa fa-pencil"></i> Edit </a></td>';
                ret += '   </tr >';
            }

            return ret;
        }
        function GenlistAll(data) {
            var ret = "";
            for (var i in data) {

                ret += '<tr>';
                ret += '   <td style="text-align:center"><a href="ReportContent?section=' + data[i].ResultSectionID + '">' + data[i].Code + '</a></td>';
               // ret += '   <td><input type="checkbox" checked class="i-checks" name="input[]"></td>';
                ret += '   <td><a href="ReportContent?section=' + data[i].ResultSectionID + '">' + data[i].Title + '</a></td>';
                
                ret += '   <td style="text-align:center">' + data[i].Priority + '</td>';
                //ret += '   <td>' + data[i].LastName + '</td>';
                //ret += '   <td>' + data[i].UserName + '</td>';
                var txt = 'Active';
                var bage = 'primary'
                if (!data[i].Status) { txt = 'Inactive'; bage = 'default'; }
                ret += '   <td style="text-align:center"><span class="label label-' + bage+'">' + txt + '</span></td>';
                //ret += '   <td style="text-align:center"><a href="Assessmentoptionaddedit?section=' + data[i].SCID + '"><i class="fa fa-pencil"></i> Edit </a></td>';
                ret += '   </tr >';
            }

            return ret;
        }

    </script>

   <%-- <script type="text/javascript">

        function stopPropagation(evt) {
            if (evt.stopPropagation !== undefined) {
                evt.stopPropagation();
            } else {
                evt.cancelBubble = true;
            }
        }


        function renderEditmode(d) {

            return '<input type="text" data-column="' + d.column + '" id="form-mode-' + d.column + '-' + d.id + '" class="form-control form-mode" style="display:none;width:100%" value="' + d.data + '" />';
        }

        function renderDataView(d) {
            return '<span class="form-mode_v">' + d.data + '</span>';
        }

        

        function UpdateButtonmode(table, $row) {
            var buttons_editMode = table.buttons(['.main-btn-delete', '.main-btn-edit']);
            var buttons_editAction = table.buttons(['.main-btn-cancel', '.main-btn-update']);
            //table.rows({ selected: true });
            //.find('input[type="checkbox"]');
            //var rowselected = table.rows().nodes().find('input[type="checkbox"]:checked');

            var $table = table.table().node();
            var $chkbox_checked = $('tbody input[type="checkbox"]:checked', $table);
            var $FormMode = $('tbody .form-mode:visible', $table);
            var $FormModeView = $('tbody .form-mode_v:visible', $table);

            var form_edit = $row.find(".form-mode");
            var form_view = $row.find(".form-mode_v");
            var rowChecked = $row.find('input[type="checkbox"]');

            var editmode = buttons_editMode.button().node().is(':visible');


            if ($chkbox_checked.length > 0 && editmode && $FormMode.length == 0) {

                buttons_editMode.enable();
                buttons_editAction.disable();

            } else {
                if ($FormMode.length > 0 && rowChecked.is(':checked')) {
                    form_edit.show();
                    form_view.hide();
                } else {
                    form_edit.hide();
                    form_view.show();
                }
                //buttons_editMode.disable();
                // buttons_editAction.disable();
            }


            if ($chkbox_checked.length === 0) {
                buttons_editMode.disable();
                buttons_editAction.disable();
            }
            //table.rows({ selected: true }).every(function () {
            //    var d = this.data();

            //    var row = this.node();

            //    $(row).find(".form-mode").show();
            //    $(row).find(".form-mode_v").hide();
            //    //$(row).find(".form-mode").toggle('fast');

            //    //$(this).find(".form-mode").toggle('fast');
            //    // d.counter++; // update data source for the row

            //    //this.invalidate(); // invalidate the data DataTables has cached for this row
            //});

        }


        function EditRole(o) {


            var obj = $(o).data('roleid');

            var rs = store.get('RoleSel' + obj);

           

            $("#rol-data").removeClass("col-lg-12").addClass("col-lg-8");
            $("#role-edit").show();
        }

        function closeEditRole() {
            $("#rol-data").removeClass("col-lg-8").addClass("col-lg-12");
            $("#role-edit").hide();
        }

        function saveRoleEdit() {

        }
         $(document).ready(function () {

             

             $("#input_btn_save").on('click', function (e) {
                 e.preventDefault();
                 var mainform = jQuery('form');
                 mainform.validate();
                 var ele = $(".required");
                 $.each(ele, function (index) {
                     $(this).rules('add', {
                         required: true,
                         messages: {
                             required: 'required field'
                         }
                     }
                     );
                 });



                 if (mainform.valid()) {
                     var post = $("#insert-form").find("input,textarea,select,hidden").not("#__VIEWSTATE,#__EVENTVALIDATION").serialize();
                     var url = "<%= ResolveUrl("/Application/ajax/subscriber/ajax_webmethod_subscriber1.aspx/InsertGroup") %>";
                     //{head: $('#ProcessTsForm').serialize(), detail: found_names},

                     var param = JSON.stringify({ parameters: qToJson(post) });
                     AjaxPost(url, param, null, function (data) {


                         if (data.success) {

                             toastr.success('Notification', data.msg);
                             //$('#datatab').DataTable().ajax.reload();

                             var table = $('#datatab').dataTable();
                             table.fnReloadAjax();
                             

                             $(".my-input").val("");




                             //chkbox_select_all.prop('checked', false);
                         }
                     }, function (xhr, status) {
                         //var table = $('#datatab').dataTable();
                         // var chkbox_all = $('tbody input[type="checkbox"]', table);
                         // var chkbox_select_all = $('thead input[name="select_all"]', table).get(0);
                         // $(chkbox_all).prop('checked', false);
                         // $(chkbox_select_all).prop('checked', false);
                     });
                 }

                 return false;

             });

             //$('#datatab thead th').each(function (index) {
             //    //if (index > 1 && ($('#datatab thead th').length - 1) != index) {
             //    if (index > 1 && ($('#datatab thead th').length - 1) != index) {
             //        $(this).append('&nbsp;<input type="text" class="form-control" onclick="stopPropagation(event);" />');
             //    }

             //});




             // Event listener to the two range filtering inputs to redraw on input
             $('#SGID_Filter').on('change', function () {
                 var table = $('#datatab').DataTable();
                 table.draw();
             });
             var rows_selected = [];
             var oTable = $('#datatab').DataTable({
                 processing: true,
                 serverSide: true,
                 responsive: true,
                 "searching": false,
                 //deferRender: true,
                 stateSave: false,
                 ajax: {
                     type: "POST",
                     url: "<%= ResolveUrl("/admin/Staff/ajax_webmethod_staff.aspx/DataAll") %>",
                     contentType: 'application/json; charset=utf-8',
                     data: function (d) {


                         //add custom filter 
                         var CustomSearch = {
                             Key: "SGID",
                             Value: $("#SGID_Filter").val()
                         };
                         d['CustomSearch'] = CustomSearch;

                         return JSON.stringify({ parameters: d });
                     },
                 },
                 
                 pageLength: 15,
                 paging: true,
                 lengthMenu: [15, 25, 50, 75, 100],

                 columns: [
                     {
                         data: null,
                         
                         'searchable': false,
                         'orderable': false,
                         'width': '1%',
                         'className': 'dt-body-center',
                         'render': function (data, type, full, meta) {
                             return '<input type="checkbox">';
                         }
                     },
                     {
                         data: "RowNum",
                         'orderable': false,
                         "width": "3%",
                         'className': 'dt-center',

                     },
                     {
                         data: "Title",
                         render: function (data, type, full, meta) {
                             return renderDataView({ data: data, id: full.SID, column: "Title" }) + renderEditmode({ data: data, id: full.SID, column: "Title" });
                         }


                     },
                     {
                         data: "Sstatus",
                         'orderable': false,
                         'className': 'dt-center',
                         render: function (data, type, full, meta) {
                             if (data) {
                                 return '<span class="label ">Active</span>';
                             } else {

                                 store.set('RoleSel' + full.UsersRoleId, full);
                                 return '<a href="#" class="btn btn-white btn-sm"><i class="fa fa-pencil"></i> Edit </a>';

                                 //<a href="#" onclick="EditRole(this);" data-roleid="' + full.UsersRoleId+'" ><span class="label label-primary">Click</span></a>
                             }


                         }
                     }
                     //{
                     //    data: "LastName",
                     //    render: function (data, type, full, meta) {
                     //        return renderDataView({ data: data, id: full.SID, column: "LastName" }) + renderEditmode({ data: data, id: full.SID, column: "LastName" });
                     //    }
                     //}
                     //,
                     //{
                     //    data: "Email",
                     //    render: function (data, type, full, meta) {
                     //        return renderDataView({ data: data, id: full.SID, column: "Email" }) + renderEditmode({ data: data, id: full.SID, column: "Email" });
                     //    }
                     //},
                     //{
                     //    data: "Sstatus",
                     //    'className': 'dt-center',
                     //    render: function (data, type, full, meta) {
                     //        if (data) {
                     //            return '<span class="label label-primary">Active</span>';
                     //        } else {
                     //            return '<span class="label">Inactive</span>';
                     //        }


                     //    }
                     //}

                 ],
                 'rowCallback': function (row, data, dataIndex) {
                   
                 },

                

                 "order": [2, "asc"],
                
                 


             });

             // Handle click on checkbox
             $('#datatab tbody').on('click', 'input[type="checkbox"]', function (e) {

                 //if (e.target.tagName != "BUTTON" && e.target.tagName != "INPUT") {
                 var $row = $(this).closest('tr');

                 // Get row data
                 var data = oTable.row($row).data();

                 // Get row ID
                 var rowId = data[0];

                 // Determine whether row ID is in the list of selected row IDs 
                 var index = $.inArray(rowId, rows_selected);

                 // If checkbox is checked and row ID is not in list of selected row IDs
                 if (this.checked && index === -1) {
                     rows_selected.push(rowId);

                     // Otherwise, if checkbox is not checked and row ID is in list of selected row IDs
                 } else if (!this.checked && index !== -1) {
                     rows_selected.splice(index, 1);
                 }

                 if (this.checked) {
                     $row.addClass('selected');
                 } else {
                     $row.removeClass('selected');
                 }

                 // Update state of "Select all" control
                 updateDataTableSelectAllCtrl(oTable);


                 UpdateButtonmode(oTable, $row);

                 e.stopPropagation();
                 // }

             });

             // Handle click on table cells with checkboxes
             //$('#datatab').on('click', 'tbody td, thead th:first-child', function (e) {
             //    if (e.target.tagName != "BUTTON" && e.target.tagName != "INPUT") {
             //        $(this).parent().find('input[type="checkbox"]').trigger('click');
             //    }

             //});


             // Handle click on "Select all" control
             //$('thead input[name="select_all"]', oTable.table().container()).on('click', function (e) {
             //    if (this.checked) {
             //        $('#datatab tbody input[type="checkbox"]:not(:checked)').trigger('click');
             //    } else {
             //        $('#datatab tbody input[type="checkbox"]:checked').trigger('click');
             //    }

             //    //updateDataTableSelectAllCtrl(oTable);
             //    // Prevent click event from propagating to parent
             //    e.stopPropagation();
             //});

             // Handle table draw event
             oTable.on('draw', function () {
                 // Update state of "Select all" control
                 updateDataTableSelectAllCtrl(oTable);
             });

             oTable.columns().every(function (t) {
                 if (t > 1) {
                     var that = this;

                     $('input', this.header()).on('keyup change', function () {
                         that
                             .search(this.value)
                             .draw();
                     });
                 }

             });


             //var table = $('#myTable').DataTable();
             var buttons = oTable.buttons(['.main-btn-delete', '.main-btn-cancel', '.main-btn-update', '.main-btn-edit']);
             buttons.disable();












         });

    </script>--%>

</asp:Content>