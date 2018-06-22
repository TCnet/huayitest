<%@ Page Language="C#" Inherits="HuaYimo.admin.Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	
    <title><%=ConfigurationManager.AppSettings["AdminTitle"].ToString() %></title>
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/Style_default.css" rel="stylesheet" type="text/css" />
    <style>
    body {
    background: url('images/bg.jpg'); MARGIN: 74px 0px 0px 0px; FONT-SIZE: 12px; COLOR: #4D4D4D; LINE-HEIGHT: 20px; font-family: ����,Arial,Verdana; TEXT-DECORATION: none; 
}
input {
    width:115px; height:15px; border-left:1px solid #4273B6; border-right:1px solid #4273B6; border-top:1px solid #4273B6; border-bottom:1px solid #4273B6; FONT-SIZE: 12px; COLOR: #4D4D4D; font-family: ����,Arial,Verdana;
}
td {
    FONT-SIZE: 12px; COLOR: #4D4D4D; font-family: Arial,Verdana; TEXT-DECORATION: none
}
.B {
    COLOR: #4272BA; FONT-WEIGHT: bold; text-align: right; 
}
.G {
    COLOR: #999999;  
}
.C {
    text-align: center;
}
.L {
    text-align: left;
}
.R {
    text-align: right;
}

a:Link,a:Visited { 
    color: #4D4D4D; text-decoration:none;
}
a:Hover,a:Active { 
    color: #FF0000; text-decoration:none;
}

a.A01:Link,a.A01:Visited { 
    color: #261CDC; text-decoration:none;
}
a.A01:Hover,a.A01:Active { 
    color: #FF0000; text-decoration:underline;
}
    </style>
</head>
<body>
	<form id="form1" runat="server">
<div align="center">
        <table border="0" width="653" id="table8" cellspacing="0" cellpadding="0">
            <tr>
                <td width="6" height="6">
                <img border="0" src="images/login_r2_c2.jpg" width="10" height="10"></td>
                <td width="633" height="10" background="images/login_r2_c3.jpg">
                <img border="0" src="images/1pix.gif" width="1" height="1"></td>
                <td width="6" height="6">
                <img border="0" src="images/login_r2_c8.jpg" width="10" height="10"></td>
            </tr>
            <tr>
                <td width="10" height="368" background="images/login_r3_c2.jpg">  </td>
                <td width="633" height="368" valign="top" bgcolor="#FFFFFF">
                <table border="0" width="100%" id="table10" cellspacing="0" cellpadding="0">
                    <tr>
                        <td colspan="2">
                        <img border="0" src="images/login_r3_c3.jpg" width="633" height="234"></td>
                    </tr>
                    <tr>
                        <td width="175">
                        <img border="0" src="images/login_r4_c3.jpg" width="175" height="134"></td>
                        <td width="458" valign="top">
                        <table border="0" width="100%" id="table11" cellspacing="0" cellpadding="0">
                            <tr>
                                <td colspan="2">
                                <img border="0" src="images/login_r4_c4.jpg" width="458" height="29"></td>
                            </tr>
                            <tr>
                                <td width="447">
                                <table border="0" width="100%" id="table12" cellspacing="0" cellpadding="0">
                                    <tr>
                                      <td colspan="5">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td width="57" class="R">用户名：</td>
                                        <td>
                                        <input class="input" size="18" id="txtUserName" runat="server"></td>
                                        <td width="50" class="R">密码：</td>
                                        <td>
                                        <input class="input" size="18" id="txtPassWord" runat="server" type="password"></td>
                                        <td width="110" class="C">
                                        <asp:ImageButton ID="imgBut" ImageUrl="images/login_r6_c5.jpg" width="90" Style="border:none;" height="30" runat="server" OnClick="imgBut_Click" />                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">&nbsp;
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName"
                                                Display="None" ErrorMessage="请输入用户名" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassWord"
                                                Display="None" ErrorMessage="请输入密码" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                                    </tr>
                                </table>
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" />
                                </td>
                                <td width="11">
                                <img border="0" src="images/login_r5_c6.jpg" width="11" height="75"></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                <img border="0" src="images/login_r8_c4.jpg" width="458" height="30"></td>
                            </tr>
                        </table>
                        </td>
                    </tr>
                </table>
                </td>
                <td width="10" height="368" background="images/login_r3_c8.jpg">&nbsp;</td>
            </tr>
            <tr>
                <td width="6" height="6">
                <img border="0" src="images/login_r9_c2.jpg" width="10" height="10"></td>
                <td width="633" height="6" background="images/login_r9_c3.jpg">
                <img border="0" src="images/1pix.gif" width="1" height="1"></td>
                <td width="6" height="6">
                <img border="0" src="images/login_r9_c8.jpg" width="10" height="10"></td>
            </tr>
        </table>
        <table border="0" width="653" id="table9" cellspacing="0" cellpadding="0">
            <tr>
                <td></td>
            </tr>
            <tr>
                <td class="G1">&nbsp;</td>
            </tr>
            <tr>
                <td class="G1 C">
               Copyright 2018 &copy;
                        <a target="_blank" href="http://bbs.nbtcnet.com"><span style="color:Red">NBTCNET</span></a>  
                        All Rights Reserved.</td>
 
            </tr>
            <tr>
                <td></td>
            </tr>
        </table>
        </div>
        </form>
</body>
</html>
