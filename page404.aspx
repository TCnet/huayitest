<%@ Page Title="" Language="C#" MasterPageFile="~/root.master" AutoEventWireup="true" CodeBehind="page404.aspx.cs" Inherits="HuaYimo.page404" %>
<%@ Register Src="~/uc/uc_breadcrumb.ascx" TagName="uc_breadcrumb" TagPrefix="uc_breadcrumb" %>
<%@ Register Src="~/uc/uc_menu.ascx" TagName="uc_menu" TagPrefix="uc_menu" %>
<%@ Register Src="~/uc/uc_leftmenu.ascx" TagName="uc_leftmenu" TagPrefix="uc_leftmenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="menu" runat="server">
    <uc_menu:uc_menu ID="uc_menu" runat="server" CssType=""></uc_menu:uc_menu>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
      <uc_breadcrumb:uc_breadcrumb ID="uc_breadcrumb" runat="server" Title="404"></uc_breadcrumb:uc_breadcrumb>
     <div class="container">
        <div class="row">
           
           <div id="right-content" class="col-md-10 col-sm-9 border-l col-xs-12 ">
                <section class="right-text">
                  <%=Request["e"]%>
                </section>


            </div>
        </div>
    </div>
</asp:Content>