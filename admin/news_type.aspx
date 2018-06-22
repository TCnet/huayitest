<%@ Page Language="C#" Inherits="HuaYimo.admin.news_type" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="CSS/main_right.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript">         
            function DeleteIt(id)
            {
                if(window.confirm("警告！删除后将不可恢复！是否确定删除？")){                   
                    var url=document.URL.replace("&","|");
                    document.location="news_type.aspx?del="+id+"&reUrl="+url;                   
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
<div id="right_table">
<form id="form1" runat="server" enctype="multipart/form-data">
   <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#FFFFFF" >
   <TBODY>
   <TR>
   <TH colSpan=2 height=25>
    栏目设置管理</TH>
    </TR>
    <TR><TD class="list" vAlign=top width=100 height=23>
        上级栏目：</TD>
  <TD class="list" width="*" height=23>
      <asp:HyperLink ID="hlBack" runat="server">[hlBack]</asp:HyperLink>
                        </TD>
    </TR>
    <TR>
    <TD class="list" vAlign=top width=80 
height=23>名称：</TD><TD class="list" 
width="*" height=23><asp:TextBox ID="tbTitle" runat="server" Width="250px" CssClass="Textbox"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbTitle"
        Display="Dynamic" ErrorMessage="名称不能为空！"></asp:RequiredFieldValidator></TD></TR>
    <tr>
        <td class="list" height="23" valign="top" width="80">
            排序：</td>
        <td class="list" height="23" width="*">
            <asp:TextBox ID="tbSord" runat="server" Width="250px" CssClass="Textbox">0</asp:TextBox>
            <asp:RangeValidator ID="RangeValidator1" runat="server" 
                ControlToValidate="tbSord" Display="Dynamic" ErrorMessage="请输入0-250之间的数值" 
                MaximumValue="250" MinimumValue="0" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
                        </td>
    </tr>
    <TR id="trIssimple" runat="server">
    <TD class="list" vAlign=top width=80 height=23>内容页或列表页：</TD>
    <TD class="list" width="*" height=23>
        <asp:RadioButtonList ID="rbIssimple" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="0" Text="列表页" Selected=True></asp:ListItem>
        <asp:ListItem Value="1" Text="内容页"></asp:ListItem>
         <asp:ListItem Value="2" Text="图片页"></asp:ListItem>
        </asp:RadioButtonList>“内容页”为一篇介绍文章，“列表页”为多篇文章列表
        </TD></TR>

    <tr>
        <td class="forumRow" height="23" valign="top" width="80">
        </td>
        <td class="forumRow" height="23" width="*">
            <input type=submit value="添 加" id="Submit1" runat="server" onserverclick="Submit1_ServerClick" />
            <input type=submit value="修 改" id="sbEdit" runat="server" onserverclick="sbEdit_ServerClick" />
                    <input type=reset value="重 填" />
                    <input type=button id="btBack" runat="server" value="返 回" onclick="history.go(-1);" />
            <input id="hdUrl" runat="server" type="hidden" /></td>
    </tr>
</TBODY></table><br />
   <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#FFFFFF" >
   <tr>
   <th>
   首页显示的四项栏目：
   </th>
   </tr>
   <TBODY>
   <TR>
   <td  align=center>
     <asp:Repeater ID="rpNewsDefault" runat="server">
     <ItemTemplate>[<%#Eval("p_id").ToString()=="0"?"<font color=green><strong>"+Eval("typename")+"</strong></font>":Eval("typename")  %>]&nbsp;&nbsp;</ItemTemplate>
     </asp:Repeater>
   </td>
   </TR>
   </TBODY>
   </table>
   
<asp:GridView ID="gvMain" runat="server" AllowPaging="True" AutoGenerateColumns="False" 
                CellPadding="2" PageSize="15" Width="100%" 
                onpageindexchanging="gvMain_PageIndexChanging">
    <Columns>
        <asp:TemplateField>
            <ItemStyle Width="4%" HorizontalAlign=Center />
            <ItemTemplate>
            <input type="checkbox" name="sel" value="<%# Eval("id") %>" />
            </ItemTemplate>
            <HeaderTemplate>
            <asp:CheckBox ID="chkAll" onClick="CheckAll(this.id);" runat="server" ToolTip="全选" />
            </HeaderTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="typename" HeaderText="名称">
            <ItemStyle Width="20%" />
        </asp:BoundField>
        <asp:BoundField DataField="sort" HeaderText="排序">
            <ItemStyle Width="6%" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="列表页或内容页">
        <ItemStyle Width="6%" />
        <ItemTemplate>
        <%#getlisttype(int.Parse(Eval("id").ToString())) %>
        </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="首页显示">
        <ItemStyle Width="6%" />
        <ItemTemplate>
        <%# Eval("isdefault").ToString() == "1" ?"<font color=green><strong>√</strong></font>":"<font color=red><strong>×</strong></font>" %>
        </ItemTemplate>
        </asp:TemplateField>
       
        <asp:TemplateField HeaderText="操作">
            <ItemStyle Width="20%" HorizontalAlign=Center />
            <ItemTemplate>
            <%#FlagNews(Eval("id").ToString(),Eval("isdefault").ToString()) %>
            <a href="news_type.aspx?id=<%# Eval("id") %>">添加下级分类</a> | <a href="news_type.aspx?edit=<%# Eval("id") %>">修改</a> | <a href="javascript:DeleteIt(<%# Eval("id") %>)">删除</a>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>    
</asp:GridView>
<asp:Button ID="btDel" runat="server" CausesValidation=false OnClick="btDel_Click" Text="批量删除" OnClientClick="if(!confirm('警告！删除后将不可恢复！是否确定删除？')) return false;" />
                </form> 
                </div>
                </div>
</body>
</html>
