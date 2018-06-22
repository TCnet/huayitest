<%@ Control Language="C#" Inherits="HuaYimo.uc.uc_leftmenu" %>
<div id="left-menu" class="col-md-2 col-sm-3 col-xs-12 m-b-lg  hidden-xs ">
    <ul class="nav left-nav">
        <asp:Repeater runat="server" ID="rpMenu">
            <ItemTemplate>
                 <li id="leftmenu_<%#Eval("id") %>"><a href="<%#geturl(Eval("id").ToString()) %>"><%#Eval("typename") %></a></li>
            </ItemTemplate>
        </asp:Repeater>       
    </ul>

</div>


<script type="text/javascript">
    $(document).ready(function () {
        var cssType = "<%=_ctype %>";

        $("ul.nav.left-nav  li.active").removeClass('active');
        $("ul.nav.left-nav  li#leftmenu_" + cssType).addClass('active');

       

    });
        </script>