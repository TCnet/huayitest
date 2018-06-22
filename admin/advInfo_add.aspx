<%@ Page Language="C#" Inherits="HuaYimo.admin.advInfo_add" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
     <title><%=ConfigurationManager.AppSettings["AdminTitle"].ToString() %></title>
  <link href="CSS/main_right.css" type="text/css" rel="stylesheet"/>

</head>
<body>
<script language="JavaScript" type="text/javascript">
function SetUrl(strFileName)
{
    document.form1.tbimgUrl.value=strFileName;             
}function CheckForm()
{

  return true;
}
</script>
    <form id="form1" runat="server">
    <div id="mainbody">
<div id="right_table">
   <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#FFFFFF" >
   <TBODY><TR>
   <TH colSpan=2 height=25>
    添加广告</TH></TR>

    <tr>
        <td class="list" height="23" valign="top" width="80">
            标题：</td>
        <td class="list" height="23" width="*">
            <asp:TextBox ID="tbtitle" runat="server" Width="450px" CssClass="Textbox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbtitle"
                Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>
    </tr>
    
    <tr>
        <td class="list" height="23" valign="top" width="80">
            图片地址：</td>
        <td class="list" height="23" width="*">
            <asp:TextBox ID="tbimgUrl" runat="server" Width="450px" CssClass="Textbox" ></asp:TextBox>
            <input id="btnBrowse" name="button" onclick="window.open('../FCKeditor/editor/filemanager/browser/default/browser.html?Type=Image&Connector=connectors/aspx/connector.aspx', '', 'toolbar=no,status=no,resizable=yes,dependent=yes,width=716,height=537');"
                                                                            type="button" value="浏览服务器" />
           </td>
    </tr>
    <tr>
        <td class="list" height="23" valign="top" width="80">
            图片链接：</td>
        <td class="list" height="23" width="*">
            <asp:TextBox ID="tbimgLink" runat="server" Width="450px" CssClass="Textbox"></asp:TextBox>
            </td>
    </tr>
     <tr>
        <td class="list" height="23" valign="top" width="80">
            宽度：</td>
        <td class="list" height="23" width="*">
            <asp:TextBox ID="tbFlyImageWidth" runat="server" Width="100px" CssClass="Textbox"></asp:TextBox>
            </td>
    </tr>
     <tr>
        <td class="list" height="23" valign="top" width="80">
            高度：</td>
        <td class="list" height="23" width="*">
            <asp:TextBox ID="tbFlyImageHeight" runat="server" Width="100px" CssClass="Textbox"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td class="list" height="23" valign="top" width="80">
            添加时间：</td>
        <td class="list" height="23" width="*">
            <asp:TextBox ID="tbAddTime" runat="server" Width="150px" CssClass="Textbox"></asp:TextBox></td>
    </tr>
    
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
        <td class="forumRow" height="23" width="*">
            <input type=submit value="添 加" id="Submit1" runat="server" onserverclick="Submit1_ServerClick" />
            <input type=submit value="修 改" id="sbEdit" runat="server" onserverclick="sbEdit_ServerClick" />
                    <input type=reset value="重 填" />
                    <input type=button id="btBack" runat="server" value="返 回" onclick="history.go(-1);" />
            <input id="hdUrl" runat="server" type="hidden" /></td>
    </tr>
</TBODY>
                    </table></div>
</div>
    </form>
</body>
</html>