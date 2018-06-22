<%@ Page Language="C#" Inherits="HuaYimo.admin.link_add" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
     <title><%=ConfigurationManager.AppSettings["AdminTitle"].ToString() %></title>
  <link href="CSS/main_right.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div id="mainbody">
<div id="right_table">
   <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#FFFFFF" >
   <TBODY><TR>
   <TH colSpan=2 height=25>
    添加友情链接</TH></TR>

    <tr>
        <td class="list" height="23" valign="top" width="80">
            名称：</td>
        <td class="list" height="23" width="*">
            <asp:TextBox ID="tbtitle" runat="server" Width="150px" CssClass="Textbox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbtitle"
                Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td class="list" height="23" valign="top" width="80">
            地址：</td>
        <td class="list" height="23" width="*">
            <asp:TextBox ID="tburl" runat="server" Width="150px" CssClass="Textbox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tburl"
                Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>
    </tr>
    <asp:Panel ID="panEdit" runat="server">
    <tr>        
        <td class="list" height="23" valign="top" width="80">
            首页位置：</td>
        <td class="list" height="23" width="*">
        <asp:DropDownList ID="ddltype" runat="server">
        
        <asp:ListItem Text="---全部---" Value="1"></asp:ListItem>
       
        </asp:DropDownList>
            </td>
    </tr>    
    <tr>
        <td class="list" height="23" valign="top" width="80">
            排序：</td>
        <td class="list" height="23" width="*">
         <asp:TextBox ID="tbsort" runat="server" Width="150px" CssClass="Textbox" Text="0"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbsort"
                Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
    </tr>
    </asp:Panel>
    
    <tr>
        <td class="list" height="23" valign="top" width="80">
            是否显示：</td>
        <td class="list" height="23" width="*">
            <asp:RadioButtonList ID="rbFlag" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
               <asp:ListItem Selected="True" Value="1">是</asp:ListItem>
                <asp:ListItem Value="0">否</asp:ListItem>
            </asp:RadioButtonList></td>
    </tr>
    

    <tr>       
        <td class="list" height="23" width="*" colspan=2>
        <div style="margin-top:10px; margin-left:50px">
            <input type=submit value="添 加" id="Submit1" runat="server" onserverclick="Submit1_ServerClick" onclick="return Submit1_onclick()" />
            <asp:Button ID="btEdit" runat="server" Text="修 改" onclick="btEdit_Click" />
            &nbsp;
                    <input type="button" value="返 回" onclick="history.go(-1)" /></div></td>
    </tr>
</TBODY></table>
</div></div>
    </form>
</body>
</html>
