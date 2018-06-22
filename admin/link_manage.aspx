<%@ Page Language="C#" Inherits="HuaYimo.admin.link_manage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
     <title><%=ConfigurationManager.AppSettings["AdminTitle"].ToString() %></title>
    <link href="CSS/main_right.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript">         
            function DeleteIt(id,page)
            {
                if(window.confirm("警告！删除后将不可恢复！是否确定删除？"))
                {
                    document.location="link_manage.aspx?del="+id+"&page="+page+"&reURL="+document.URL;
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
    <div style="width:100%; text-align:center; font-weight:bold; font-size:16pt">
        友情链接管理
        </div>

<DIV id="search">
 <div class="search_left"></div>
 <div class="search_center"> 
    <table cellspacing="3" cellpadding="0" width="55%" align="left" border="0">
     <tbody>
       <tr>
         <td align="left" width="12%" style="padding-top:1px;">关键字：</td>
         <td align="left" width="40%"><asp:TextBox ID="tbKey" runat="server" CssClass="textbox"></asp:TextBox></td>
         <td align="left" width="28%">
         类型：
         <asp:DropDownList ID="ddlType" runat="server" CssClass="textbox">
         <asp:ListItem Text="全部" Value="all"></asp:ListItem>
        <asp:ListItem Text="---全部---" Value="1"></asp:ListItem>
       
            </asp:DropDownList>
         </td>
         <td align="left" width="20%"><asp:Button ID="btSearch" runat="server" OnClick="btSearch_Click" Text="搜 索" />
         </td>
       </tr>
     </tbody>
   </table>
   </div>
 <div style=" width:2.9%; height:28px; float:right;"><img src="images/img_search_right.gif"  /></div>
</DIV>

  <div id="right_table">
   <table class=tableBorder style="LINE-HEIGHT: 14pt" cellSpacing=1 cellPadding=3 align=center border=0 >
   <tr>
   <td colspan="7">
   <%=IsStrong("1")?"<strong>":"" %><a href="link_manage.aspx?type=1">[全部]</a><%=IsStrong("1")?"</strong>":""  %>&nbsp;&nbsp;
   
   </td>
   </tr>
            <tr>
                    <th height="25" style="width:5%">
                        <asp:CheckBox ID="chkAll" onClick="CheckAll(this.id)"  runat="server" ToolTip="全选" />         
                    </th>
                    <th style="width:15%">名称</th>
                    <th style="width:15%">地址</th>
                    <th style="width:5%">排序</th>
                    <th style="width:5%">类型</th>  
                    <th style="width:10%">是否显示</th>                        
                    <th style="width:30%">操作</th>
                </tr>
    <asp:Repeater ID="rtAdmin" runat="server" onitemdatabound="rtAdmin_ItemDataBound">
        <ItemTemplate>
            <tr>
            <td class="forumRow"><input type="checkbox" name="sel" value="<%# Eval("id") %>" /></td>
            <td class="forumRow">
                <%# Eval("title") %><br />
            </td>
            <td class="forumRow">
                <%# Eval("url") %>
            </td>
            <td class="forumRow">
                <%# Eval("sort") %>
            </td>
            
            <td class="forumRow">
               <%# gettype(Eval("type").ToString()) %>
            </td> 
            
            <td class="forumRow">
               <%# Convert.ToBoolean( Eval("flag")) == true ? "<font color=red><strong>×</strong></font>" : "<font color=green><strong>√</strong></font>"%>
            </td>           
            <td class="forumRow">
                <%# GetFlag( Convert.ToBoolean( Eval("flag")),Eval("id").ToString()) %> | 
                <a href="link_add.aspx?edit=<%# Eval("id") %>">修改</a> |              
                
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
</table>
<br />
&nbsp;&nbsp;&nbsp;<asp:Button ID="btDel" runat="server" OnClick="btDel_Click" Text="批量删除" OnClientClick="if(!confirm('警告！删除后将不可恢复！是否确定删除？')) return false;" />
</div>
</div>
    </form>

</body>
</html>