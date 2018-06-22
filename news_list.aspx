<%@ Page Title="" Language="C#" MasterPageFile="~/root.master" AutoEventWireup="true" CodeBehind="news_list.aspx.cs" Inherits="HuaYimo.news_list" %>
<%@ Register Src="~/uc/uc_breadcrumb.ascx" TagName="uc_breadcrumb" TagPrefix="uc_breadcrumb" %>
<%@ Register Src="~/uc/uc_menu.ascx" TagName="uc_menu" TagPrefix="uc_menu" %>
<%@ Register Src="~/uc/uc_leftmenu.ascx" TagName="uc_leftmenu" TagPrefix="uc_leftmenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="menu" runat="server">
    <uc_menu:uc_menu ID="uc_menu" runat="server"></uc_menu:uc_menu>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <uc_breadcrumb:uc_breadcrumb ID="uc_breadcrumb" runat="server" Title=""></uc_breadcrumb:uc_breadcrumb>
    <div class="container">
        <div class="row ">
            <uc_leftmenu:uc_leftmenu ID="uc_leftmenu" runat="server" />
            <div id="right-content" class="col-md-10 col-sm-9 border-l col-xs-12 ">
               
                <% if (!issimple) %>
                <%
                   { %>

               <div class="m-b-xs m-t-xs title "  style="display: none;">
                    <i class="i i-home"></i><a href="/Default.aspx">&nbsp;首页&nbsp;</a>&nbsp;<i class="fa fa-angle-double-right"></i>&nbsp;<%=title %>
                </div>
                <div class="ullist">
                    <ul>
                        <asp:Repeater ID="rpNewslist" runat="server" OnItemDataBound="rpNewslist_ItemDataBound">
                            <ItemTemplate>
                                <li>·<%#geturl(Eval("id").ToString(),Eval("title").ToString()) %>
                                    <span class="timespan">[<%#Convert.ToDateTime(Eval("addtime")).ToString("yyyy-MM-dd") %>]
                                    </span>
                                </li>

                            </ItemTemplate>

                            <FooterTemplate>
                                <div class="divpage visibale-sm visible-lg visible-md" style="text-align: center;">
                                    页次:<asp:Label ID="lbpagenow" runat="server" Text="Label"></asp:Label>/<asp:Label ID="lbpagetotal"
                                        runat="server" Text="Label"></asp:Label>
                                    每页<asp:Label ID="lbnumber" runat="server" Text="Label"></asp:Label>条 共有记录[<asp:Label
                                        ID="lbnumbertotal" runat="server" Text="Label"></asp:Label>]条
                                <asp:HyperLink ID="lpfirst" runat="server" CssClass="black_link">首页</asp:HyperLink>
                                    <asp:HyperLink ID="lpprev" runat="server" CssClass="black_link">
                                  <i class="glyphicon glyphicon-backward"></i>
                                    </asp:HyperLink>
                                    <asp:Label ID="lbGid" runat="server" Text=""></asp:Label>
                                    <asp:HyperLink ID="lpnext" runat="server" CssClass="black_link">
                                <i class="glyphicon glyphicon-forward"></i> 
                                    </asp:HyperLink>
                                    <asp:HyperLink ID="lplast" runat="server" CssClass="black_link">末页</asp:HyperLink>
                                </div>
                                <div class="divpage visible-xs">
                                    <asp:HyperLink ID="lpfirst2" runat="server" CssClass="black_link">首页</asp:HyperLink>
                                    <asp:HyperLink ID="lpprev2" runat="server" CssClass="black_link">
                                  <i class="glyphicon glyphicon-backward"></i>
                                    </asp:HyperLink>
                                    <asp:Label ID="lbGid2" runat="server" Text=""></asp:Label>
                                    <asp:HyperLink ID="lpnext2" runat="server" CssClass="black_link">
                                <i class="glyphicon glyphicon-forward"></i> 
                                    </asp:HyperLink>
                                    <asp:HyperLink ID="lplast2" runat="server" CssClass="black_link">末页</asp:HyperLink>
                                </div>
                               

                            </FooterTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <% }
                   else
                   { %>
                <section class="right-text">
                    <asp:Repeater ID="rpsimple" runat="server">
                        <ItemTemplate>
                            <div class="m-b-lg title">
                                <h4><span class="main-title font-normal"><%#Eval("title") %></span></h4>
                                <span class="date"><%#Convert.ToDateTime(Eval("addtime")).ToString("MM/dd/yyyy") %></span>
                            </div>

                            <p>
                                <%#Eval("content") %>
                            </p>

                        </ItemTemplate>
                    </asp:Repeater>
                </section>



                <% } %>
            </div>
        </div>
    </div>






</asp:Content>
