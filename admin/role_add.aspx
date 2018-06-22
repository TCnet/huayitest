<%@ Page Language="C#" Inherits="HuaYimo.admin.role_add" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
     <title><%=ConfigurationManager.AppSettings["AdminTitle"].ToString() %></title>
 <link href="CSS/main_right.css" type="text/css" rel="stylesheet"/>
 <script type="text/javascript">
function DeleteIt(del,page)
{
     if(window.confirm("警告！删除后将不可恢复！是否确定删除？"))
                {                   
                    var url=document.URL.replace("&","|");
                    document.location="role_add.aspx?del="+del+"&page="+page+"&reUrl="+url;                 
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
    <div id="mainbody">
<div id="right_table">
   <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#FFFFFF" >
   <TBODY><TR>
   <TH colSpan=2 height=25>
    角色管理</TH></TR>

    <tr>
        <td class="list" height="23" valign="top" width="80">
            角色名称：</td>
        <td class="list" height="23" width="*">
            <asp:TextBox ID="tbName" runat="server" Width="150px" CssClass="Textbox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbName"
                Display="Dynamic" ErrorMessage="角色名称不能为空！"></asp:RequiredFieldValidator></td>
    </tr>

    

    <tr>       
        <td class="list" height="23" width="*" colspan=2>
        <div style="margin-top:10px; margin-left:50px">
            <input type=submit value="添 加" id="Submit1" runat="server" onserverclick="Submit1_ServerClick" />
            <asp:Button ID="btEdit" runat="server" Text="修 改" onclick="btEdit_Click"  Visible=false/>
            &nbsp;
            <input  type="reset" value="重 置" id="btReset" runat="server"/>
                    <input type="button" value="返 回" onclick="history.go(-1)"  id="btBack" runat="server" visible=false/></div></td>
    </tr>
</TBODY></table>
<table  width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#FFFFFF">
 <TBODY>
 <tr>
            <th height="25" style="width:5%">
            <asp:CheckBox ID="chkAll" onClick="CheckAll(this.id);" runat="server" ToolTip="全选" />
                    </th>
                    <th style="width:10%">角色名称</th>
                    <th style="width:10%">级别</th>
                    <th style="width:10%">操作</th>

 </tr>
 <asp:Repeater ID="rpRole" runat="server" onitemdatabound="rpRole_ItemDataBound" >
 <ItemTemplate>
 <tr>
 <td align="center" class="list"><div align="center">&nbsp;<input type="checkbox" name="sel" value="<%# Eval("id") %>" /></div></td>
 <td align="center" class="list"><%#Eval("roleName") %></td>
 <td align="center" class="list"><%#Eval("depth") %></td>
 <td align="center" class="list">
 <a href="role_add.aspx?edit=<%#Eval("id") %>">修改</a> |
 <a href="role_rank.aspx?roleid=<%#Eval("id") %>">设置权限</a> |
<a href="javascript:DeleteIt(<%# Eval("id") %>,<%#Request["page"]==null?"0":Request["page"] %>)">删除</a>

 </td>
 </tr>
 </ItemTemplate>
 <FooterTemplate>
            <tr>
              <td height="30" colspan="8" align="center" >页次：
              <asp:Label ID="lbpagenow" runat="server" Text="Label"></asp:Label>/<asp:Label ID="lbpagetotal" runat="server" Text="Label"></asp:Label>     
               每页<asp:Label ID="lbnumber" runat="server" Text="Label"></asp:Label>条 共有记录[<asp:Label
                   ID="lbnumbertotal" runat="server" Text="Label"></asp:Label>]条 
                   <asp:HyperLink ID="lpfirst" runat="server">首页</asp:HyperLink>
                    <asp:HyperLink ID="lpprev" runat="server" CssClass="black_link">上一页</asp:HyperLink>
                    <asp:Label ID="lbGid" runat="server" Text=""></asp:Label>
                   <asp:HyperLink ID="lpnext" runat="server" CssClass="black_link"> 下一页</asp:HyperLink>
                   <asp:HyperLink ID="lplast" runat="server">末页</asp:HyperLink> 
                   </td>
            </tr>
            </FooterTemplate>
 </asp:Repeater>
 </TBODY>
 
</table>
&nbsp;&nbsp;&nbsp;<asp:Button ID="btDel" runat="server" OnClick="btDel_Click" Text="批量删除" OnClientClick="if(!confirm('警告！删除后将不可恢复！是否确定删除？')) return false;" />

</div>
</div>
    </form>
</body>
</html>

