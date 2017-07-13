﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Subscriber.aspx.cs" Inherits="Subscriber" %>
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
   </style>
 </asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <div class="wrapper wrapper-content animated fadeInRight">

           
                
             <div class="row">
                <div class="col-lg-8">
                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>Subscriber Group Insert Box</h5>
                            <div class="ibox-tools">
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                               
                            </div>
                        </div>
                        <div class="ibox-content">
                            <div role="form" id="insert-form">

                                <div class="form-group col-md-12">
                                    <label for="SGID" class="control-label">Group</label>
                                
                                    <select id="SGID" name="SGID" class="form-control required my-inputs">
                                        <%= GetGroup() %>
                                    </select>
                                         <%--<input type="text" placeholder="Enter Name" id="SGID" name="SGID" 
                                           class="form-control required my-input">--%>
                                </div>
                                <div style="clear:both"></div>
                                <div class="form-group col-md-3">
                                    <label for="FirstName" class="control-label">FirstName</label>
                                
                                         <input type="text" placeholder="Enter Name" id="FirstName" name="FirstName" 
                                           class="form-control required my-input">
                                    
                                    
                                    
                                </div>
                                <div class="form-group col-md-3">
                                    <label for="LastName" class="control-label">LastName</label>
                                
                                         <input type="text" placeholder="Enter Name" id="LastName" name="LastName" 
                                           class="form-control required my-input">
                                    
                                    
                                </div>
                                 <div class="form-group col-md-3">
                                    <label for="Email" class="control-label">Email</label>
                                
                                         <input type="text" placeholder="Enter Detail" id="Email" name="Email"
                                           class="form-control required my-input">
                                 </div>
                                
                                <div class="form-group col-md-2">
                                        <label style="height:12px;display:block;"></label>
                                        <button  type="button" id="input_btn_save" class="btn btn-w-m btn-primary">Save</button>
                                        <%--<asp:Button ID="input_btn_save" runat="server" Text="Save"   CssClass="btn btn-w-m btn-primary" />--%>
                                 </div>
                                <div style="clear:both"></div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>Import Subscriber <small> Excel *.xlsx,*.csv only!! </small></h5>
                            <div class="ibox-tools">
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                                
                               
                            </div>
                        </div>
                        
                        <div class="ibox-content">
                            <div class="alert alert-danger" id="import_alert" style="display:none;">
                               <span> ไฟล์ที่ท่านเลือกไม่อนุญาติให้ใช้ !!</span> <a class="alert-link" href="#">close</a>.
                            </div>
                            <div class="text-center">
                                 <div class="form-group col-md-12">
                                    
                                
                                    <select id="SGID_import" name="SGID_import" class="form-control  my-inputs">
                                        <%= GetGroup() %>
                                    </select>
                                         <%--<input type="text" placeholder="Enter Name" id="SGID" name="SGID" 
                                           class="form-control required my-input">--%>
                                </div>
                                <div class="fileinput fileinput-new input-group" data-provides="fileinput">
                                    <div class="form-control" data-trigger="fileinput">
                                        <i class="glyphicon glyphicon-file fileinput-exists"></i>
                                    <span class="fileinput-filename"></span>
                                    </div>
                                    <span class="input-group-addon btn btn-default btn-file">
                                        <span class="fileinput-new">Select file</span>
                                        <span class="fileinput-exists">Change</span>
                                        <input type="file" id="import_now" name="import_now" multiple />
                                        <%--<asp:FileUpload ID="fileImport" runat="server" />--%>
                                    </span>
                                    <a href="#" class="input-group-addon btn btn-default fileinput-exists" data-dismiss="fileinput">Remove</a>
                                </div> 
                                <input type="button" id="btnUploadFile" class="btn btn-primary" value="Import"  />
                                <%--<asp:Button ID="btn_import" runat="server" CssClass="btn btn-primary" Text="Import" OnClick="btn_import_Click" />--%>
                            <%--<a data-toggle="modal" class="btn btn-primary" href="#modal-form">Import By Excel</a>--%>
                            </div>
                            
                    </div>
                </div>
</div>

            </div>

            <div class="row">
                <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>SubScriber Group</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                           
                        </div>
                    </div>
                    <div class="ibox-content">
                        <div class="sub-custom-filter">
                            <select id="SGID_Filter" name="SGID_Filter" class="form-control  my-inputs">
                                        <%= GetGroup() %>
                         </select>
                        </div>     
                         
                        <div class="table-responsive">

 
                    <table id="datatab" class="table table-striped table-bordered table-hover " >
                    <thead>
                    <tr>
                      <th><input name="select_all" value="1"  type="checkbox" /></th>
                       <th>No.</th>
                        <th>First Name</th>
                        <th>Last Name</th>
                         <th>Email</th>
                        <th>Status</th>
                     <%--   <th></th>--%>
                       
                    </tr>
                    </thead>
                    <tbody>

                    </tbody>

                    <tfoot>
                    <tr>
                        <th></th>
                       <th>No.</th>
                          <th>First Name</th>
                        <th>Last Name</th>
                         <th>Email</th>
                        <th>Status</th>
                     <%--   <th></th>--%>
                    </tr>
                    </tfoot>
                    </table>
                        </div>

                        

                    </div>
                </div>
            </div>
            </div>
   
           

    </div>

     <div class="modal inmodal" id="myModal" tabindex="-1" role="dialog" aria-hidden="true">
                                <div class="modal-dialog">
                                <div class="modal-content ibox-content animated bounceInRight">
                                    
                                    <div class="sk-spinner sk-spinner-wave">
                                       
                                       <p class="custom_progress_percentage"><span id="progress">0</span>%</p> <p style="clear:both"></p>
                                   
                                        <div class="sk-rect1"></div>
                                        <div class="sk-rect2"></div>
                                        <div class="sk-rect3"></div>
                                        <div class="sk-rect4"></div>
                                        <div class="sk-rect5"></div>
                                    </div>
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                            <i class="fa fa-laptop modal-icon"></i>
                                            <h4 class="modal-title">Notofication</h4>
                                            <small class="font-bold">การ import Subscriber</small>
                                        </div>
                                        <div class="modal-body">
                                            <p><strong>ท่านมีจำนวนการ import ทั้งหมด : </strong> <span id="total_import"></span></p>

                                            <p>ดำเนินการต่อ หรือไม่</p>
                                                   <%-- <div class="form-group"><label>Sample Input</label> <input type="email" placeholder="Enter your email" class="form-control"></div>--%>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-white" data-dismiss="modal">Close</button>
                                            <button type="button" class="btn btn-primary"  onclick="uploadnow(this);">ดำเนินการต่อ</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
</asp:Content>

<asp:Content ID="FooterScript" ContentPlaceHolderID="ContentFooter" runat="server">
     <script type="text/javascript">

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


         function uploadnow(e) {
             
             var url = "<%= ResolveUrl("/Application/ajax/subscriber/ajax_webmethod_subscriber1.aspx/UploadNow") %>";

             var data = { Key: $(e).data('key'), Total: $(e).data('total'), Group: $('#SGID_import').val() };
             var param = JSON.stringify({ parameters: data });
             AjaxPost(url, param, function () {
                 $('#myModal').find('.ibox-content').addClass('sk-loading');
             }, function (data) {


                 if (data.success) {
                     CheckImportProgress();
                     //$('#myModal').find('.ibox-content').removeClass('sk-loading');
                     //$('#myModal').modal('hide');
                 }
             });

             return false;
         }


         function CheckImportProgress() {

                     var url = "<%= ResolveUrl("/Application/ajax/subscriber/ajax_webmethod_subscriber1.aspx/CheckStatusImport") %>";

                     var data = null;
                     var param = JSON.stringify({ parameters: data });
                     AjaxPost(url, param, null, function (data) {


                         if (data.success) {
                             $('#progress').html(data.PerCentCompleted);

                             if (data.PerCentCompleted < 100) {
                                 setTimeout('CheckImportProgress()', 2000);
                             } else {
                                 var table = $('#datatab').dataTable();
                                 table.fnReloadAjax();

                                 setTimeout(function () {
                                     $('#myModal').find('.ibox-content').removeClass('sk-loading');

                                     $('<div class="alert alert-success">Import เรียบร้อยแล้ว กรุณา กดปุ่ม Close เพื่อปิดหน้าต่างนี้</div>').prependTo(".modal-content");
                                 }, 3000);
                         
                         
                             }
                         }
                     });

             
           
         }


         //$.fn.dataTable.ext.search.push(
         //    function (settings, data, dataIndex) {
         //        var min = parseInt($('#min').val(), 10);
         //        var max = parseInt($('#max').val(), 10);
         //        var age = parseFloat(data[3]) || 0; // use data for the age column

         //        if ((isNaN(min) && isNaN(max)) ||
         //            (isNaN(min) && age <= max) ||
         //            (min <= age && isNaN(max)) ||
         //            (min <= age && age <= max)) {
         //            return true;
         //        }
         //        return false;
         //    }
         //);



         $(document).ready(function () {


             $('#btnUploadFile').on('click',function (e) {

                 var file = $("#import_now").get(0).files[0];


                 if (file == null) {
                     swal({
                         title: "Please Select file",
                         text: "กรุณาเลือก ไฟล์ที่ท่านต้องการ Import"
                     });
                 } else {
                     // Make sure `file.name` matches our extensions criteria
                     if (!/\.(csv|xls|xlsx)$/i.test(file.name)) {

                         $('#import_alert').show();
                         //  return alert(file.name + " is not an image");
                     } else {
                         $('#import_alert').hide();
                         var formData = new FormData();
                         formData.append("FileUpload", file);
                         //var r = new FileReader();
                         //r.onload = function () {
                            // var binimage = r.result;
                             $.ajax({
                                 type: "POST",
                                 //contentType: "application/json; charset=utf-8",
                                 url: '<%= ResolveUrl("/Application/ajax/subscriber/ajax_import_sub.aspx") %>',
                                 data: formData , //"{ 'Based64BinaryString' :'" + binimage + "'}"
                                 dataType: "json",
                                 contentType: false,
                                 processData: false,
                             success: function (data) {
                                 if (data.success) {
                                     $('#total_import').html(data.Totalrecord);
                                     $('#myModal').find('button').attr('data-key', data.KeyID);
                                     $('#myModal').find('button').attr('data-total', data.Totalrecord);
                                     $('#myModal').modal({
                                         backdrop: 'static',
                                         keyboard: false
                                     });
                                     $('#myModal').modal('show');
                                     // alert(data.msg);
                                 } else {
                                     swal({
                                         title: "Something Wrong",
                                         text: data.msg
                                     });

                                     console.log(data.msg);
                                 }
                             },
                             error: function (result) {
                                 alert(result.d);
                             }
                         });


                     }
                    // r.readAsDataURL(file);
                 }
                 //}
                
                   

                 
             });
         


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
                             //table
                             //    .clear()
                             //    .draw();
                             //$('#datatab').DataTable().draw();
                             //oTable.draw();

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

             $('#datatab thead th').each(function (index) {
                 if (index > 1 && ($('#datatab thead th').length -1) != index) {
                     $(this).append('&nbsp;<input type="text" class="form-control" onclick="stopPropagation(event);" />');
                 }
                 
             });


             

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
                 //deferRender: true,
                 stateSave: false,
                ajax: {
                     type: "POST",
                     url: "<%= ResolveUrl("/Application/ajax/subscriber/ajax_webmethod_subscriber1.aspx/DataAll") %>",
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
                 //"dom": 'frtiS',
                 //"scrollY": 500,
                 //"scrollX": true,
                 //"scrollCollapse": true,
                 //"scroller": {
                 //    loadingIndicator: false
                 //},
                pageLength:15,
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
                        data: "FirstName",
                        render: function (data, type, full, meta) {
                            return renderDataView({ data: data, id: full.SID, column: "FirstName" }) + renderEditmode({ data: data, id: full.SID, column: "FirstName"});
                        }
                        

                    },
                    {
                        data: "LastName",
                         render: function (data, type, full, meta) {
                             return renderDataView({ data: data, id: full.SID, column: "LastName" }) + renderEditmode({ data: data, id: full.SID, column: "LastName" });
                        }
                    }
                    ,
                    {
                        data: "Email",
                        render: function (data, type, full, meta) {
                            return renderDataView({ data: data, id: full.SID, column: "Email" }) + renderEditmode({ data: data, id: full.SID, column: "Email" });
                        }
                    },
                     {
                         data: "Sstatus",
                         'className': 'dt-center',
                         render: function (data, type, full, meta) {
                             if (data) {
                                 return '<span class="label label-primary">Active</span>';
                             } else {
                                 return '<span class="label">Inactive</span>';
                             }

                             
                         }
                    }

                ],
                'rowCallback': function (row, data, dataIndex) {
                    // Get row ID
                    //var rowId = data[0];

                    //// If row ID is in the list of selected row IDs
                    //if ($.inArray(rowId, rows_selected) !== -1) {
                    //    $(row).find('input[type="checkbox"]').prop('checked', true);
                    //    $(row).addClass('selected');
                    //}
                },
               
                //select: {
                //    style: "multi",
                //    className: 'selected'
                //},
                
                "order": [2, "asc"],
                dom: 'lBfrtip',
                buttons: [
                    {
                        text: 'Edit',
                        className: 'main-btn-edit',
                        action: function (e, dt, node, config) {
        
                            var rows = oTable.rows().nodes();
                            $.each(rows, function () {

                                var check = $(this).find('input[type="checkbox"]');
                                if (check.is(':checked')) {
                                    $(this).find(".form-mode").show();
                                    $(this).find(".form-mode_v").hide();
                                }
                            });
                           
                            var buttons_1 = oTable.buttons(['.main-btn-delete', '.main-btn-edit']);
                            var buttons_2 = oTable.buttons(['.main-btn-cancel', '.main-btn-update']);
                            buttons_1.disable();
                            buttons_2.enable();
                           
                           
                        }
                    },
                    {
                        text: 'Bin',
                        className: 'main-btn-delete',
                        action: function (e, dt, node, config) {


                            swal({
                                title: "Are you sure?",
                                text: "You will not be able to recover this record!",
                                type: "warning",
                                showCancelButton: true,
                                confirmButtonColor: "#DD6B55",
                                confirmButtonText: "Yes, delete it!",
                                closeOnConfirm: false
                            }, function () {


                                post = [];
                                oTable.rows().every(function () {
                                    var d = this.data();

                                    var row = this.node();

                                    var check = $(row).find('input[type="checkbox"]');
                                    if (check.is(':checked')) {
                                        post.push(d);
                                    }
                                });


                                var url = "<%= ResolveUrl("/Application/ajax/subscriber/ajax_webmethod_subscriber1.aspx/Delete") %>";
                            var param = JSON.stringify({ parameters: post });
                            AjaxPost(url, param, null, function (data) {
                                if (data.success) {

                                    toastr.success('Notification', data.msg);
                                    //oTable.draw();
                                    var table = $('#datatab').dataTable();
                                    table.fnReloadAjax();


                                }

                            });

                            swal.close();
                               
                            });





                           


                            //$('#my_confirm').modal()
                            //    .one('click', '#my_modal_action', function (e) {
                                   


                            //        $("#my_confirm").modal('hide');
                            //        e.preventDefault();
                                   
                            //    });
                           
                        }
                    }
                    ,
                    {
                        text: 'Cancel',
                        className: 'main-btn-cancel',
                        action: function (e, dt, node, config) {
                            


                            var rows = oTable.rows().nodes();
                            $.each(rows, function () {

                                var check = $(this).find('input[type="checkbox"]');
                               // if (check.is(':checked')) {
                                    $(this).find(".form-mode").hide();
                                    $(this).find(".form-mode_v").show();
                                //}
                            });
                            var buttons_1 = oTable.buttons(['.main-btn-delete', '.main-btn-edit']);
                            var buttons_2 = oTable.buttons(['.main-btn-cancel', '.main-btn-update']);
                            buttons_2.disable();
                            buttons_1.enable();
                        }
                    }
                    ,
                    {
                        text: 'Update',
                        className: 'main-btn-update',
                        action: function (e, dt, node, config) {
                            post = [];
                            oTable.rows().every(function () {
                                var d = this.data();

                                var row = this.node();

                              var editmode =  $(row).find(".form-mode");
                              var viewmode =  $(row).find(".form-mode_v");
                                var check = $(row).find('input[type="checkbox"]');
                                if (check.is(':checked')) {

                                    $.each(editmode, function () {
                                        var col = $(this).data('column');
                                        var id = d.SID;

                                        var v = $("#form-mode-" + col + "-" + id).val();
                                        d[col] = v;
                                    });


                                    post.push(d);
                                }

                            });


                            var url = "<%= ResolveUrl("/Application/ajax/subscriber/ajax_webmethod_subscriber1.aspx/Update") %>";
                            var param = JSON.stringify({ parameters: post });
                            AjaxPost(url, param, null, function (data) {


                                if (data.success) {

                                    toastr.success('Notification', data.msg);
                                    //oTable.draw();
                                    var table = $('#datatab').dataTable();
                                    table.fnReloadAjax();

                                    
                                    var buttons_4 = oTable.buttons(['.main-btn-cancel', '.main-btn-update']);
                                    
                                    buttons_4.disable();


                                }

                            });
                        }
                    }

                ]
                

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
             $('#datatab').on('click', 'tbody td, thead th:first-child', function (e) {
                 if (e.target.tagName != "BUTTON" && e.target.tagName != "INPUT") {
                     $(this).parent().find('input[type="checkbox"]').trigger('click');
                 }
                
             });


             // Handle click on "Select all" control
             $('thead input[name="select_all"]', oTable.table().container()).on('click', function (e) {
                 if (this.checked) {
                     $('#datatab tbody input[type="checkbox"]:not(:checked)').trigger('click');
                 } else {
                     $('#datatab tbody input[type="checkbox"]:checked').trigger('click');
                 }

                 //updateDataTableSelectAllCtrl(oTable);
                 // Prevent click event from propagating to parent
                 e.stopPropagation();
             });

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
             var buttons = oTable.buttons(['.main-btn-delete', '.main-btn-cancel', '.main-btn-update','.main-btn-edit']);
             buttons.disable();

            






            
         
           

        });

    </script>
 </asp:Content>
