<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Orders.aspx.cs" Inherits="Users_Orders" %>
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
                                   <%-- <label><strong>Case Issue:</strong></label> 
                                    <asp:DropDownList ID="dropcase" ClientIDMode="Static"  runat="server" Width="250px" CssClass="input-sm form-control input-s-sm inline">
                                         <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Paid account" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Free account" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Waiting for verify email" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Email verified" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="Assessment expired" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="Incomplete Profile" Value="6"></asp:ListItem>
                                      
                                    </asp:DropDownList>--%>
                                 
                                </div>

                                <div class="col-sm-6">
                                    <%--<div class="input-group"><input type="text" onkeypress="return clickButton(event,'btn_search')" id="input-search" placeholder="Search" class="input-sm form-control"> <span class="input-group-btn">
                                        <button type="button" id="btn_search" class="btn btn-sm btn-primary"> Go!</button> </span></div>--%>
                                </div>
                             
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <table class="table table-striped">
                                            <thead>
                                            <tr>

                                                <%--<th></th>--%>
                                                  <th> <a href="#" class="th_sort" data-sort="asc"  data-column="TransactionID"> TSID <i class="fa fa-sort"></i></a></th>
                                                    <th><a href="#" class="th_sort" data-sort="desc"  data-column="DateSubmit"> Date <i class="fa fa-sort"></i></a></th>
                                                <th> <a href="#" class="th_sort" data-sort="asc"  data-column="FirstName"> Name <i class="fa fa-sort"></i></a></th>
                                                <th> <a href="#" class="th_sort" data-sort="asc"  data-column="Email"> Email <i class="fa fa-sort"></i></a></th>
                                              
                                               
                                                <th><a href="#" class="th_sort" data-sort="asc"  data-column="DownloadCount">Download Count <i class="fa fa-sort"></i></a></th>
                                                
                                               
                                                <th><a href="#" class="th_sort" data-sort="asc"  data-column="Status">Status <i class="fa fa-sort"></i></a></th>
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

            //$('#btn_search').on('click', function () {
                
            //    getList();

            //    return false;
            //});

            //$('#dropcase').on('change', function () {

            //    getList();
            //    return false;
            //});


            $(".th_sort").on('click', function () {
                $(".th_sort").removeClass('action');
                // Get the current column clicked
                var thisColumn = $(this).data('column');
                var sort = $(this).data("sort");
                var newsort = toggleSort(sort);
                



                $(this).data('sort', newsort);
                $(this).addClass('action');


                getList();
                return false;

            });


            if ($('#hd_listTotal')) {
                //alert($('#hd_listTotal').val());

                $('#pagination').bootpag().on("page", function (event, num) {
                    store.set('Paging_now', num);

                    console.log(num);

                    getList();
                    //$("#content").html("Page " + num); // or some ajax content loading...
                    //// ... after content load -> change total to 10
                    //$(this).bootpag({ total: 10, maxVisible: 10 });
                });
            }

        
           
        });

        function toggleSort(sort) {
            var newsort = "";
            if (sort == "asc") {
                newsort = "desc";
            }

            if (sort == "desc") {
                newsort = "asc";
            }

            return newsort;
        }

        function getList() {

            var url = "<%= ResolveUrl("/admin/Users/ajax_webmethod_user.aspx/GetTsAll") %>";
            var ps = $('#droppagsize').val();
            var v = $('#input-search').val();
            var c = $('#dropcase').val();


            var Order = [];

            var item = {
                Column: $(".th_sort.action").data('column'),
                Dir: $(".th_sort.action").data('sort')
            };

            if ($(".th_sort.action").data('column') != null && $(".th_sort.action").data('sort') != null) {
                Order.push(item);
            }
            
          
            //if (!v) { v = 0 };

            //if (!s) { v = 1 };
            var s = store.get('Paging_now');
            if (!s) { s = 1 };
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
           //CustomSearchList.push(key1);
            
           //CustomSearchList.push(caseissue);


            store.set('Paging_now', s);
            var offset = (s - 1) * ps;
            var PagingParam = { Start: offset, Length: ps, CustomSearchList: CustomSearchList, Order: Order};
            var data = { UsersRoleId: 0, UserCatId: 1, PagingParam: PagingParam};
            var param = JSON.stringify({ parameters: data });

            AjaxPost(url, param, function () {
               
            }, function (data) {

              //  console.log(data);
                var h = GenlistAll(data);
                $('#body_list').html(h);
                var totalS = data[0].TotalRows;
                $('<input type="hidden" id="hd_listTotal" value="' + totalS + '" />').appendTo("body");
                paging(data);
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
                ret += '   <td>' + gender + ' ' + (data[i].FirstName == null ? 'XXXX' : data[i].FirstName) + ' ' + (data[i].LastName == null ? 'XXXX' : data[i].LastName) + '</td>';
                //ret += '   <td>' + (data[i].MobileNumber == null ? 'XXX-XXX-XXXX' : data[i].MobileNumber) + '</td>';
                ret += '   <td>' + data[i].Email + '</td>';
              
                ret += '   <td style="text-align:left">' + data[i].DownloadCount + '</td>';

                //ret += '   <td>' + paid + '</td>';
                ret += '   <td style="text-align:left"><span class="label label-' + bage + '">' + txt + '</span></td>';
                //ret += '   <td>' + verify +'</td>';
                //ret += '   <td><span class="label label-primary">' + data[i].UserRoleName +'</span></td>';
                ret += '   <td><a href="UserAssDetail?ts=' + data[i].TransactionID+'"><i class="fa fa-pencil"></i> view </a></td>';
                ret += '   </tr >';
            }

           
           

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
                    })
                } else {
                    $('#pagination').html('');
                }
              
            }
        }


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


    </script>

</asp:Content>