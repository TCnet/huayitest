using System;
using System.Web;
using System.Web.UI;

namespace HuaYimo.admin
{

    public partial class nologin : System.Web.UI.Page
    {
		protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("<script>parent.location='Default.aspx'</script>");
        }
    }
}
