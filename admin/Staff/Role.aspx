<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Role.aspx.cs" Inherits="_Role" %>
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
   </style>
 </asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
           <div class="row">
                <div class="col-lg-12">

                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>Role List </h5>

                            <div class="ibox-tools">
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                                <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                                    <i class="fa fa-wrench"></i>
                                </a>
                                <ul class="dropdown-menu dropdown-user">
                                    <li><a href="#">Config option 1</a>
                                    </li>
                                    <li><a href="#">Config option 2</a>
                                    </li>
                                </ul>
                                <a class="close-link">
                                    <i class="fa fa-times"></i>
                                </a>
                            </div>
                        </div>
                        <div class="ibox-content">
                            <div class="row">
                                <div class="col-sm-5 m-b-xs">
                                   <%--<strong>Role:</strong>--%> <%--<asp:DropDownList ID="dropRole" ClientIDMode="Static" runat="server" CssClass="input-sm form-control input-s-sm inline">

                                    </asp:DropDownList>--%>
                                   <%-- <select class="input-sm form-control input-s-sm inline">
                                    <option value="0">Option 1</option>
                                    <option value="1">Option 2</option>
                                    <option value="2">Option 3</option>
                                    <option value="3">Option 4</option>
                                    </select>--%>
                                </div>
                                <div class="col-sm-4 m-b-xs">
                                   <%-- <div data-toggle="buttons" class="btn-group">
                                        <label class="btn btn-sm btn-white"> <input type="radio" id="option1" name="options"> Day </label>
                                        <label class="btn btn-sm btn-white active"> <input type="radio" id="option2" name="options"> Week </label>
                                        <label class="btn btn-sm btn-white"> <input type="radio" id="option3" name="options"> Month </label>
                                    </div>--%>
                                </div>
                                <div class="col-sm-3" style="text-align:right">
                                    <a href="RoleAdd"  class="btn btn-w-m btn-success">Add New Role</a>
                                   <%-- <div class="input-group"><input type="text" placeholder="Search" class="input-sm form-control"> <span class="input-group-btn">
                                        <button type="button" class="btn btn-sm btn-primary"> Go!</button> </span></div>--%>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <table class="table table-striped">
                                    <thead>
                                    <tr>

                                        <th></th>
                                        <th>Role Name </th>
                                     <th>Status </th>
                                        <th>Action</th>
                                    </tr>
                                    </thead>
                                    <tbody id="body_list">
                                   <%-- <tr>
                                        <td><input type="checkbox"  checked class="i-checks" name="input[]"></td>
                                        <td>Project<small>This is example of project</small></td>
                                        <td><span class="pie">0.52/1.561</span></td>
                                        <td>20%</td>
                                        <td>Jul 14, 2013</td>
                                        <td><a href="#"><i class="fa fa-check text-navy"></i></a></td>
                                    </tr>--%>
                                    
                                    </tbody>
                                </table>
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
            getList();

            $('#dropRole').on('change', function () {

                var v = $(this).val();
                getList(v);
            });
        });


        function getList(v) {

            var url = "<%= ResolveUrl("/admin/Staff/ajax_webmethod_staff.aspx/GetRoleAll") %>";

            if (!v) { v = 0 }
            var data = { UsersRoleId: v };
            var param = JSON.stringify({ parameters: data });

            AjaxPost(url, param, function () {

            }, function (data) {

                //  console.log(data);
                var h = GenlistAll(data);
                $('#body_list').html(h);

            });
        }


        function GenlistAll(data) {
            var ret = "";
            for (var i in data) {

                ret += '<tr>';
                ret += '   <td><input type="checkbox" checked class="i-checks" name="input[]"></td>';
                ret += '   <td>' + data[i].Title + '</td>';
                //ret += '   <td>' + data[i].LastName + '</td>';
                //ret += '   <td>' + data[i].UserName + '</td>';
                var txt = 'Active';
                var bage = 'primary'
                if (!data[i].Status) { txt = 'Inactive'; bage = 'default'; }
                ret += '   <td><span class="label label-' + bage+'">' + txt + '</span></td>';
                ret += '   <td><a href="RoleEdit?s=' + data[i].UsersRoleId + '"><i class="fa fa-pencil"></i> Edit </a></td>';
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