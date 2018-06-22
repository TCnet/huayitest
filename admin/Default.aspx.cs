using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuaYimo.Controls;
using TCSolutions.TCweb.Common.Utils;

namespace HuaYimo.admin
{

	public partial class Default : BaseTCwebAdministrationPage
    {
		protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write(LJH.Admin.encry("111111"));
            //Response.End();

        }

        protected void imgBut_Click(object sender, ImageClickEventArgs e)
		{
			string mes = AdminService.checklogin(this.txtUserName.Value, this.txtPassWord.Value, Page.Request.UserHostAddress);
            if (mes == "")
            {
                Response.Redirect("index.aspx");
            }
            else
            {

                ShowJs.ShowAndBack(mes, this.Page);
            }
   
        }

    }
}
