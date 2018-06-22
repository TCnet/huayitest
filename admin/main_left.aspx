<%@ Page Language="C#" Inherits="HuaYimo.admin.main_left" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>左侧导航</title>
           <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="CSS/left_menu.css" type="text/css" rel="stylesheet" />
    <script src="JS/menu.js" type="text/javascript"></script>
    <script src="JS/scrollphoto.js" type="text/javascript"></script>
    <script language="javascript">
        function switchSysBar() {
            if (parent.document.getElementById('attachucp').cols == "180,10,*") {
                document.getElementById('leftbar').style.display = "";
                parent.document.getElementById('attachucp').cols = "0,10,*";
            }
            else {
                parent.document.getElementById('attachucp').cols = "180,10,*";
                document.getElementById('leftbar').style.display = "none"
            }
        }
        function load() {
            if (parent.document.getElementById('attachucp').cols == "0,10,*") {
                document.getElementById('leftbar').style.display = "";
            }
        }
    </script>
</head>

<body style="background-color: #C8E8F7; overflow-x: hidden;">

    <div id="sidebar">
        <div class="list" onclick="chengstate('01')" id="pr01">
            <div style="margin-top: 7px">用户管理</div>
        </div>
        <div class="textbg" id="item01">
            <div class="text_01"><a href="main_right.aspx" target="mainFrame">管理页面</a> │ <a href="logout.aspx" target="_parent" title="注销退出">退出</a></div>
            <div class="text_01">当前用户：<asp:Literal ID="ltName" runat="server"></asp:Literal></div>
        </div>

        <asp:Repeater runat="server" ID="rpMenu">
            <ItemTemplate>

                <div class="list" onclick="chengstate('<%#Eval("id") %>')" id="pr<%#Eval("id") %>" >
                    <div style="margin-top: 7px"><%#Eval("typename") %></div>
                </div>
                <div class="textbg" id="item<%#Eval("id") %>" style="display: none">
                    <div class="text_03"><a href="news_add.aspx?type=<%#Eval("id") %>" target="mainFrame">添加</a>│<a href="news_manage.aspx?type=<%#Eval("id") %>" target="mainFrame">管理</a></div>
                    <div class="text_03"><a href="news_audit.aspx?type=<%#Eval("id") %>" target="mainFrame" style="color: Red">待审核(<%#getAu(Convert.ToInt32(Eval("id"))) %>)</a> | <a href="news_recyle.aspx?type=<%#Eval("id") %>" target="mainFrame">回收管理</a></div>
                </div>

            </ItemTemplate>
        </asp:Repeater>

     




        <div class="list" onmouseup="chengstate('23')" id="pr23">
            <div style="margin-top: 7px">互动平台</div>
        </div>
        <div class="textbg" id="item23" style="display: none">
            <%--<div class="text_03"><a href="message_manage.aspx" target="mainFrame">局长信箱</a></div>--%>
            <div class="text_03"><a href="feedback.aspx?type=1" target="mainFrame">咨询留言</a></div>


            <%-- <div class="text_03"><a href="survey_add.aspx" target="mainFrame">网上调查</a></div>--%>
        </div>








        <div class="list" onmouseup="chengstate('08')" id="pr08">
            <div style="margin-top: 7px">其他管理</div>
        </div>

        <div class="textbg" id="item08" style="display: none">
            <asp:Repeater ID="rpIntro" runat="server">
                <ItemTemplate>
                    <div class="text_03"><a href="intro.aspx?id=<%# Eval("id") %>" target="mainFrame"><%# Eval("title") %>设置</a></div>
                </ItemTemplate>
            </asp:Repeater>
        </div>


        <div class="list" onmouseup="chengstate('26')" id="pr26">
            <div style="margin-top: 7px">基础设置</div>
        </div>
        <div class="textbg" id="item26" style="display: none">

            <div class="text_03"><a href="news_type.aspx" target="mainFrame">栏目设置管理</a></div>

            <%--<div class="text_03"><a href="feedback_type.aspx" target="mainFrame" >咨询类型设置</a></div>--%>

            <div class="text_03"><a href="webSite_set.aspx" target="mainFrame">站点设置</a> </div>
            <div class="text_03"><a href="link_add.aspx" target="mainFrame">添加友情链接</a> | <a href="link_manage.aspx" target="mainFrame">管理</a></div>

            <div class="text_03"><a href="advInfo_add.aspx" target="mainFrame">添加广告</a> | <a href="advInfo_manage.aspx" target="mainFrame">管理</a></div>

        </div>

        <div class="list" onmouseup="chengstate('20')" id="pr20">
            <div style="margin-top: 7px">系统管理</div>
        </div>
        <div class="textbg" id="item20" style="display: none">
            <div class="text_03"><a href="admin_add.aspx" target="mainFrame">管理员添加</a>│<a href="admin_manage.aspx" target="mainFrame">管理</a></div>
            <div class="text_03"><a href="admin_psw.aspx" target="mainFrame">修改密码</a></div>
            <div class="text_03"><a href="role_add.aspx" target="mainFrame">角色权限管理</a></div>
        </div>




    </div>
</body>
</html>
