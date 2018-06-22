<%@ Page Language="C#" Inherits="HuaYimo.admin.logout" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
     <title><%=ConfigurationManager.AppSettings["AdminTitle"].ToString() %></title>
    <link href="res/style.css" type="text/css" rel="stylesheet"/>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body>
    <form id="form1" runat="server">
    <TABLE id="Table1" cellSpacing="1" cellPadding="1" width="500" align="center">
                    <TR>
                        <TD height="150" ></TD>
                    </TR>
                    
                    <TR>
                        <TD align="center"><FONT face="宋体">
                                <asp:Label id="lbMess" runat="server"  Font-Bold="True" ForeColor="Red">您已经成功退出系统!</asp:Label>
                    </FONT></TD>
                    </TR>
                </TABLE>
    </form>
</body>
</html>
