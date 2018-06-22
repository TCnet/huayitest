using System;
using System.Web;
using System.Web.UI;
using TCSolutions.TCweb.BusinessLogic.Content.Admin;
using TCSolutions.TCweb.Common.Utils;
using HuaYimo.Controls;

namespace HuaYimo.admin
{

	public partial class admin_psw : BaseTCwebAdministrationPage
    {
		protected void Page_Load(object sender, EventArgs e)
        {
            //if (!LJH.Rank.IsModuleRank(1502))
           // {
            //    Response.Write("<div style='width:100%;margin-top:200px;text-align:center;color:red;'>您没有本模块的操作权限！ 请与管理员联系！</div>");
            //    Response.End();
           // }
            Page.EnableViewState = false;
            if (!IsPostBack)
            {
				tbName.Text = AdminService.Adminname;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (tbNewPass.Text == tbNewPass2.Text)
            {
                string mess = "";
				mess = AdminService.SetPsw(AdminService.Adminid, tbOp.Text, tbNewPass.Text);
                ShowJs.ShowAndBack(mess, this.Page);
            }
            else
            {
                ShowJs.ShowAndBack("两次输入密码不一样!", this.Page);
            }
        }

    }
}
