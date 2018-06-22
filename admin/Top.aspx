<%@ Page Language="C#" Inherits="HuaYimo.admin.Top" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>顶部页面</title>
    <link href="css/style.css" type="text/css" rel="stylesheet" />
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body style="margin:0 auto">
<div id="Header">
  <div id="top_img">
  <img src="images/top_img_logo.gif"/>
  </div>
  <div id="top_img02">
    <img src="images/top_img_left.gif" /><img src="images/top_img_center.gif" width="130" height="96" /><img src="images/top_img_right.gif"  />
  <div id="top_time">  
          <script language="JavaScript" type="text/javascript">
function initArray()
 {
  for(i=0;i<initArray.arguments.length;i++)
  this[i]=initArray.arguments[i];
 }
 var isnMonths=new initArray("1","2","3","4","5","6","7","8","9","10","11","12");
 var isnDays=new initArray("星期日","星期一","星期二","星期三","星期四","星期五","星期六","星期日");
 today=new Date();
 hrs=today.getHours();
 min=today.getMinutes();
 sec=today.getSeconds();
 clckh=""+((hrs>12)?hrs-12:hrs);
 clckm=((min<10)?"0":"")+min;clcks=((sec<10)?"0":"")+sec;
 clck=(hrs>=12)?"下午":"上午";
 var stnr="";
 var ns="0123456789";
 var a="";

function getFullYear(d)
{
  yr=d.getYear();if(yr<1000)
  yr+=1900;return yr;}
  document.write("<a href='/Default.aspx' class='black_link' target=_blank title='网站前台首页'><strong>主页</strong></a> "+getFullYear(today)+"-"+isnMonths[today.getMonth()]+"-"+today.getDate()+"  "+isnDays[today.getDay()]+"");</script>   
 </div>
  </div>
</div>
</body>
</html>