<%@ Page Language="C#" Inherits="HuaYimo.admin.admin_psw" %>
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
     <table width="100%" border="0" cellpadding="3" cellspacing="1" bgcolor="#FFFFFF" >
     <TBODY>
     <TR>
     <TH colSpan=2 height=25>
    修改密码</TH></TR>
    <tr>
        <td class="list" height="23" valign="top" width="80">
            管理员名：</td>
        <td class="list" height="23" width="*">
                    <asp:TextBox ID="tbName" runat="server" Enabled="False" ReadOnly="True" Width="250px" CssClass="Textbox"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="list" height="23" valign="top" width="80">
            原来密码：</td>
        <td class="list" height="23" width="*">
                    <asp:TextBox ID="tbOp" runat="server" TextMode="Password" Width="250px" CssClass="Textbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbOp"
                        ErrorMessage="密码不能为空！"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td class="list" height="23" valign="top" width="80">
            新密码：</td>
        <td class="list" height="23" width="*">
                    <asp:TextBox ID="tbNewPass" runat="server" TextMode="Password" Width="250px" CssClass="Textbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbNewPass"
                        Display="Dynamic" ErrorMessage="密码不能为空！"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td class="list" height="23" valign="top" width="80">
                    确认新密码：</td>
        <td class="list" height="23" width="*">
                    <asp:TextBox ID="tbNewPass2" runat="server" TextMode="Password" Width="250px" CssClass="Textbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbNewPass2"
                        Display="Dynamic" ErrorMessage="密码不能为空！"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tbNewPass"
                        ControlToValidate="tbNewPass2" Display="Dynamic" ErrorMessage="密码输入不一样！"></asp:CompareValidator></td>
    </tr>
    <tr>
        <td class="list" height="23" valign="top" width="80">
        </td>
        <td class="list" height="23" width="*">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="修 改" />&nbsp; 
                    <input type=reset value="重 填" /></td>
    </tr>
</TBODY></table>
</div>
</div>
    </form>
</body>
</html>
