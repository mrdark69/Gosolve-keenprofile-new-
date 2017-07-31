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
       .pagination{
           margin:0;
       }
   </style>
 </asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
            <div class="row">
                <div class="col-lg-12">

                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>User List </h5>

                        </div>
                        <div class="ibox-content">
                            <div class="row">
                                <div class="col-sm-2 m-b-xs">
                                   <label><strong>Pagesize:</strong></label>
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
                                    <label><strong>Case Issue:</strong></label> 
                                    <asp:DropDownList ID="dropcase" ClientIDMode="Static"  runat="server" Width="250px" CssClass="input-sm form-control input-s-sm inline">
                                         <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Paid account" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Free account" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Waiting for verify email" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Email verified" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="Assessment expired" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="Incomplete Profile" Value="6"></asp:ListItem>
                                      
                                    </asp:DropDownList>
                                 
                                </div>

                                <div class="col-sm-6">
                                    <div class="input-group"><input type="text" onkeypress="return clickButton(event,'btn_search')" id="input-search" placeholder="Search" class="input-sm form-control"> <span class="input-group-btn">
                                        <button type="button" id="btn_search" class="btn btn-sm btn-primary"> Go!</button> </span></div>
                                </div>
                              <%--  <div class="col-sm-6" >
                                    <label><strong>Search:</strong></label> 
                                    <asp:TextBox ID="Search" style="display: inline-block;" CssClass="form-control" Width="300" ClientIDMode="Static" runat="server" placeholder="Name and Email"></asp:TextBox>
                                 
                                </div>--%>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <table class="table table-striped">
                                            <thead>
                                            <tr>

                                                <%--<th></th>--%>
                                                <th>Name </th>
                                                 <th>Phone</th>
                                                 <th>Email </th>
                                                <th>Join Date </th>
                                               
                                                <th>Paid</th>
                                                <th>Verify</th>
                                                <th>Action</th>
                                            </tr>
                                            </thead>
                                            <tbody id="body_list">
                                         
                                    
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            
                            <div class="btn-group" id="pagination">
                                <%--<button type="button" class="btn btn-white"><i class="fa fa-chevron-left"></i></button>
                                <button class="btn btn-white">1</button>
                                <button class="btn btn-white  active">2</button>
                                <button class="btn btn-white">3</button>
                                <button class="btn btn-white">4</button>
                                <button type="button" class="btn btn-white"><i class="fa fa-chevron-right"></i> </button>--%>
                            </div>
                            <div id="list-total" class="list-total" style="float:right;">

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

            $('#droppagsize').on('change', function () {
               
                getList();
                return false;
            });

            $('#btn_search').on('click', function () {
                
                getList();

                return false;
            });

            $('#dropcase').on('change', function () {

                getList();
                return false;
            });
            
           
        });

        function clickButton(e, buttonid) {
            var evt = e ? e : window.event;
            var bt = document.getElementById(buttonid);
            if (bt) {
                if (evt.keyCode == 13) {
                    bt.click();
                    return false;
                }
            }
        }
        function getList() {

            var url = "<%= ResolveUrl("/admin/Users/ajax_webmethod_user.aspx/GetAll") %>";
            var ps = $('#droppagsize').val();
            var v = $('#input-search').val();
            var c = $('#dropcase').val();
            //if (!v) { v = 0 };

            //if (!s) { v = 1 };
            var s = store.get('Paging_now');

            //add custom filter 
            var CustomSearchList = [];
           var key1 = {
                Key: "Search",
                Value: v
            };

           var caseissue = {
               Key: "caseissue",
               Value: c
           }
           CustomSearchList.push(key1);
            
           CustomSearchList.push(caseissue);


            store.set('Paging_now', s);
            var offset = (s - 1) * ps;
            var PagingParam = { Start: offset, Length: ps, CustomSearchList: CustomSearchList};
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

                var day = moment(data[i].DateSubmit).format('DD-MMM-YYYY HH:mm');
                ret += '<tr>';
                //ret += '   <td><input type="checkbox" checked class="i-checks" name="input[]"></td>';
                ret += '   <td>' + gender + ' ' + (data[i].FirstName == null ? 'XXXX' : data[i].FirstName) + ' ' + (data[i].LastName == null ? 'XXXX' : data[i].LastName) + '</td>';
                ret += '   <td>' + (data[i].MobileNumber == null ? 'XXX-XXX-XXXX' : data[i].MobileNumber) + '</td>';
                ret += '   <td>' + data[i].Email + '</td>';
                ret += '   <td>' + day + '</td>';
                ret += '   <td>' + paid + '</td>';
                ret += '   <td>' + verify +'</td>';
                //ret += '   <td><span class="label label-primary">' + data[i].UserRoleName +'</span></td>';
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
                var s = (store.get('Paging_now') == null ? 1 : store.get('Paging_now'));
                var tp = Math.ceil(totalS / pagesize);

                $('#list-total').html("Showing " + (((s - 1) * pagesize) + 1) + " to " + ((s * pagesize) > totalS ? totalS : (s * pagesize)) +" of " + totalS + " entries");

                if (tp > 1) {
                    $('#pagination').bootpag({
                        total: tp,          // total pages
                        page: s,            // default page
                        maxVisible: 5,     // visible pagination
                        leaps: true         // next/prev leaps through maxVisible
                    }).on("page", function (event, num) {
                        store.set('Paging_now', num);
                       
                        getList();
                        //$("#content").html("Page " + num); // or some ajax content loading...
                        //// ... after content load -> change total to 10
                        //$(this).bootpag({ total: 10, maxVisible: 10 });
                        });
                } else {
                    $('#pagination').html('');
                }
              
            }
        }

    </script>

</asp:Content>