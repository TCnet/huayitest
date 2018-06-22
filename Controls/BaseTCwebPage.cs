using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using  TCSolutions.TCweb.BusinessLogic.Products;
using TCSolutions.TCweb.BusinessLogic.Content.Admin;

using TCSolutions.TCweb.BusinessLogic.Maintenance;
using TCSolutions.TCweb.BusinessLogic.Content.News;
using TCSolutions.TCweb.BusinessLogic.Content.Link;
using TCSolutions.TCweb.BusinessLogic.Content.FeedBack;
using TCSolutions.TCweb.BusinessLogic.Content.AdvInfo;


namespace HuaYimo.Controls
{
    public partial class BaseTCwebPage : Page
    {
      

        /// <summary>
        /// Gets a value indicating whether this page is tracked by 'Online Customers' module
        /// </summary>
        public virtual bool TrackedByOnlineCustomersModule
        {
            get
            {
                return true;
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            ////online user tracking
            //if (this.TrackedByOnlineCustomersModule)
            //{
            //    this.OnlineUserService.TrackCurrentUser();
            //}

            //base.OnPreRender(e);
        }
		#region page



		public static string App_ImgPath
        {
            get
            {
				return ConfigurationManager.AppSettings["ImgPath"].ToString();

            }

        }

		public static string App_FilePath
        {
            get
            {
				return ConfigurationManager.AppSettings["FilePath"].ToString();
              

            }

        }


		public static string UpFile(FileUpload ob, string path)
        {
            string url = string.Format("{0}{1}", path, ob.FileName);
            ob.SaveAs(url);
			return ob.FileName;


        }

		public static string BackPage(PagedDataSource pds, string url, string backurl)
        {
            if (pds.PageCount == pds.CurrentPageIndex)
            {
                return backurl;
            }
            else
            {
                return url;

            }

        }

		public static void GetPage(PagedDataSource pds, Label lbpagetotal, Label lbpagenow, Label lbnumber, Label lbnumbertotal, Label lbGid, HyperLink lpfirst, HyperLink lpprev, HyperLink lpnext, HyperLink lplast, string canshu, string url, string css)
        {
            int n = Convert.ToInt32(pds.PageCount);//n为分页数
            int i = Convert.ToInt32(pds.CurrentPageIndex);//i为当前页
            lbpagetotal.Text = n.ToString();
            lbpagenow.Text = Convert.ToString(pds.CurrentPageIndex + 1);
            lbnumber.Text = Convert.ToString(pds.PageSize);
            lbnumbertotal.Text = Convert.ToString(pds.DataSourceCount);
            lpfirst.NavigateUrl = "?page=0" + canshu;
            //向Default.aspx(就是本页)传递参数page
            lplast.NavigateUrl = "?page=" + (n - 1) + canshu;

            if (i <= 0)
            {
                lpfirst.Enabled = false;
                lpprev.Enabled = false;
                lplast.Enabled = true;
                lpnext.Enabled = true;
            }
            else
            {
                lpprev.NavigateUrl = "?page=" + (i - 1) + canshu;
            }
            if (i >= n - 1)
            {
                lpfirst.Enabled = true;
                lplast.Enabled = false;
                lpnext.Enabled = false;
                lpprev.Enabled = true;
            }
            else
            {
                lpnext.NavigateUrl = "?page=" + (i + 1) + canshu;
            }

            int mi = i % 10;
            int ki = i / 10;
            int mn = n % 10;
            int kn = n / 10;

            if (ki == kn)
            {
                for (int j = 0; j < mn; j++)
                {
                    lbGid.Text += "[<a href='" + url + "?page=" + (ki * 10 + j) + "" + canshu + "' class='" + css + "'>" + SetColor((ki * 10 + j + 1), "red", i) + "</a>]";
                }
            }
            else
            {
                for (int j = 0; j < 10; j++)
                {
                    lbGid.Text += "[<a href='" + url + "?page=" + (ki * 10 + j) + "" + canshu + "' class='" + css + "'>" + SetColor((ki * 10 + j + 1), "red", i) + "</a>]";
                }

            }

        }

		public static string SetColor(int page,string color)
        {
            return "<font color='"+color+"'>"+page+"</font>";
 
        }

        public static string SetColor(int page, string color, int CurrentPageIndex)
        {
            if (page == CurrentPageIndex+1)
            {
                return SetColor(page, color);
            }
            else
            {
                return page.ToString();
 
            }
 
        }
#endregion 



		#region Services, managers



		public ISettingManager SettingManager
        {
            get { return IoC.Resolve<ISettingManager>(); }
        }


        public IMaintenanceService MaintenanceService
        {
            get { return IoC.Resolve<IMaintenanceService>(); }
        }


		public IAdminService AdminService
        {
			get { return IoC.Resolve<IAdminService>(); }
        }

        public  IProductService ProductService
        {
            get { return IoC.Resolve<IProductService>(); }
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
        
		public IAdvInfoService AdvInfoService
        {
			get { return IoC.Resolve<IAdvInfoService>(); }
        }

		public IRoleService RoleService
        {
			get { return IoC.Resolve<IRoleService>(); }
        }
		public IModuleService ModuleService
        {
			get { return IoC.Resolve<IModuleService>(); }
        }
		public IRankService RankService
        {
			get { return IoC.Resolve<IRankService>(); }
        }
		public IFeedBackTypeService FeedBackTypeService
        {
			get { return IoC.Resolve<IFeedBackTypeService>(); }
        }
        
        




        #endregion
    }
}