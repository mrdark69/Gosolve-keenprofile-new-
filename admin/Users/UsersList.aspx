﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="UsersList.aspx.cs" Inherits="Users_UsersList" %>
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
                            <h5>Staff List </h5>

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
                                   <strong>Pagesize:</strong> <%--<asp:DropDownList ID="dropRole" ClientIDMode="Static" runat="server" CssClass="input-sm form-control input-s-sm inline">

                                    </asp:DropDownList>--%>
                                    <asp:DropDownList ID="droppagsize" ClientIDMode="Static" Width="50px" runat="server" CssClass="input-sm form-control input-s-sm inline">
                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                             <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                          <asp:ListItem Text="30" Value="30"></asp:ListItem>
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
                                    <a href="Register"  class="btn btn-w-m btn-success">Add New Staff</a>
                                   <%-- <div class="input-group"><input type="text" placeholder="Search" class="input-sm form-control"> <span class="input-group-btn">
                                        <button type="button" class="btn btn-sm btn-primary"> Go!</button> </span></div>--%>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <table class="table table-striped">
                                    <thead>
                                    <tr>

                                        <th></th>
                                        <th>FirstName </th>
                                        <th>LastName </th>
                                        <th>UserName</th>
                                        <th>Role</th>
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
                            <div class="btn-group" id="pagination">
                                <%--<button type="button" class="btn btn-white"><i class="fa fa-chevron-left"></i></button>
                                <button class="btn btn-white">1</button>
                                <button class="btn btn-white  active">2</button>
                                <button class="btn btn-white">3</button>
                                <button class="btn btn-white">4</button>
                                <button type="button" class="btn btn-white"><i class="fa fa-chevron-right"></i> </button>--%>
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
            var pagesize = $('#droppagsize').val();
            getList(pagesize,1);

            $('#droppagsize').on('change', function () {

                var ps = $(this).val();
                getList(ps,1);
            });


           
        });


        function getList(ps,s) {

            var url = "<%= ResolveUrl("/admin/Users/ajax_webmethod_user.aspx/GetAll") %>";

            //if (!v) { v = 0 };

            //if (!s) { v = 1 };
            //var s = store.get('Paging_now');

            store.set('Paging_now', s);
            var offset = (s - 1) * ps;
            var PagingParam = { Start: offset, Length: ps};
            var data = { UsersRoleId: 0, UserCatId: 1, PagingParam: PagingParam};
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
                ret += '   <td>' + data[i].FirstName+'</td>';
                ret += '   <td>' + data[i].LastName +'</td>';
                ret += '   <td>' + data[i].UserName +'</td>';
                ret += '   <td><span class="label label-primary">' + data[i].UserRoleName +'</span></td>';
                ret += '   <td><a href="StaffEdit?s=' + data[i].UserID+'"><i class="fa fa-pencil"></i> Edit </a></td>';
                ret += '   </tr >';
            }

           
            paging(data);

            return ret;
        }

        function paging(data) {
            if (data.length > 0) {
                //store.set('Paging_now', 1);
                var totalS = data[0].TotalRows;

                var pagesize = $('#droppagsize').val();
                var s = store.get('Paging_now');
                var tp = Math.ceil(totalS / pagesize);

                if (tp > 1) {
                    $('#pagination').bootpag({
                        total: tp,          // total pages
                        page: s,            // default page
                        maxVisible: 5,     // visible pagination
                        leaps: true         // next/prev leaps through maxVisible
                    }).on("page", function (event, num) {
                        store.set('Paging_now', num);

                        var pagesize = $('#droppagsize').val();
                        getList(pagesize, num);
                        //$("#content").html("Page " + num); // or some ajax content loading...
                        //// ... after content load -> change total to 10
                        //$(this).bootpag({ total: 10, maxVisible: 10 });
                    });
                }
              
            }
        }

    </script>

</asp:Content>