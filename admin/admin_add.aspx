<%@ Page Language="C#" Inherits="HuaYimo.admin.admin_add" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%=ConfigurationManager.AppSettings["AdminTitle"].ToString() %></title>
    <link href="CSS/main_right.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div id="mainbody">
        <div id="right_table">
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#FFFFFF">
                <tbody>
                    <tr>
                        <th colspan="2" height="25">
                            添加管理员
                        </th>
                    </tr>
                    <tr>
                        <td class="list" height="23" valign="top" width="80">
                            请选择角色：
                        </td>
                        <td class="list" height="23" width="*">
                            <asp:DropDownList ID="ddlrole" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="list" height="23" valign="top" width="80">
                            管理员名：
                        </td>
                        <td class="list" height="23" width="*">
                            <asp:TextBox ID="tbName" runat="server" Width="150px" CssClass="Textbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbName"
                                Display="Dynamic" ErrorMessage="管理员名不能为空！"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="list" height="23" valign="top" width="80">
                            真实姓名：
                        </td>
                        <td class="list" height="23" width="*">
                            <asp:TextBox ID="tbTruename" runat="server" Width="150px" CssClass="Textbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbTruename"
                                Display="Dynamic" ErrorMessage="姓名不能为空！"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <asp:Panel ID="panEdit" runat="server">
                        <tr>
                            <td class="list" height="23" valign="top" width="80">
                                密码：
                            </td>
                            <td class="list" height="23" width="*">
                                <asp:TextBox ID="tbPass" runat="server" TextMode="Password" Width="150px" CssClass="Textbox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbPass"
                                    Display="Dynamic" ErrorMessage="密码不能为空！"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="list" height="23" valign="top" width="80">
                                重复密码：
                            </td>
                            <td class="list" height="23" width="*">
                                <asp:TextBox ID="tbPass2" runat="server" TextMode="Password" Width="150px" CssClass="Textbox"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tbPass"
                                    ControlToValidate="tbPass2" Display="Dynamic" ErrorMessage="两次密码不一样！"></asp:CompareValidator>
                            </td>
                        </tr>
                    </asp:Panel>
                    <asp:Panel ID="panReset" runat="server">
                        <tr>
                            <td class="list" height="23" valign="top" width="80">
                                重设密码：
                            </td>
                            <td class="list" height="23" width="*">
                                <asp:TextBox ID="tbRestPass" runat="server" TextMode="Password" Width="150px" CssClass="Textbox"></asp:TextBox>
                                <font color="red">如果重设密码请在此输入,原来的密码将被覆盖!</font>
                            </td>
                        </tr>
                    </asp:Panel>
                    <tr>
                        <td class="list" height="23" valign="top" width="80">
                            是否激活：
                        </td>
                        <td class="list" height="23" width="*">
                            <asp:RadioButtonList ID="rbFlag" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                <asp:ListItem Selected="True" Value="1">激活</asp:ListItem>
                                <asp:ListItem Value="0">不激活</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="list" height="23" width="*" colspan="2">
                            <div style="margin-top: 10px; margin-left: 50px">
                                <input type="submit" value="添 加" id="Submit1" runat="server" onserverclick="Submit1_ServerClick"
                                    onclick="return Submit1_onclick()" />
                                <asp:Button ID="btEdit" runat="server" Text="修 改" OnClick="btEdit_Click" />
                                &nbsp;
                                <input type="button" value="返 回" onclick="history.go(-1)" /></div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
