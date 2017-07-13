<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.User.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
            <div class="row">
                <div class="col-lg-12">
                    <div class="text-center m-t-lg">
                        <h1>
                            Welcome in Newsletter System
                        </h1>
                       <%-- <small>
                            It is an application skeleton for a typical web app. You can use it to quickly bootstrap your webapp projects and dev environment for these projects.
                        </small>--%>

                        
    <asp:Button ID="Button1" CssClass="button" runat="server" OnClick="Button1_Click" Text="Sign Up" />
                    </div>
                </div>
            </div>
        </div>
   
</asp:Content>
