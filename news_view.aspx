<%@ Page Title="" Language="C#" MasterPageFile="~/root.master" AutoEventWireup="true" CodeBehind="news_view.aspx.cs" Inherits="HuaYimo.news_view" %>
<%@ Register Src="~/uc/uc_breadcrumb.ascx" TagName="uc_breadcrumb" TagPrefix="uc_breadcrumb" %>
<%@ Register Src="~/uc/uc_menu.ascx" TagName="uc_menu" TagPrefix="uc_menu" %>
<%@ Register Src="~/uc/uc_leftmenu.ascx" TagName="uc_leftmenu" TagPrefix="uc_leftmenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="menu" runat="server">
    <uc_menu:uc_menu ID="uc_menu" runat="server"></uc_menu:uc_menu>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <uc_breadcrumb:uc_breadcrumb ID="uc_breadcrumb" runat="server" ></uc_breadcrumb:uc_breadcrumb>

    <div class="container">
        <div class="row">
             <uc_leftmenu:uc_leftmenu ID="uc_leftmenu" runat="server" />
           <div id="right-content" class="col-md-10 col-sm-9 border-l col-xs-12 ">
                <section class="right-text">
                    <asp:Repeater ID="rpNews" runat="server">
                        <ItemTemplate>
                            <div class="m-b-lg title">
                                <h3><span class="main-title font-normal"><%#Eval("title") %></span></h3>
                                <span class="date"><%#Convert.ToDateTime(Eval("addtime")).ToString("MM/dd/yyyy") %></span>
                            </div>
                            <p>
                                <%# Eval("img")==null ? "" : "<img  src='" + Eval("img").ToString() + "'  />" %>
                            </p>
                            <p>
                                <%#Eval("content") %>
                            </p>
                            <p>
                                <%#Eval("upfile")==null ? "" : "<a  href='" + Eval("upfile").ToString() + "' target='_blank'>" + Eval("title") + "</a>"%>
                            </p>
                            <p class="txt_font">
                                上一篇: <%#NewsService.GetNable(int.Parse( Eval("id").ToString()),int.Parse(Eval("type").ToString()),"news_view.aspx","last","black_link") %><br>
                                下一篇: <%#NewsService.GetNable(int.Parse(Eval("id").ToString()), int.Parse(Eval("type").ToString()), "news_view.aspx", "next", "black_link")%>
                            </p>
                        </ItemTemplate>
                    </asp:Repeater>
                </section>


            </div>
        </div>
    </div>



</asp:Content>
