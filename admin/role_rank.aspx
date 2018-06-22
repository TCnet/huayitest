<%@ Page Language="C#" Inherits="HuaYimo.admin.role_rank" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
     <title><%=ConfigurationManager.AppSettings["AdminTitle"].ToString() %></title>
 <link href="CSS/main_right.css" type="text/css" rel="stylesheet"/>
<script>
function CheckAll(cid,id){ 
            for(var i=0;i<document.getElementById(cid).getElementsByTagName("input").length;i++)
            {
                if(document.getElementById(id).checked)
                {document.getElementById(cid+"_"+i).checked=true;}
                else
                {document.getElementById(cid+"_"+i).checked=false;}
                
            }             

        }
function CheckAll2(id){ 
               if(document.getElementById(id).checked)
                {
                   for(var i=1;i<16;i++)
                   {
                      document.getElementById("CheckBox"+i).checked=true;
                      if(document.getElementById("cblmodule"+i)!=null)
                      { CheckAll("cblmodule"+i,"CheckBox"+i);}
                     
                   }
                }
                else
                {
                   for(var i=1;i<16;i++)
                   {
                      document.getElementById("CheckBox"+i).checked=false;
                      if(document.getElementById("cblmodule"+i)!=null)
                      { CheckAll("cblmodule"+i,"CheckBox"+i);}
                   }
                
                }       

        } 


</script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="mainbody">
<div id="right_table">
   <table width="100%" border="0" cellpadding="0" cellspacing="1" class="list" >
   <tbody><TR>
   <TH colSpan=3 height=25>
    设置权限</TH></TR>
    <tr>
        <td  class="list" width="5%"><div align="center">&nbsp;</div></td>   
          <td class="list"  colspan="2"><div align="left">&nbsp;<span style="color:Red">（操作说明：角色权限以详细模块为准。）</span></div></td>    
        </tr>
      <tr>
        <td  class="list" width="5%"><div align="center">&nbsp;</div></td>   
          <td class="list"  colspan="2"><div align="left">&nbsp;角色名称：<asp:Label ID="lbrolename" runat="server" Text="Label"></asp:Label></div></td>    
        </tr>
        
        <tr>
        <td bgcolor="#EFEFEF" width="5%"><div align="center">&nbsp;<asp:CheckBox ID="chkAll" onClick="CheckAll2(this.id);" runat="server" ToolTip="全选" /></div></td>   
          <td bgcolor="#EFEFEF" width="15%"><div align="left">&nbsp;<strong>主模块</strong></div></td>           
            <td bgcolor="#EFEFEF" width="*"><div align="left">&nbsp;<strong>详细模块</strong></div></td>
        </tr>
         <tr>
        <td class="list" width="5%"><div align="center">&nbsp;<asp:CheckBox ID="CheckBox1" onClick="CheckAll('cblmodule1',this.id);" runat="server" ToolTip="全选" /></div></td>   
          <td class="list" width="15%"><div align="left">&nbsp;<asp:Label ID="lbmodule1" runat="server" Text="Label"></asp:Label></div></td>
              
            <td class="list" width="*"><div align="left">
                <asp:CheckBoxList ID="cblmodule1" runat="server" RepeatColumns=4 RepeatDirection=Horizontal>
                </asp:CheckBoxList>
            </div></td>
        </tr>
         <tr>
        <td class="list" width="5%"><div align="center">&nbsp;<asp:CheckBox ID="CheckBox2" onClick="CheckAll('cblmodule2',this.id);" runat="server" ToolTip="全选" /></div></td>   
          <td class="list" width="15%"><div align="left">&nbsp;<asp:Label ID="lbmodule2" runat="server" Text="Label"></asp:Label></div></td>
              
            <td class="list" width="*"><div align="left">
                <asp:CheckBoxList ID="cblmodule2" runat="server" RepeatColumns=4 RepeatDirection=Horizontal>
                </asp:CheckBoxList>
            </div></td>
        </tr>
         <tr>
        <td class="list" width="5%"><div align="center">&nbsp;<asp:CheckBox ID="CheckBox3" onClick="CheckAll('cblmodule3',this.id);" runat="server" ToolTip="全选" /></div></td>   
          <td class="list" width="15%"><div align="left">&nbsp;<asp:Label ID="lbmodule3" runat="server" Text="Label"></asp:Label></div></td>
              
            <td class="list" width="*"><div align="left">
                <asp:CheckBoxList ID="cblmodule3" runat="server" RepeatColumns=4 RepeatDirection=Horizontal>
                </asp:CheckBoxList>
            </div></td>
        </tr>
         <tr>
        <td class="list" width="5%"><div align="center">&nbsp;<asp:CheckBox ID="CheckBox4" onClick="CheckAll('cblmodule4',this.id);" runat="server" ToolTip="全选" /></div></td>   
          <td class="list" width="15%"><div align="left">&nbsp;<asp:Label ID="lbmodule4" runat="server" Text="Label"></asp:Label></div></td>
              
            <td class="list" width="*"><div align="left">
                <asp:CheckBoxList ID="cblmodule4" runat="server" RepeatColumns=4 RepeatDirection=Horizontal>
                </asp:CheckBoxList>
            </div></td>
        </tr>
         <tr>
        <td class="list" width="5%"><div align="center">&nbsp;<asp:CheckBox ID="CheckBox5" onClick="CheckAll('cblmodule5',this.id);" runat="server" ToolTip="全选" /></div></td>   
          <td class="list" width="15%"><div align="left">&nbsp;<asp:Label ID="lbmodule5" runat="server" Text="Label"></asp:Label></div></td>
              
            <td class="list" width="*"><div align="left">
                <asp:CheckBoxList ID="cblmodule5" runat="server" RepeatColumns=4 RepeatDirection=Horizontal>
                </asp:CheckBoxList>
            </div></td>
        </tr>
         <tr>
        <td class="list" width="5%"><div align="center">&nbsp;<asp:CheckBox ID="CheckBox6" onClick="CheckAll('cblmodule6',this.id);" runat="server" ToolTip="全选" /></div></td>   
          <td class="list" width="15%"><div align="left">&nbsp;<asp:Label ID="lbmodule6" runat="server" Text="Label"></asp:Label></div></td>
              
            <td class="list" width="*"><div align="left">
                <asp:CheckBoxList ID="cblmodule6" runat="server" RepeatColumns=4 RepeatDirection=Horizontal>
                </asp:CheckBoxList>
            </div></td>
        </tr>
         <tr>
        <td class="list" width="5%"><div align="center">&nbsp;<asp:CheckBox ID="CheckBox7" onClick="CheckAll('cblmodule7',this.id);" runat="server" ToolTip="全选" /></div></td>   
          <td class="list" width="15%"><div align="left">&nbsp;<asp:Label ID="lbmodule7" runat="server" Text="Label"></asp:Label></div></td>
              
            <td class="list" width="*"><div align="left">
                <asp:CheckBoxList ID="cblmodule7" runat="server" RepeatColumns=4 RepeatDirection=Horizontal>
                </asp:CheckBoxList>
            </div></td>
        </tr>
         <tr>
        <td class="list" width="5%"><div align="center">&nbsp;<asp:CheckBox ID="CheckBox8" onClick="CheckAll('cblmodule8',this.id);" runat="server" ToolTip="全选" /></div></td>   
          <td class="list" width="15%"><div align="left">&nbsp;<asp:Label ID="lbmodule8" runat="server" Text="Label"></asp:Label></div></td>
              
            <td class="list" width="*"><div align="left">
                <asp:CheckBoxList ID="cblmodule8" runat="server" RepeatColumns=4 RepeatDirection=Horizontal>
                </asp:CheckBoxList>
            </div></td>
        </tr>
        
        
        <tr>
        <td class="list" width="5%"><div align="center">&nbsp;<asp:CheckBox ID="CheckBox9" onClick="CheckAll('cblmodule9',this.id);" runat="server" ToolTip="全选" /></div></td>   
          <td class="list" width="15%"><div align="left">&nbsp;<asp:Label ID="lbmodule9" runat="server" Text="Label"></asp:Label></div></td>
              
            <td class="list" width="*"><div align="left">
                <asp:CheckBoxList ID="cblmodule9" runat="server" RepeatColumns=4 RepeatDirection=Horizontal>
                </asp:CheckBoxList>
            </div></td>
        </tr>
         <tr>
        <td class="list" width="5%"><div align="center">&nbsp;<asp:CheckBox ID="CheckBox10" onClick="CheckAll('cblmodule10',this.id);" runat="server" ToolTip="全选" /></div></td>   
          <td class="list" width="15%"><div align="left">&nbsp;<asp:Label ID="lbmodule10" runat="server" Text="Label"></asp:Label></div></td>
              
            <td class="list" width="*"><div align="left">
                <asp:CheckBoxList ID="cblmodule10" runat="server" RepeatColumns=4 RepeatDirection=Horizontal>
                </asp:CheckBoxList>
            </div></td>
        </tr>
         <tr>
        <td class="list" width="5%"><div align="center">&nbsp;<asp:CheckBox ID="CheckBox11" onClick="CheckAll('cblmodule11',this.id);" runat="server" ToolTip="全选" /></div></td>   
          <td class="list" width="15%"><div align="left">&nbsp;<asp:Label ID="lbmodule11" runat="server" Text="Label"></asp:Label></div></td>
              
            <td class="list" width="*"><div align="left">
                <asp:CheckBoxList ID="cblmodule11" runat="server" RepeatColumns=4 RepeatDirection=Horizontal>
                </asp:CheckBoxList>
            </div></td>
        </tr>

        
        
         <tr>
        <td class="list" width="5%"><div align="center">&nbsp;</div></td>   
          <td class="list"  colspan="2"><div align="left">&nbsp;
              <asp:Button ID="btSub" runat="server" Text="提 交" onclick="btSub_Click" />
              &nbsp;&nbsp;
              <input  type="reset"  value="重 置"/>
              <input  type="hidden" id="hdback" runat="server"/>
          </div></td>
              
            
        </tr>
        
    </tbody>
        </table>
</div>

    
    </div>
    </form>
</body>
</html>
