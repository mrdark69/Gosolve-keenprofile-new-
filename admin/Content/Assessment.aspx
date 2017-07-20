<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Assessment.aspx.cs" Inherits="_Assessment" %>
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
                            <li class="active" id="li_tab1" runat="server"><a href="Assessmentoptionaddedit" id="tab1" runat="server" aria-expanded="true"> Assessment</a></li>
                           
                        </ul>
                        <div class="tab-content">
                            <div id="tab_content1" runat="server" class="tab-pane active">
                                <div class="panel-body">


                             
                              
                                             <div class="ibox float-e-margins" style="margin-bottom:0px;"  id="add_section" runat="server" visible="false">
                                                      <div class="ibox-content">
                                            <div class="form-horizontal">
                                <h4 id="headsection_pan" runat="server">Create a new Assessment</h4>
                                <hr />
                             <%--   <asp:ValidationSummary runat="server" CssClass="text-danger" />--%>
                                <asp:Label ID="lblsms" runat="server"></asp:Label>

                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="QuestionTitle" CssClass="col-md-2 control-label">Question </asp:Label>
                                    <div class="col-md-10">
                                        <asp:TextBox runat="server" ID="QuestionTitle" CssClass="form-control" />
                                        <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="QuestionTitle"
                                            CssClass="text-danger" ErrorMessage="The  field is required." />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtCode" CssClass="col-md-2 control-label">Question Code</asp:Label>
                                    <div class="col-md-10">
                                        <asp:TextBox runat="server" ID="txtCode" MaxLength="2" CssClass="form-control" />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCode" Width="100"
                                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The  field is required." />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtpri" CssClass="col-md-2 control-label">Priority</asp:Label>
                                    <div class="col-md-10">
                                        <asp:TextBox runat="server" ID="txtpri" CssClass="form-control"  Text="1"  />
                                       <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator1" ControlToValidate="txtpri" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>

                                                         <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="dropSection" CssClass="col-md-2 control-label">Section</asp:Label>
                                    <div class="col-md-10">
                                        <asp:DropDownList ID="dropSection" OnSelectedIndexChanged="dropSection_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                                   <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="dropsub" CssClass="col-md-2 control-label">Sub Section</asp:Label>
                                    <div class="col-md-5">
                                        <asp:DropDownList ID="dropsub" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                       <div class="col-md-5">
                                        <asp:DropDownList ID="dropsubrigth" placeholder="Sub Section Right" Visible="false" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                                                    </ContentTemplate>

                                                </asp:UpdatePanel>
                                   



                            <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="dropQType" CssClass="col-md-2 control-label">Question Type</asp:Label>
                                    <div class="col-md-10">
                                        <asp:DropDownList ID="dropQType" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>

                                   <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtStartRank" CssClass="col-md-2 control-label">Rank</asp:Label>
                                    <div class="col-md-5">
                                        <asp:TextBox ID="txtStartRank" placeholder="From" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                        <div class="col-md-5">
                                        <asp:TextBox ID="txtEndRank" placeholder="To"  runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="dropQType" CssClass="col-md-2 control-label">Choice</asp:Label>
                                 <div class="col-md-10">
                                     <asp:DropDownList  ID="dropChoice_ret" ClientIDMode="Static" style="display:none;" runat="server"></asp:DropDownList>
                                <input type="button" id="addchoice" class="btn btn-success btn-xs" value="Add Choice" />
                                     <div>
                                    <table class="table" id="add-row-social">
                                        <thead>
                                            <tr>
                                                <td>Question</td>
                                                <td>Priority</td>
                                                <td></td>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            
                                        </tbody>
                                    </table>
                                </div>
                                     </div>
                                
                            </div>
                                              
     
<div class="form-group">
            <asp:Label runat="server" AssociatedControlID="status" CssClass="col-md-2 control-label"> Status</asp:Label>
            <div class="col-md-10">
              <asp:RadioButtonList ID="status"  runat="server">
                  <asp:ListItem Text="Active" Selected="True" Value="True"  ></asp:ListItem>
                  <asp:ListItem Text="Inactive" Value="False"></asp:ListItem>
              </asp:RadioButtonList>
            </div>
        </div>
                                <div class="form-group">
                                    <div class="col-md-offset-2 col-md-10">
               
                                       <asp:Button runat="server" ID="Button1" OnClick="Button1_Click"  Text="Save" CssClass="btn btn-w-m btn-primary" />
                                           <asp:Button runat="server" ID="Button2" OnClick="Button2_Click" CausesValidation="false"  Text="Cancel" CssClass="btn btn-w-m  btn-default" />
                                    </div>
                                </div>
                            </div>
                                             </div>
                                            </div>
                                   

                             

                                    <div class="ibox float-e-margins">
                        <div class="ibox-title" style="border:none;">
                            <h5>Section List </h5>

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
                                   <strong>Section:</strong> <asp:DropDownList ID="dropsecs" ClientIDMode="Static" runat="server" CssClass="input-sm form-control input-s-sm inline">

                                    </asp:DropDownList>
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
                                    <asp:Button  runat="server" ID="btnAddnewSection" class="btn btn-w-m btn-success" OnClick="btnAddnewSection_Click" Text="Add New Section" />
                                   <%-- <div class="input-group"><input type="text" placeholder="Search" class="input-sm form-control"> <span class="input-group-btn">
                                        <button type="button" class="btn btn-sm btn-primary"> Go!</button> </span></div>--%>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <table class="table table-striped">
                                    <thead>
                                    <tr>

                                        <th></th>
                                      
                                        <th >Title</th>
                                         <th style="text-align:center">Code </th>
                                          <th style="text-align:center"> Priority</th>
                                        <th style="text-align:center">Status </th>

                                        <th style="text-align:center">Action</th>
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


            $("#addchoice").on('click', function () {
                var uuid = guid();

                //var dropsocial = $('#dropSocial').html();

                var chk = '<input type="checkbox" name="chk_choice" checked="checked" value="' + uuid + '" style="display:none;" />';
                //var drop = '<select id="sel_' + uuid + '" name="sel_' + uuid + '" class="form-control">' + dropsocial + '</select>'
                var txtbox1 = '<input class="form-control" type="textbox"  id="question_s_' + uuid + '" name="question_s_' + uuid + '" />'
                var txtbox = '<input class="form-control" type="textbox" value="1" id="pri_s_' + uuid + '" name="pri_s_' + uuid + '" />'
                var html = '<tr id="row_s_' + uuid + '"><td>' + chk + txtbox1 + '</td><td>' + txtbox + '</td><td><button data-idrow="' + uuid + '"  onclick="removeRow(this);" class="btn btn-warning btn-circle" type="button"><i class="fa fa-times"></i></button ></td></tr>'
                $('#add-row-social tbody').append(html);
                return false;
            });


            var option = $('#dropChoice_ret option');
            if (option.length > 0) {
                $.each(option, function () {
                    var uuid = guid();
                    var link = $(this).html();
                    //var dropsocial = $('#dropSocial').html();
                    var val = $(this).attr('value');

                    var chk = '<input type="checkbox" name="chk_social" checked="checked" value="' + uuid + '" style="display:none;" />';
                    var txtbox1 = '<input class="form-control" type="textbox"  id="question_s_' + uuid + '" name="question_s_' + uuid + '" value="' + link +'" />'
                    var txtbox = '<input class="form-control" type="textbox" value="1" id="pri_s_' + uuid + '" name="pri_s_' + uuid + '" value="' + val +'"  />'
                    var html = '<tr id="row_s_' + uuid + '"><td>' + chk + txtbox1 + '</td><td>' + txtbox + '</td><td><button data-idrow="' + uuid + '"  onclick="removeRow(this);" class="btn btn-warning btn-circle" type="button"><i class="fa fa-times"></i></button ></td></tr>'
                    $('#add-row-social tbody').append(html);


                    //$('#sel_' + uuid).val(val);
                });
            }
          
        });

        function removeRow(e) {
            var id = $(e).data('idrow');

            $("#row_s_" + id).remove(); return false;
        }
        function getList(v) {

            var url = "<%= ResolveUrl("/admin/Content/ajax_webmethod_assessment.aspx/GetAssessment") %>";

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
                ret += '   <td>' + data[i].Questions + '</td>';
                ret += '   <td style="text-align:center">' + data[i].Code + '</td>';
                ret += '   <td style="text-align:center">' + data[i].Priority + '</td>';
                //ret += '   <td>' + data[i].LastName + '</td>';
                //ret += '   <td>' + data[i].UserName + '</td>';
                var txt = 'Active';
                var bage = 'primary'
                if (!data[i].Status) { txt = 'Inactive'; bage = 'default'; }
                ret += '   <td style="text-align:center"><span class="label label-' + bage + '">' + txt + '</span></td>';
                ret += '   <td style="text-align:center"><a href="Assessmentoptionaddedit?ass=' + data[i].ASID + '"><i class="fa fa-pencil"></i> Edit </a></td>';
                ret += '   </tr >';
            }

            return ret;
        }

    </script>

  

</asp:Content>