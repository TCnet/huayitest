using System;
using System.Web;
using System.Web.UI;
using TCSolutions.TCweb.BusinessLogic.Infrastructure;
using TCSolutions.TCweb.BusinessLogic.Content.Admin;
using HuaYimo.Controls;
using PetaPoco;
using TCSolutions.TCweb.BusinessLogic.SEO;

namespace HuaYimo
{

	public partial class Default : BaseTCwebFrontendPage
    {
		protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
				//Response.Write(AdminService.encry("111111"));
				//Response.End();
                
            }

            

        }

       
    }
}
