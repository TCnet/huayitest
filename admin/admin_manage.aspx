<%@ Page Language="C#" Inherits="HuaYimo.admin.admin_manage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
     <title><%=ConfigurationManager.AppSettings["AdminTitle"].ToString() %></title>
    <link href="CSS/main_right.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript">         
            function DeleteIt(id)
            {
                if(window.confirm("警告！删除后将不可恢复！是否确定删除？"))
                {
                    document.location="admin_manage.aspx?del="+id+"&reURL="+document.URL;
                }               
            }
            function CheckAll(id) {  
              var all=document.getElementById(id);//获取到点击全选的那个复选框的id  
              var one=document.getElementsByName('sel');//获取到复选框的名称  
              //因为获得的是数组，所以要循环 为每一个checked赋值  
              for(var i=0;i<one.length;i++){  
                one[i].checked=all.checked; //直接赋值不就行了嘛  
              }  
             } 
        </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="mainbody" >
  <div id="right_table">
   <table class=tableBorder style="LINE-HEIGHT: 14pt" cellSpacing=1 cellPadding=3 align=center border=0 >
            <tr>
                    <th height="25" style="width:5%">
                                 <asp:CheckBox ID="chkAll" onClick="CheckAll(this.id)"  runat="server" ToolTip="全选" />        
                    </th>
                    <th style="width:10%">管理员</th>
                    <th style="width:10%">最后登录时间</th>
                    <th style="width:10%">登录次数</th>
                    <th style="width:15%">角色</th>                    
                    <th style="width:30%">操作</th>
                </tr>
    <asp:Repeater ID="rtAdmin" runat="server">
        <ItemTemplate>
            <tr>
            <td class="forumRow"><input type="checkbox" name="sel" value="<%# Eval("id") %>" /></td>
            <td class="forumRow">
                <%# Eval("username") %><br />
            </td>
            <td class="forumRow">
                <%# Eval("lasttime") %>
            </td>
            <td class="forumRow">
                <%# Eval("logincount") %>
            </td>
            
            <td class="forumRow">
                <%# GetRoleName(int.Parse(Eval("roleId").ToString())) %>
            </td>            
            <td class="forumRow">
                <%# GetFlag(Convert.ToBoolean(Eval("flag")),Eval("id").ToString()) %> | 
                <a href="admin_add.aspx?edit=<%# Eval("id") %>">修改</a> |              
                <a href="Login_History.aspx?id=<%# Eval("id") %>">登录历史</a> | 
                <a href="javascript:DeleteIt(<%# Eval("id") %>)">删除</a>
            </td>
        </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>
<br />
&nbsp;&nbsp;&nbsp;<asp:Button ID="btDel" runat="server" OnClick="btDel_Click" Text="批量删除" OnClientClick="if(!confirm('警告！删除后将不可恢复！是否确定删除？')) return false;" />
</div>
</div>
    </form>

</body>
</html>