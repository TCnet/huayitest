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
using TCSolutions.TCweb.BusinessLogic.SEO;

namespace HuaYimo.Controls
{
    public partial class BaseTCwebFrontendPage : BaseTCwebPage
    {
        #region Overrides





        protected override void OnPreInit(EventArgs e)
        {
            //store is closed


            //SSL


            //allow navigation only for registered customers


            //theme
            //page security validation
            //if (!ValidateIsLoginSecurity())
            //{
            //    string url = SEOHelper.GetLoginPageUrl();
            //    Response.Redirect(url);
            //}
            base.OnPreInit(e);
        }

        protected override void OnInit(EventArgs e)
        {
            

            base.OnInit(e);

            
        }

        protected override void OnLoad(EventArgs e)
        {
            

            base.OnLoad(e);

        }

       

        protected override void OnPreRender(EventArgs e)
        {
            //java-script
            string publicJS = CommonHelper.GetStoreLocation() + "Scripts/public.js";
            Page.ClientScript.RegisterClientScriptInclude(publicJS, publicJS);

            base.OnPreRender(e);
        }
        #endregion


        

        #region Properties

        /// <summary>
        /// Gets a value indicating whether this page is SSL protected
        /// </summary>
        public virtual PageSslProtectionEnum SslProtected
        {
            get
            {
                return PageSslProtectionEnum.DoesntMatter;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this page can be visited by anonymous customer when "Allow navigation only for registered customers" settings is set to true
        /// </summary>
        public virtual bool AllowGuestNavigation
        {
            get
            {
                return false;
            }
        }
        #endregion
    }
}