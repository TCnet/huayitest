<%@ Page Language="C#" Inherits="HuaYimo.admin.index" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title><%=ConfigurationManager.AppSettings["AdminTitle"].ToString() %></title>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>

<FRAMESET rows="96,*" cols="*" frameborder="no" border="0" framespacing="0">
  <frame id="topFrame" src="Top.aspx" name=topFrame noresize scrolling=No  />
<FRAMESET id=attachucp border=0 frameSpacing=0 rows=* scrolling=No frameBorder=no cols=180,10,*>
<FRAME name=leftFrame src="main_left.aspx" frameBorder=no noResize  >
<FRAME id=leftbar name=switchFrame src="mainswitch.aspx" noResize scrolling=no>
<FRAME id=rightbar border=0 name=mainFrame src="main_right.aspx" frameBorder=no noResize scrolling=yes>
</FRAMESET>
</FRAMESET>
    <noframes></noframes>


</html>

