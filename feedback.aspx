<%@ Page Title="" Language="C#" MasterPageFile="~/root.master" AutoEventWireup="true" CodeBehind="feedback.aspx.cs" Inherits="HuaYimo.feedback" %>
<%@ Register Src="~/uc/uc_breadcrumb.ascx" TagName="uc_breadcrumb" TagPrefix="uc_breadcrumb" %>
<%@ Register Src="~/uc/uc_menu.ascx" TagName="uc_menu" TagPrefix="uc_menu" %>
<%@ Register Src="~/uc/uc_leftmenu.ascx" TagName="uc_leftmenu" TagPrefix="uc_leftmenu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="menu" runat="server">
    <uc_menu:uc_menu ID="uc_menu" runat="server" CssType="10"></uc_menu:uc_menu>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
      <uc_breadcrumb:uc_breadcrumb ID="uc_breadcrumb" runat="server" Title="联系我们"></uc_breadcrumb:uc_breadcrumb>
    <div class="container ">
      <div class="row m-t-md">
        <div class="col-md-7 col-sm-7 col-xs-12">
          <div class="row wrapper">
            <div class="col-md-4 col-sm-4 col-xs-12 ">
              <p>
                <span class="font-bold"> <asp:Label id="lbWebName" runat="server" /></span><br> 
                  微信: <asp:Label id="lbWeiXin" runat="server" /><br>
                  QQ: <asp:Label id="lbQQ" runat="server" /><br>
                           
              </p>

            </div>
            <div class="col-md-4 col-sm-4 col-xs-12">
              <p>
                  <asp:Label id="lbAddress" runat="server" /><br>
              </p>


            </div>
            <div class="col-md-4 col-sm-4 col-xs-12">
              <p>
                电话: <asp:Label id="lbTelPhone" runat="server" /><br> 手机: <asp:Label id="lbMobilPhone" runat="server" /><br> 传真:  <asp:Label id="lbFax" runat="server" /><br>
              </p>

            </div>
          </div>
          <div class="row wrapper ">
            <p class="padder">
                <iframe src="http://www.google.cn/maps/embed?pb=!1m18!1m12!1m3!1d3459.57385601874!2d121.58052285633086!3d29.876561283913652!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x344d632081c90d7f%3A0x373c2d60c5554167!2z5rWZ5rGf55yB5a6B5rOi5biC5rGf5Lic5Yy66aKQ6auY5Yib5Lia5aSn5Y6mIOmCruaUv-e8lueggTogMzE1MDAw!5e0!3m2!1szh-CN!2scn!4v1517316588273" width="100%" height="400" frameborder="0" style="border:0" allowfullscreen></iframe>
            </p>

          </div>
        </div>
        <div class="col-md-5 col-sm-5 col-xs-12">
          <div class="row wrapper ">
         
              <section class=" ">
                <div class="panel-body">

                  <div class="form-group pull-in clearfix">
                    <div class="col-sm-6">
                      <label>联系人 *</label>
                      <input type="text" id="tbusername" runat="server" class="form-control bg-light lt" placeholder="" data-required="true" />
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请填写联系人！"
                                                        ControlToValidate="tbusername" Display="None" SetFocusOnError="true"></asp:RequiredFieldValidator>
                         </div>
                    <div class="col-sm-6">
                      <label>联系电话 *</label>
                        <input type="text" runat="server" id="tbphone" class="form-control bg-light lt" placeholder="" data-required="true"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="请填写联系电话！"
                                                        ControlToValidate="tbphone" Display="None" SetFocusOnError="true"></asp:RequiredFieldValidator>
                         </div>
                  </div>
                    <div class="form-group">
                    <label>Email</label>
                      <input runat="server" id="tbemail" type="text" data-required="true" class="form-control bg-light lt" placeholder=""/>
                  </div>
                  <div class="form-group">
                    <label>公司名称</label>
                      <input runat="server" id="tbcompany" type="text" data-required="true" class="form-control bg-light lt" placeholder=""/>
                  </div>
                     <div class="form-group">
                    <label>公司地址</label>
                      <input runat="server"  id="tbaddress" type="text" data-required="true" class="form-control bg-light lt" placeholder=""/>
                  </div>
                  <div class="form-group">
                    <label>主题 *</label>
                      <input runat="server" id="tbtitle" type="text" data-required="true" class="form-control bg-light lt" placeholder=""/>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="主题不能为空！"
                                                        ControlToValidate="tbtitle" Display="None" SetFocusOnError="true"></asp:RequiredFieldValidator>
                  </div>
                  <div class="form-group">
                    <label>内容 *</label>
                    <textarea id="tbcontent" runat="server" class="form-control bg-light lt" rows="6" data-minwords="6" data-required="true" placeholder="请输入您的留言"></textarea>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="内容不能为空！"
                                                        ControlToValidate="tbcontent" Display="None" SetFocusOnError="true"></asp:RequiredFieldValidator>
                       </div>
                </div>
                <footer class="panel-footer bg-white " style="border:none;">
                     <asp:Button ID="btSub" Text="提交" class="btn btn-blue btn-s-xs" runat="server" OnClick="btSub_Click" />
                  <input type="reset" value=" 重 写 " class="btn btn-grey btn-s-xs  " name="cmdReset">
                                                    <asp:ValidationSummary ID="vs" runat="server" ShowMessageBox="true" ShowSummary="false" />
                </footer>
              </section>
              
          
          </div>
        </div >

      </div>
    </div>
    
</asp:Content>