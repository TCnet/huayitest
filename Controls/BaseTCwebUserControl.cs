using System;
using System.Configuration;
using System.Data;
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
using TCSolutions.TCweb.BusinessLogic.Content.News;
using TCSolutions.TCweb.BusinessLogic.Content.Link;
using TCSolutions.TCweb.BusinessLogic.Content.FeedBack;

namespace HuaYimo.Controls
{
    public partial class BaseTCwebUserControl : UserControl
    {





        #region Services, managers



        public ISettingManager SettingManager
        {
            get { return IoC.Resolve<ISettingManager>(); }
        }


        public IMaintenanceService MaintenanceService
        {
            get { return IoC.Resolve<IMaintenanceService>(); }
        }
		public INewsService NewsService
        {
            get { return IoC.Resolve<INewsService>(); }
        }
        public INewsTypeService NewsTypeService
        {
            get { return IoC.Resolve<INewsTypeService>(); }
        }
        public ILinkService LinkService
        {
            get { return IoC.Resolve<ILinkService>(); }
        }
        

		public IFeedBackService FeedBackService
        {
            get { return IoC.Resolve<IFeedBackService>(); }
        }
        




        #endregion
    }
}