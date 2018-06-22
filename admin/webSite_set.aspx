<%@ Page Language="C#" Inherits="HuaYimo.admin.webSite_set" validateRequest="false"  %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>站点设置</title>
    <link href="CSS/main_right.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript" src="/ckeditor/ckeditor.js"></script>
    <script type="text/javascript">
    CKEDITOR.replace('TextArea1');  
    CKEDITOR.replace('tbContent');
</script>
</head>
<body>
    <div id="mainbody">
        <div id="right_table">
            <form id="form1" runat="server" enctype="multipart/form-data">
                <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#FFFFFF">
                    <tbody>
                        <tr>
                            <th colspan="4" height="25">站点设置</th>
                        </tr>


                        <tr>
                            <td class="list" valign="top" width="80"
                                height="23">公司简称：</td>
                            <td class="list"
                                width="*" colspan="3">
                                <asp:TextBox ID="tsName" runat="server" Width="250px" CssClass="Textbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="list" height="23" valign="top" width="100">站点标题：</td>
                            <td class="list" height="23" width="*" colspan="3">
                                <asp:TextBox ID="tsTitle" runat="server" Width="650px" CssClass="Textbox"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="list" height="23" valign="top" width="100">站点URL：</td>
                            <td class="list" height="23" width="*" colspan="3">
                                <asp:TextBox ID="tsSiteUrl" runat="server" Width="650px" CssClass="Textbox"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="list" height="23" valign="top" width="100">站点Logo地址：</td>
                            <td class="list" height="23" width="*" colspan="3">
                                <asp:TextBox ID="tsSiteLogo" runat="server" Width="650px" CssClass="Textbox"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="list" height="23" valign="top" width="100">办公地址：</td>
                            <td class="list" height="23" width="*">
                                <asp:TextBox ID="tsAddress" runat="server" Width="250px" CssClass="Textbox"></asp:TextBox></td>
                            <td class="list" height="23" valign="top" width="100">传真：</td>
                            <td class="list" height="23" width="*">
                                <asp:TextBox ID="tsFax" runat="server" Width="250px" CssClass="Textbox"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="list" height="23" valign="top" width="100">电话：</td>
                            <td class="list" height="23" width="*">
                                <asp:TextBox ID="tsTel" runat="server" Width="250px" CssClass="Textbox"></asp:TextBox></td>
                            <td class="list" height="23" valign="top" width="100">手机：</td>
                            <td class="list" height="23" width="*">
                                <asp:TextBox ID="tsPhone" runat="server" Width="250px" CssClass="Textbox"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="list" height="23" valign="top" width="100">微信：</td>
                            <td class="list" height="23" width="*">
                                <asp:TextBox ID="tsWeiXin" runat="server" Width="250px" CssClass="Textbox"></asp:TextBox></td>
                            <td class="list" height="23" valign="top" width="100">QQ ：</td>
                            <td class="list" height="23" width="*">
                                <asp:TextBox ID="tsQQ" runat="server" Width="250px" CssClass="Textbox"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="list" valign="top" width="80" height="23">站点版权：</td>
                            <td class="list" width="*" colspan="3">
                               
                                    <asp:TextBox ID="tbContent" runat="server" TextMode="MultiLine" class="ckeditor"></asp:TextBox>
                              
                            </td>
                        </tr>
                        <tr>
                            <td class="list" height="23" valign="top" width="100">站点描述：</td>
                            <td class="list" height="23" width="*" colspan="3">
                                <asp:TextBox ID="tsDescription" runat="server" Width="80%" CssClass="Textbox" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="list" height="23" valign="top" width="100">站点关键字：</td>
                            <td class="list" height="23" width="*" colspan="3">
                                <asp:TextBox ID="tsKeywords" runat="server" Width="80%" CssClass="Textbox" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="list" height="23" valign="top" width="100">站点计数：</td>
                            <td class="list" height="23" width="*" colspan="3">
                                <asp:TextBox ID="tbsCount" runat="server" Width="250px" CssClass="Textbox"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="rev1" runat="server" ErrorMessage="请输入数字！" Display="Dynamic" ControlToValidate="tbsCount" SetFocusOnError="true" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>


                        <tr>
                            <td class="forumRow" height="23" valign="top" width="100"></td>
                            <td class="forumRow" height="23" width="*" colspan="3">
                                <asp:Button ID="btSub" runat="server" Text="提 交" OnClick="btSub_Click" /></td>
                        </tr>
                    </tbody>
                </table>
            </form>
                </div>
              </div>
    </body>
</html>