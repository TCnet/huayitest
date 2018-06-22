<!--
document.writeln('<div id=meizzDateLayer style="position: absolute; width: 142; height: 166; z-index: 100; display: none">');
    document.writeln('<span id=tmpSelectYearLayer  style="z-index: 9999;position: absolute;top: 2; left: 18;display: none"></span>');
    document.writeln('<span id=tmpSelectMonthLayer style="z-index: 9999;position: absolute;top: 2; left: 75;display: none"></span>');
    document.writeln('<table border=0 cellspacing=1 cellpadding=0 width=142 height=160 bgcolor=#000000 onselectstart="return false">');
        
        document.writeln('<tr>');
            document.writeln('<td width=142 height=23 bgcolor=#FFFFFF>');
                document.writeln('<table border=0 cellspacing=1 cellpadding=0 width=140 height=23>');
                    document.writeln('<tr align=center>');
                        document.writeln('<td width=20 align=center bgcolor=#808080 style="font-size:12px;cursor: hand;color: #FFD700" onclick="meizzPrevM()" title="前一月" Author=meizz>');
                            document.writeln('<b Author=meizz>&lt;</b>');
                        document.writeln('</td>');
                        document.writeln('<td width=100 align=center style="font-size:12px;cursor:default" Author=meizz>');
                            document.writeln('<span Author=meizz id=meizzYearHead onmouseover="style.backgroundColor=\'yellow\'" onmouseout="style.backgroundColor=\'white\'" title="点击这里选择年份" onclick="tmpSelectYearInnerHTML(this.innerText)" style="cursor: hand;"></span>');
                            document.writeln('&nbsp;年&nbsp;');
                            document.writeln('<span id=meizzMonthHead Author=meizz onmouseover="style.backgroundColor=\'yellow\'" onmouseout="style.backgroundColor=\'white\'" title="点击这里选择月份" onclick="tmpSelectMonthInnerHTML(this.innerText)" style="cursor: hand;"></span>');
                            document.writeln('&nbsp;月&nbsp;');
                        document.writeln('</td>');
                        document.writeln('<td width=20 bgcolor=#808080 align=center style="font-size:12px;cursor: hand;color: #FFD700" onclick="meizzNextM()" title="后一月" Author=meizz>');
                            document.writeln('<b Author=meizz>&gt;</b>');
                        document.writeln('</td>');
                    document.writeln('</tr>');
                document.writeln('</table>');
            document.writeln('</td>');
        document.writeln('</tr>');
        
        document.writeln('<tr>');
            document.writeln('<td width=142 height=18 bgcolor=#808080>');
                document.writeln('<table border=0 cellspacing=0 cellpadding=0 width=140 height=1 style="cursor:default">');
                    document.writeln('<tr align=center>');
                        document.writeln('<td style="font-size:12px;color:#FFFFFF" Author=meizz>日</td>');
                        document.writeln('<td style="font-size:12px;color:#FFFFFF" Author=meizz class="td1">一</td>');
                        document.writeln('<td style="font-size:12px;color:#FFFFFF" Author=meizz>二</td>');
                        document.writeln('<td style="font-size:12px;color:#FFFFFF" Author=meizz>三</td>');
                        document.writeln('<td style="font-size:12px;color:#FFFFFF" Author=meizz>四</td>');
                        document.writeln('<td style="font-size:12px;color:#FFFFFF" Author=meizz>五</td>');
                        document.writeln('<td style="font-size:12px;color:#FFFFFF" Author=meizz>六</td>');
                    document.writeln('</tr>');
                document.writeln('</table>');
            document.writeln('</td>');
        document.writeln('</tr>');
        
        document.writeln('<tr>');
            document.writeln('<td width=142 height=120>');
                document.writeln('<table border=0 cellspacing=1 cellpadding=0 width=140 height=120 bgcolor=#FFFFFF>');
                var n=0; 
                for (j=0;j<5;j++)
                { 
                    document.writeln('<tr align=center>'); 
                    for (i=0;i<7;i++)
                    {
                        document.writeln('<td width=20 height=20 id=meizzDay'+n+' style="font-size:12px" Author=meizz onclick=meizzDayClick(this.innerText,'+ n +')></td>');
                        n++;
                    }
                    document.writeln('</tr>');
                 }
                    document.writeln('<tr align=center>');
                        document.writeln('<td width=20 height=20 style="font-size:12px" id=meizzDay35 Author=meizz onclick=meizzDayClick(this.innerText,' +35+')></td>');
                        document.writeln('<td width=20 height=20 style="font-size:12px" id=meizzDay36 Author=meizz onclick=meizzDayClick(this.innerText,' + 36+')></td>');
                        document.writeln('<td colspan=5 align=right Author=meizz><span onclick=closeLayer() style="font-size:12px;cursor: hand" Author=meizz title="返回（不选择日期）"><u>关闭</u></span>&nbsp;</td>');
                    document.writeln('</tr>');
                document.writeln('</table>');
            document.writeln('</td>');
        document.writeln('</tr>');
        
        document.writeln('<tr>');
            document.writeln('<td>');
                document.writeln('<table border=0 cellspacing=1 cellpadding=0 width=100% bgcolor=#FFFFFF>');
                    document.writeln('<tr>');
                        document.writeln('<td Author=meizz align=left>');
                            document.writeln('<input Author=meizz type=button value="<<" title="前一年" onclick="meizzPrevY()" onfocus="this.blur()" style="cursor: hand;BACKGROUND-COLOR: #808080;BORDER-BOTTOM: #808080 1px outset; BORDER-LEFT: #808080 1px outset; BORDER-RIGHT: #808080 1px outset; BORDER-TOP: #808080 1px outset; FONT-SIZE: 12px; height: 20px;color: #FFD700; font-weight: bold">');
                            document.writeln('<input Author=meizz title="前一月" type=button value="<" onclick="meizzPrevM()" onfocus="this.blur()" style="cursor: hand;BACKGROUND-COLOR: #808080;BORDER-BOTTOM: #808080 1px outset; BORDER-LEFT: #808080 1px outset; BORDER-RIGHT: #808080 1px outset; BORDER-TOP: #808080 1px outset;font-size: 12px; height: 20px;color: #FFD700; font-weight: bold">');
                        document.writeln('</td> ');
                        document.writeln('<td Author=meizz align=center> ');
                            document.writeln('<input Author=meizz type=button value="重置" onclick="meizzToday()" onfocus="this.blur()" title="显示当前时间" style="cursor: hand;BACKGROUND-COLOR: #808080;BORDER-BOTTOM: #808080 1px outset; BORDER-LEFT: #808080 1px outset; BORDER-RIGHT: #808080 1px outset; BORDER-TOP: #808080 1px outset;font-size: 12px; height: 20px;color: #FFFFFF; font-weight: bold">');
                        document.writeln('</td>');
                        document.writeln('<td Author=meizz align=right>');
                            document.writeln('<input Author=meizz type=button value=">" onclick="meizzNextM()" onfocus="this.blur()" title="后一月" style="cursor: hand;BACKGROUND-COLOR: #808080;BORDER-BOTTOM: #808080 1px outset; BORDER-LEFT: #808080 1px outset; BORDER-RIGHT: #808080 1px outset; BORDER-TOP: #808080 1px outset;font-size: 12px; height: 20px;color: #FFD700; font-weight: bold">');
                            document.writeln('<input Author=meizz type=button value=">>" title="后一年" onclick="meizzNextY()" onfocus="this.blur()" style="cursor: hand;BACKGROUND-COLOR: #808080;BORDER-BOTTOM: #808080 1px outset; BORDER-LEFT: #808080 1px outset; BORDER-RIGHT: #808080 1px outset; BORDER-TOP: #808080 1px outset;font-size: 12px; height: 20px;color: #FFD700; font-weight: bold">');
                        document.writeln('</td>');
                    document.writeln('</tr>');
                document.writeln('</table>');
            document.writeln('</td>');
        document.writeln('</tr>');
    document.writeln('</table>');
    document.writeln('<iframe src="javascript:false" style="position:absolute;visibility:inherit; top:0px; left:0px; width:142px; height:166px; z-index:-1;opacity:.0;filter: alpha( opacity=0 ); -moz-opacity: 0;"></iframe>');
document.writeln('</div>');


var outObject;
//定义阳历中每个月的最大天数
var MonHead = new Array(12);    		   
MonHead[0] = 31; MonHead[1] = 28; MonHead[2] = 31; MonHead[3] = 30; MonHead[4]  = 31; MonHead[5]  = 30;
MonHead[6] = 31; MonHead[7] = 31; MonHead[8] = 30; MonHead[9] = 31; MonHead[10] = 30; MonHead[11] = 31;
//定义年的变量的初始值
var currentYear=new Date().getFullYear(); 
//定义月的变量的初始值  
var currentMonth=new Date().getMonth() + 1; 
//定义写日期的数组
var meizzWDay=new Array(37);  
               
function DateTimePicker(tt,obj) //主调函数
{
    if (arguments.length > 2)
    {
        alert("对不起！传入本控件的参数太多！");
        return;
    }
    
    if (arguments.length == 0)
    {
        alert("对不起！您没有传回本控件任何参数！");
        return;
    }
    
    var dads  = document.all.meizzDateLayer.style;
    var th = tt;
    var ttop  = tt.offsetTop;     //TT控件的定位点高
    var thei  = tt.clientHeight;  //TT控件本身的高
    var tleft = tt.offsetLeft;    //TT控件的定位点宽
    var ttyp  = tt.type;          //TT控件的类型
    
    while (tt = tt.offsetParent)
    {
        ttop  += tt.offsetTop; 
        tleft += tt.offsetLeft;
    }
    dads.top  = (ttyp == "image") ? ttop + thei : ttop + thei + 6;
    dads.left = tleft;
    outObject = (arguments.length == 1) ? th : obj;
    dads.display = '';
    event.returnValue=false;
}

function document.onclick() //任意点击时关闭该控件
{ 
    with(window.event.srcElement)
    { 
        if (tagName != "INPUT" && getAttribute("Author") == null)
        {
            document.all.meizzDateLayer.style.display="none";
        }
    }
}

function meizzWriteHead(yy,mm)  //往 head 中写入当前的年与月
{ 
    document.all.meizzYearHead.innerText  = yy;
    document.all.meizzMonthHead.innerText = mm;
}

function tmpSelectYearInnerHTML(strYear) //年份的下拉框
{
  if (strYear.match(/\D/)!=null){alert("年份输入参数不是数字！");return;}
  var m = (strYear) ? strYear : new Date().getFullYear();
  if (m < 1000 || m > 9999) {alert("年份值不在 1000 到 9999 之间！");return;}
  var n = m - 10;
  if (n < 1000) n = 1000;
  if (n + 26 > 9999) n = 9974;
  var s = "<select Author=meizz name=tmpSelectYear style='font-size: 12px' "
     s += "onblur='document.all.tmpSelectYearLayer.style.display=\"none\"' "
     s += "onchange='document.all.tmpSelectYearLayer.style.display=\"none\";"
     s += "currentYear = this.value; Main(currentYear,currentMonth)'>\r\n";
  var selectInnerHTML = s;
  for (var i = n; i < 2018; i++)
  {
    if (i == m)
       {selectInnerHTML += "<option value='" + i + "' selected>" + i + "年" + "</option>\r\n";}
    else {selectInnerHTML += "<option value='" + i + "'>" + i + "年" + "</option>\r\n";}
  }
  selectInnerHTML += "</select>";
  document.all.tmpSelectYearLayer.style.display="";
  document.all.tmpSelectYearLayer.innerHTML = selectInnerHTML;
  document.all.tmpSelectYear.focus();
}

function tmpSelectMonthInnerHTML(strMonth) //月份的下拉框
{
  if (strMonth.match(/\D/)!=null){alert("月份输入参数不是数字！");return;}
  var m = (strMonth) ? strMonth : new Date().getMonth() + 1;
  var s = "<select Author=meizz name=tmpSelectMonth style='font-size: 12px' "
     s += "onblur='document.all.tmpSelectMonthLayer.style.display=\"none\"' "
     s += "onchange='document.all.tmpSelectMonthLayer.style.display=\"none\";"
     s += "currentMonth = this.value; Main(currentYear,currentMonth)'>\r\n";
  var selectInnerHTML = s;
  for (var i = 1; i < 13; i++)
  {
    if (i == m)
       {selectInnerHTML += "<option value='"+i+"' selected>"+i+"月"+"</option>\r\n";}
    else {selectInnerHTML += "<option value='"+i+"'>"+i+"月"+"</option>\r\n";}
  }
  selectInnerHTML += "</select>";
  document.all.tmpSelectMonthLayer.style.display="";
  document.all.tmpSelectMonthLayer.innerHTML = selectInnerHTML;
  document.all.tmpSelectMonth.focus();
}

function closeLayer()               //这个层的关闭
{
    document.all.meizzDateLayer.style.display="none";
}

function document.onkeydown()
{
    if (window.event.keyCode==27)document.all.meizzDateLayer.style.display="none";
}

function IsPinYear(year)            //判断是否闰平年
{
    if ( 0 == year % 4 && ( (year %100 != 0)||(year % 400 == 0) ) )
    {
        return true;
    }
    else
    { 
        return false;
    }
}

function DaysInMonth(year,month)  //闰年二月为29天
{
    var c = MonHead[month-1];
    if( (month == 2) && IsPinYear(year) ) 
    {
        c++;
    }
    return c;
}

function GetDOW(day,month,year)     //求某天的星期几
{
    var dt = new Date(year,month-1,day).getDay()/7; return dt;
}

function meizzPrevY()  //往前翻 Year
  {
    if(currentYear > 999 && currentYear <10000){currentYear--;}
    else{alert("年份超出范围（1000-9999）！");}
    Main(currentYear,currentMonth);
  }
function meizzNextY()  //往后翻 Year
  {
    if(currentYear > 999 && currentYear <10000){currentYear++;}
    else{alert("年份超出范围（1000-9999）！");}
    Main(currentYear,currentMonth);
  }
function meizzToday()  //Today Button
  {
    currentYear = new Date().getFullYear();
    currentMonth = new Date().getMonth()+1;
    Main(currentYear,currentMonth);
  }
function meizzPrevM()  //往前翻月份
  {
    if(currentMonth>1){currentMonth--}else{currentYear--;currentMonth=12;}
    Main(currentYear,currentMonth);
  }
function meizzNextM()  //往后翻月份
  {
    if(currentMonth==12){currentYear++;currentMonth=1}else{currentMonth++}
    Main(currentYear,currentMonth);
  }

function Main(yy,mm)   //主要的写程序**********
{
    meizzWriteHead(yy,mm);
    
    for (var i = 0; i < 37; i++)
    {
        //将显示框的内容全部清空
        meizzWDay[i]=""; 
    } 
    
    var day1 = 1;
    var firstday = new Date(yy, mm-1, 1).getDay();  //某月第一天的星期几
    
    //4444
    var prevMonth = currentMonth - 1;
    var prevYear = currentYear;
    if(currentMonth - 1 == 0)
    {
        prevMonth = 12;
        prevYear = currentYear - 1;
    }
    else
    {
        prevMonth = currentMonth - 1;
        prevYear = currentYear;
    }
   
    var prevMonthDays = DaysInMonth(prevYear, prevMonth)
    
    for(var i = firstday - 1; i >= 0; i--)
    {
        meizzWDay[i] = prevMonthDays;
        prevMonthDays--;
    }
    
    //
    
    for (var i = firstday; day1 < DaysInMonth(yy,mm) + 1; i++)
    {
        meizzWDay[i] = day1;
        day1++;
    }
    
    //4444
    day1 = 1;
    for(var i = firstday + DaysInMonth(yy,mm); i < 37; i++)
    {
        meizzWDay[i] = day1;
        day1++;
    }
    
    //
    
    for (var i = 0; i < 37; i++)
    { 
        var da = eval("document.all.meizzDay" + i)     //书写新的一个月的日期星期排列
        if (meizzWDay[i] != "")
        { 
            if(i < firstday)
            {
                da.style.backgroundColor = "FD1606";
            }
            else if( i >= firstday + DaysInMonth(yy,mm))
            {
                da.style.backgroundColor = "FD1606";
            }
            else
            {
                da.style.backgroundColor = (yy == new Date().getFullYear() &&
                mm == new Date().getMonth() + 1 && meizzWDay[i] == new Date().getDate()) ? "#FFD700" : "#73A6DE";
            }
            
            da.innerHTML = "<b>" + meizzWDay[i] + "</b>";
            da.style.cursor="hand"
        }
        else
        {
            da.innerHTML = "";
            da.style.backgroundColor = "";
            da.style.cursor = "default"
        }
    }
}

function meizzDayClick(n, dayIndex)  //点击显示框选取日期，主输入函数*************
{
    //444
    var prevMonth = currentMonth - 1;
    var prevYear = currentYear;
    var nextMonth = currentMonth + 1;
    var nextYear = currentYear
    var firstday = new Date(currentYear, currentMonth - 1, 1).getDay();
    if(currentMonth - 1 == 0)
    {
        prevMonth = 12;
        prevYear = currentYear - 1;
    }
    else
    {
        prevMonth = currentMonth - 1;
        prevYear = currentYear;
    }
    
    if(currentMonth + 1 == 13)
    {
        nextMonth = 1;
        nextYear = currentYear + 1;
    }
    else
    {
        nextMonth = currentMonth + 1;
        nextYear = currentYear;
    }
    //444

    var yy = currentYear;
    var mm = currentMonth;
    
    //44
    if(dayIndex < firstday)
    {
        yy = prevYear;
        mm = prevMonth;
    }
    else if(dayIndex >= firstday + DaysInMonth(currentYear,currentMonth))
    {
        yy = nextYear;
        mm = nextMonth;
    }
    //44
    
    if (mm < 10){mm = "0" + mm;}
    if (outObject)
    {
        if (!n) 
        {
            outObject.value="";
            return;
        }
        if ( n < 10)
        {
            n = "0" + n;
        }
        outObject.value= yy + "-" + mm + "-" + n ; //注：在这里你可以输出改成你想要的格式
        closeLayer();
        //outObject.focus();
    }
    else 
    {
        closeLayer(); 
        alert("您所要输出的控件对象并不存在！");
    }
}

Main(currentYear,currentMonth);

// -->
