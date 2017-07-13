<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="StaffEdit.aspx.cs" Inherits="Staff_StaffEdit" %>
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

                    <div class="form-horizontal">
        <h4>Edit Staff</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <asp:Label ID="lblsms" runat="server"></asp:Label>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="FirsName" CssClass="col-md-2 control-label">FirsName</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="FirsName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="FirsName"
                    CssClass="text-danger" ErrorMessage="The FirsName field is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="LastName" CssClass="col-md-2 control-label">LastName</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="LastName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName"
                    CssClass="text-danger" ErrorMessage="The LastName field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-2 control-label">User name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                    CssClass="text-danger" ErrorMessage="The user name field is required." />
            </div>
        </div>
      <%--  <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" />
                <asp:RegularExpressionValidator  runat="server" CssClass="text-danger" ErrorMessage="The Email invalid format." ControlToValidate="Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="The Email field is required." />
            </div>
        </div>--%>

        <asp:Panel runat="server" ID="resetPassword" Visible="false">
        <div class="form-group" >
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" ID="pcheck"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"  ID="pcheck2"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" ID="pcheckcompare"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>

       </asp:Panel>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">User Role</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="dropRole" runat="server" CssClass="form-control">
                    
                </asp:DropDownList>
               
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                
                 <asp:Button runat="server" ID="btnReset" CausesValidation="False" OnClick="btnReset_Click" Text="Reset Password" CssClass="btn btn-w-m btn-warning" />
                <asp:Button runat="server" ID="btnSave"  OnClick="btnSave_Click" Text="Save" CssClass="btn btn-w-m btn-primary" />
            </div>
        </div>
    </div>
                </div>

            </div>
        </div>
</asp:Content>
<asp:Content ID="FooterScript" ContentPlaceHolderID="ContentFooter" runat="server">



    

</asp:Content>