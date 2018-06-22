<%@ Page Language="C#" Inherits="HuaYimo.admin.mainswitch" %>
html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>天策网络</title>

<SCRIPT language=javascript>
function switchSysBar(){
    if (parent.document.getElementById('attachucp').cols=="180,10,*"){  
        document.getElementById('leftbar').style.display="";
        parent.document.getElementById('attachucp').cols="0,10,*";      
    }
    else{
        parent.document.getElementById('attachucp').cols="180,10,*";        
        document.getElementById('leftbar').style.display="none"
    }
}
function load(){
    if (parent.document.getElementById('attachucp').cols=="0,10,*"){    
        document.getElementById('leftbar').style.display="";        
    }
}
</SCRIPT>
</head>

<BODY bgColor=#000000 leftMargin=0 topMargin=0 onload=load() marginheight="0" marginwidth="0">
<CENTER>
<TABLE height="100%" cellSpacing=0 cellPadding=0 width="100%" border=0>
  <TBODY>
  <TR>
    <TD width=1 bgColor=#009fef><IMG height=1 src="images/ccc.gif" 
      width=1></TD>
    <TD background="images/img_center_bg.gif" bgColor=#f5f4f4 id=leftbar style="DISPLAY: none"><A 
      onclick=switchSysBar() href="javascript:void(0);"><IMG height=90 
      alt=展开左侧菜单 src="images/pic24.gif" width=9 border=0></A></TD>
    <TD background="../images/img_center_bg.gif" bgColor=#f5f4f4 id=rightbar><A onclick=switchSysBar() 
      href="javascript:void(0);"><IMG height=90 alt=隐藏左侧菜单 
      src="images/pic23.gif" width=9 
border=0></A></TD>
  </TR></TBODY></TABLE></CENTER></BODY>
</html>
