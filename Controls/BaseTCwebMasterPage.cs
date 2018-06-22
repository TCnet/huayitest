using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using TCSolutions.TCweb.Common.Utils;
using TCSolutions.TCweb.BusinessLogic;

using TCSolutions.TCweb.BusinessLogic.Infrastructure;
using TCSolutions.TCweb.BusinessLogic.Configuration.Settings;

using TCSolutions.TCweb.BusinessLogic.Maintenance;

namespace HuaYimo.Controls
{
    public class BaseTCwebMasterPage : MasterPage
    {

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            SetFavIcon();
        }

        protected void SetFavIcon()
        {
            string favIconPath = HttpContext.Current.Request.PhysicalApplicationPath + "favicon.ico";
            if (File.Exists(favIconPath))
            {
                string favIconUrl = CommonHelper.GetStoreLocation() + "favicon.ico";

                HtmlLink htmlLink1 = new HtmlLink();
                htmlLink1.Attributes["rel"] = "icon";
                htmlLink1.Attributes["href"] = favIconUrl;

                HtmlLink htmlLink2 = new HtmlLink();
                htmlLink2.Attributes["rel"] = "shortcut icon";
                htmlLink2.Attributes["href"] = favIconUrl;

                Page.Header.Controls.Add(htmlLink1);
                Page.Header.Controls.Add(htmlLink2);
            }
        }

       

        #region Services, managers

       

        public ISettingManager SettingManager
        {
            get { return IoC.Resolve<ISettingManager>(); }
        }

       
        public IMaintenanceService MaintenanceService
        {
            get { return IoC.Resolve<IMaintenanceService>(); }
        }



        

        #endregion

    }
}