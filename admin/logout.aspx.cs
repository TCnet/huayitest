using System;
using System.Web;
using System.Web.UI;
using System.Web.Security;

namespace HuaYimo.admin
{

    public partial class logout : System.Web.UI.Page
    {
		protected void Page_Load(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
           // lbMess.Text = "您已经成功退出系统!";
            Response.Write("<script language='javascript'>setTimeout(\"document.location='Default.aspx'\",1000);</script>");
        }

    }
}
