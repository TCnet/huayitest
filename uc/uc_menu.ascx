<%@ Control Language="C#" Inherits="HuaYimo.uc.uc_menu" %>
<nav class="navbar navbar-default" role="navigation">
                    <div class="collapse navbar-collapse">
                        <div class="container">
                            <ul id="menu" class="nav navbar-nav navbar-left ">
                                <li id="menu_0"><a href="Default.aspx">首页</a>
                                </li>
                                <% for (int i = 0; i < dptype.Count; i++)
                                   { %>
                                <% dctype = NewsTypeService.GetChildTypeByParentIdDefault(dptype[i].id); %>
                                <% if (dctype.Count > 0)
                                   { %>
                                   <li id='menu_<%=dptype[i].id%>' class="dropdown ">
                                    <a href="news_list.aspx?type=<%=dptype[i].id %>" class="dropdown-toggle " data-toggle="dropdown"><%=dptype[i].typename %></a>

                                    <ul class="dropdown-menu">
                                        <% for(int j=0;j<dctype.Count; j++) {%>
                                          <li><a href="news_list.aspx?type=<%=dctype[j].id %>"><%=dctype[j].typename %></a></li>
                                        <%} %>
                                      
                                    </ul>

                                </li>
                                <% }else { %>
                                <li id="menu_<%=dptype[i].id%>">
                                    <a href="news_list.aspx?type=<%=dptype[i].id %>"><%=dptype[i].typename %></a>
                                </li>
                                 <% } %>
                                <% } %>
                              
                                <li  id="menu_9">
                                    <a target="_blank" href="http://m.huayitest.com">会员登录</a>
                                </li>
                                  <li  id="menu_10">
                                    <a href="feedback.aspx">联系我们</a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </nav>

<script type="text/javascript">
    $(document).ready(function () {
        var cssType = "<%=_cssType %>";
       
         $("ul#menu  li.active").removeClass('active');
         $("ul#menu  li#menu_" + cssType).addClass('active');

         var subCssType = "<%=_subCssType %>";
       
     });
        </script>