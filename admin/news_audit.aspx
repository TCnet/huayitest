<%@ Page Language="C#" Inherits="HuaYimo.admin.news_audit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="CSS/main_right.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript">         
            function DeleteIt(id,page,type)
            {
                if(window.confirm("警告！删除后将不可恢复！是否确定删除？"))
                {                   
                    var url=document.URL.replace("&","|");
                    document.location="news_audit.aspx?del="+id+"&page="+page+"&type="+type+"&reUrl="+url;                  
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
<div id="mainbody">
   <form id="form1" runat="server">
  <div style="width:100%; text-align:center; font-weight:bold; font-size:16pt">
        待审核管理
        </div>
<div id="right_table">
    <table align="center" border="0" cellpadding="3" cellspacing="1" class="tableBorder" style="line-height: 14pt">
            <tr>
                    <th height="25" style="width:5%">
                    <asp:CheckBox ID="chkAll" onClick="CheckAll(this.id);" runat="server" ToolTip="全选" />
                    </th>
                    <th style="width:20%">标题</th>
                    <th style="width:7%">图片</th>
                    <th style="width:10%">添加时间</th>
                    <th style="width:8%">类型</th>   
                    <th style="width:10%;">状态</th>
                    <th style="width:8%">附件</th>
                    <th style="width:5%">添加者</th>
                    <th style="width:25%">操作</th>
                </tr>
    <asp:Repeater ID="rtNews" runat="server" EnableViewState="false" 
                onitemdatabound="rtNews_ItemDataBound">
        <ItemTemplate>
              <tr>
            <td class="forumRow" align=center><input type="checkbox" name="sel" value="<%# Eval("id") %>" /></td>
            <td class="forumRow">
                <%# Eval("title") %><br />
            </td>
            <td class="forumRow" align=center>
                <%# GetImg(Eval("img")) %>
            </td> 
            <td class="forumRow" align="center">
                   <%#Convert.ToDateTime( Eval("addtime")).ToString("yyyy-MM-dd") %>
            </td>            
            <td class="forumRow" align="center" >
                <%# GetTypeName(Eval("type")) %>
            </td>  
            <td class="forumRow" align="center" >
               <%#  Convert.ToBoolean( Eval("flag")) == false  ? "<font color=red><strong>×</strong></font>" : "<font color=green><strong>√</strong></font>"%>
                 <%# Convert.ToBoolean( Eval("istop")) == false ? "" : "<font color=green>(顶)</font>"%>
                 <%# Convert.ToBoolean( Eval("comm")) == false ? "" : "<font color=green>(flash)</font>"%>
            </td>
            <td class="forumRow" align=center>
                <%# GetUpFile(Eval("upfile")) %>
            </td>
            <td class="forumRow" align=center>
             <%# GetUser(Eval("adduser")) %>
            </td>     
            <td class="forumRow" align="center">                
               <a href="news_add.aspx?type=<%# Eval("type") %>&edit=<%# Eval("id") %>">查看修改</a> | 
                <%# CommNews(Eval("id").ToString(),Convert.ToBoolean(Eval("flag"))) %> | 
               <a href="javascript:DeleteIt(<%# Eval("id") %>,<%#Request["page"]==null?"0":Request["page"] %>,<%#Request["type"] %>)">删除</a>
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

&nbsp;&nbsp;
    <asp:Button ID="btAudit" runat="server" Text="审核通过" onclick="btAudit_Click" />

&nbsp;

        </div>
&nbsp;</form>
 </div>
 
</body>
</html>

