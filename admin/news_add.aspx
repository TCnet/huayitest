<%@ Page Language="C#" Inherits="HuaYimo.admin.news_add" validateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="CSS/main_right.css" type="text/css" rel="stylesheet" />
            <script type="text/javascript" src="/ckeditor/ckeditor.js"></script>
    <script type="text/javascript">
        function getpldown(id) {
            if (document.getElementById(id).value == "27" || document.getElementById(id).value == "87") {

                document.getElementById("trdownload1").style.display = "inline";
                document.getElementById("trdownload2").style.display = "inline";
            }
            else {
                document.getElementById("trdownload1").style.display = "none";
                document.getElementById("trdownload2").style.display = "none";
            }

        }
    </script>
</head>
<body>
    <div id="mainbody">
        <div id="right_table">
            <form id="form1" runat="server" enctype="multipart/form-data">
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#FFFFFF">
                <tbody>
                    <tr>
                        <th colspan="2" height="25">
                            添加<asp:Label ID="lbTitle" runat="server"></asp:Label>
                        </th>
                    </tr>
                    <tr>
                        <td class="list" valign="top" width="100" height="23">
                            频道：
                        </td>
                        <td class="list" width="*" height="23">
                            <asp:DropDownList ID="ddlptype" runat="server" CssClass="Textbox" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlptype_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="ddlptype"
                                Display="Dynamic" ErrorMessage="请选择分类" MaximumValue="99999" MinimumValue="1"
                                SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="list" valign="top" width="100" height="23">
                            栏目：
                        </td>
                        <td class="list" width="*" height="23">
                            <asp:DropDownList ID="ddlType" runat="server" CssClass="Textbox" onchange="getpldown(this.id)">
                            </asp:DropDownList>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="ddlType"
                                Display="Dynamic" ErrorMessage="请选择分类" MaximumValue="99999" MinimumValue="1"
                                SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="list" valign="top" width="80" height="23">
                            标题：
                        </td>
                        <td class="list" width="*" height="23">
                            <asp:TextBox ID="tbTitle" runat="server" Width="250px" CssClass="Textbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbTitle"
                                Display="Dynamic" ErrorMessage="标题不能为空！"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="list" valign="top" width="80" height="23">
                            副标题：
                        </td>
                        <td class="list" width="*" height="23">
                            <asp:TextBox ID="tbTitle2" runat="server" Width="250px" CssClass="Textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="list" height="23" valign="top" width="80">
                            作者：
                        </td>
                        <td class="list" height="23" width="*">
                            <asp:TextBox ID="tbAuthor" runat="server" Width="250px" CssClass="Textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="list" height="23" valign="top" width="80">
                            来源：
                        </td>
                        <td class="list" height="23" width="*">
                            <asp:TextBox ID="tbSource" runat="server" Width="250px" CssClass="Textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="list" valign="top" width="80" height="23">
                            内容：
                        </td>
                        <td class="list" width="*" height="23">
                         
                              <asp:TextBox ID="txtFull" runat="server" TextMode="MultiLine" class="ckeditor"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="list" height="23" valign="top" width="80">
                            首页图片：
                        </td>
                        <td class="list" height="23" width="*">
                             <asp:FileUpload ID="upFile" runat="server" Width="242px" CssClass="Textbox" /><br />
                            <asp:Image ID="Image1" runat="server" Height="100px" Visible="False" />
                             <asp:Button ID="btDelImg" runat="server" Text="删除图片" Visible="false" OnClick="btDelImg_Click" />
                           
                           
                        </td>
                    </tr>
                    <tr>
                        <td class="list" height="23" valign="top" width="80">
                            附件：
                        </td>
                        <td class="list" height="23" width="*">
                            <asp:FileUpload ID="upFile1" runat="server" Width="242px" CssClass="Textbox" /><br />
                            <asp:Button ID="btDelFile" runat="server" Text="删除已传附件" Visible="false" OnClick="btDelFile_Click" />
                            <asp:TextBox ID="tbfile" runat="server" Visible="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="trdownload1" runat="server" style="display: none">
                        <td class="list" height="23" valign="top" width="80">
                            下载连接：
                        </td>
                        <td class="list" height="23" width="*">
                            <asp:TextBox ID="tburl" runat="server" Width="250px" CssClass="Textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="trdownload2" runat="server" style="display: none">
                        <td class="list" height="23" valign="top" width="80">
                            使用连接：
                        </td>
                        <td class="list" height="23" width="*">
                            <asp:RadioButtonList ID="rbisdiredict" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="否" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="是" Value="1"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="list" height="23" valign="top" width="80">
                            添加时间：
                        </td>
                        <td class="list" height="23" width="*">
                            <asp:TextBox ID="tbTime" runat="server" Width="250px" CssClass="Textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="list" height="23" valign="top" width="80">
                            审核发布：
                        </td>
                        <td class="list" height="23" width="*">
                            <asp:RadioButtonList ID="rbComm" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="0">否</asp:ListItem>
                                <asp:ListItem Selected="True" Value="1">是</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="forumRow" height="23" valign="top" width="80">
                        </td>
                        <td class="forumRow" height="23" width="*">
                            <input type="submit" value="添 加" id="Submit1" runat="server" onserverclick="Submit1_ServerClick" />
                            <input type="submit" value="修 改" id="sbEdit" runat="server" onserverclick="sbEdit_ServerClick" />
                            <input type="reset" value="重 填" />
                            <input type="button" id="btBack" runat="server" value="返 回" onclick="history.go(-1);" />
                            <input id="hdUrl" runat="server" type="hidden" />
                        </td>
                    </tr>
                </tbody>
            </table>
            </form>
                </div>
            </div>
</body>
</html>
