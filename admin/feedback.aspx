<%@ Page Language="C#" Inherits="HuaYimo.admin.feedback" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
     <title><%=ConfigurationManager.AppSettings["AdminTitle"].ToString() %></title>
    <link href="CSS/main_right.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript">         
            function DeleteIt(id,page)
            {
                if(window.confirm("警告！删除后将不可恢复！是否确定删除？"))
                {                   
                    var url=document.URL.replace("&","|");
                    document.location="feedback.aspx?del="+id+"&page="+page+"&reUrl="+url;                  
                }               
            }

            function CheckAll(id) {  
              var all=document.getElementById(id);//获取到点击全选的那个复选框的id  
              var one=document.getElementsByName('sel');//获取到复选框的名称  
              //因为获得的是数组，所以要循环 为每一个checked赋值  
              for(var i=0;i<one.length;i++){  
                one[i].checked=all.checked; //直接赋值不就行了嘛  
              }  
             } 
            
           
        </script>
    <style type="text/css">
        .style1
        {
            width: 7%;
        }
        .style2
        {
            width: 8%;
        }
        .style3
        {
            width: 9%;
        }
        .style4
        {
            width: 6%;
        }
    </style>
</head>
<body>
<div id="mainbody">
   <form id="form1" runat="server">
  <div style="width:100%; text-align:center; font-weight:bold; font-size:16pt">
        留言管理
        </div>

<DIV id="search">
 <div class="search_left"></div>
 <div class="search_center"> 
    <table cellspacing="3" cellpadding="0" width="98%" align="left" border="0">
     <tbody>
       <tr>
        
         <td align="left" width="15%">关键字：<asp:TextBox ID="tbKey" runat="server" CssClass="textbox" Width=80></asp:TextBox></td>
         <td align="left" width="15%" style="padding-top:1px;" >用户：
             <asp:TextBox ID="tbusername" runat="server" Width=80></asp:TextBox>
         </td>
         
         <td align="left" width="40%">
        时间： <asp:TextBox ID="tbTime1" runat="server" Width=60px></asp:TextBox>～
         <asp:TextBox ID="tbTime2" runat="server" Width=60px></asp:TextBox>
        &nbsp;
         类型：
          <asp:DropDownList ID="ddltype" runat="server">
          
                        </asp:DropDownList>
                        &nbsp;
                        
                         <asp:Button ID="btSearch" runat="server" OnClick="btSearch_Click" Text="搜 索" />
         </td>
         <td align="left" >
        
             <asp:DropDownList ID="drPaixu" runat="server">
            
           
               <asp:ListItem Text="是否审核" Value="flag"></asp:ListItem>
                <asp:ListItem Text="添加时间" Value="addtime"></asp:ListItem>
             </asp:DropDownList>&nbsp;
             <asp:DropDownList ID="drPaixu2" runat="server">
             
             <asp:ListItem  Text="降序" Value="desc"></asp:ListItem>
             <asp:ListItem  Text="升序" Value="asc"></asp:ListItem>
             
             </asp:DropDownList>
             &nbsp;&nbsp;
             <asp:Button ID="btPaiXu" runat="server" Text="排 序" onclick="btPaiXu_Click" />
         </td>
       </tr>
     </tbody>
   </table>
   </div>
 <div style=" width:2.9%; height:28px; float:right;"><img src="images/img_search_right.gif"  /></div>
</DIV>

<div id="right_table">
 
      

    <table align="center" border="0" cellpadding="3" cellspacing="1" class="tableBorder" style="line-height: 14pt">
            <tr>
                    <th height="25" style="width:5%">
                    <asp:CheckBox ID="chkAll" onClick="CheckAll(this.id)"  runat="server" ToolTip="全选" /></th>
                    
                    <th style="width:10%">用户</th>
                    <th style="width:15%">标题</th>
                    <th style="width:35%">内容</th>
              
                    <th style="width:10%">留言时间</th>   
                    
                    
                    <th style="width:10%">是否审核</th>
                    <th style="width:15%">操作</th>
                </tr>
    <asp:Repeater ID="rtNews" runat="server" EnableViewState="false" 
                onitemdatabound="rtNews_ItemDataBound">
        <ItemTemplate>
            <tr>
            <td class="forumRow" align=center><input type="checkbox" name="sel" value="<%# Eval("id") %>" /></td>
           
            <td class="forumRow">
                <%# Eval("username") %><br />
            </td>
            <td class="forumRow" >
                <%# Eval("title") %>
            </td> 
            
           
            
            <td class="forumRow" >
            <%#Eval("content") %>
            </td>
            <td class="forumRow" align=center>
                <%# Eval("addtime") %>
            </td> 
            <td class="forumRow" align="center" >
                 <%# Convert.ToBoolean(Eval("flag"))==false ? "<font color=red><strong>×</strong></font>" : "<font color=green><strong>√</strong></font>"%>
            </td>
          
            
            <td class="forumRow" align="center">                
             
                <%# CommNews(Eval("id").ToString(),Convert.ToBoolean(Eval("flag"))) %> | 
                <a href="javascript:DeleteIt(<%# Eval("id") %>,<%=Request["page"]==null?"0":Request["page"] %>)">删除</a>
            </td>
        </tr>
        </ItemTemplate>
        <FooterTemplate>
            <tr>
              <td height="30" colspan="9" align="center" >页次：
              <asp:Label ID="lbpagenow" runat="server" Text="Label"></asp:Label>/<asp:Label ID="lbpagetotal" runat="server" Text="Label"></asp:Label>     
               每页<asp:Label ID="lbnumber" runat="server" Text="Label"></asp:Label>条 共有记录[<asp:Label
                   ID="lbnumbertotal" runat="server" Text="Label"></asp:Label>]条 
                   <asp:HyperLink ID="lpfirst" runat="server">首页</asp:HyperLink>
                    <asp:HyperLink ID="lpprev" runat="server" CssClass="black_link">上一页</asp:HyperLink>
                    <asp:Label ID="lbGid" runat="server" Text=""></asp:Label>
                   <asp:HyperLink ID="lpnext" runat="server" CssClass="black_link"> 下一页</asp:HyperLink>
                   <asp:HyperLink ID="lplast" runat="server">末页</asp:HyperLink> 
                   </td>
            </tr>
            </FooterTemplate>
    </asp:Repeater>
    
</table>

    

&nbsp;
    &nbsp;
    <asp:Button ID="btsetflag1" runat="server" Text="批量审核" 
        onclick="btsetflag1_Click" />
    &nbsp;
    <asp:Button ID="btsetflag2" runat="server" Text="批量撤销审核" 
        onclick="btsetflag2_Click" />
    &nbsp;&nbsp;
    <asp:Button ID="btDel" runat="server" OnClick="btDel_Click" Text="批量删除" OnClientClick="if(!confirm('警告！删除后将不可恢复！是否确定删除？')) return false;" />

        </div>
&nbsp;</form>
 </div>
 
</body>
</html>
