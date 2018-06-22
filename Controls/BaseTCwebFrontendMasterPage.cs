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
using  TCSolutions.TCweb.BusinessLogic.SEO;



namespace HuaYimo.Controls
{
    public partial class BaseTCwebFrontendMasterPage : BaseTCwebMasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }

            string defaulSEOTitle = this.SettingManager.GetSettingValue("SEO.DefaultTitle");
            string defaulSEODescription = this.SettingManager.GetSettingValue("SEO.DefaultMetaDescription");
            string defaulSEOKeywords = this.SettingManager.GetSettingValue("SEO.DefaultMetaKeywords");
            SEOHelper.RenderTitle(this.Page, defaulSEOTitle, false, false);
            SEOHelper.RenderMetaTag(this.Page, "description", defaulSEODescription, false);
            SEOHelper.RenderMetaTag(this.Page, "keywords", defaulSEOKeywords, false);
            //if (TCwebContext.Current.WorkingLanguage.LanguageCulture == "zh-CN")
            //{ SEOHelper.RenderHeaderCssLink(this.Page, "/css/cn.css"); }

            //if (this.SettingManager.GetSettingValueBoolean("Display.ShowNewsHeaderRssURL"))
            //{
            //    SEOHelper.RenderHeaderRssLink(this.Page, defaulSEOTitle + ": News", SEOHelper.GetNewsRssUrl());
            //}
            //if (this.SettingManager.GetSettingValueBoolean("Display.ShowBlogHeaderRssURL"))
            //{
            //    SEOHelper.RenderHeaderRssLink(this.Page, defaulSEOTitle + ": Blog", SEOHelper.GetBlogRssUrl());
            //}
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);


            //AddPoweredBy();
        }

        public virtual void ShowMessage(string message)
        {

        }

        public virtual void ShowError(string message, string completeMessage)
        {

        }


        protected void AddPoweredBy()
        {
            StringBuilder poweredBy = new StringBuilder();
            poweredBy.Append(Environment.NewLine);
            poweredBy.Append("<!--Powered by TCNET - http://www.nbtcnet.com-->");
            poweredBy.Append(Environment.NewLine);
            poweredBy.Append("<!--Copyright (c) 2011-2013-->");
            poweredBy.Append(Environment.NewLine);
            Page.Header.Controls.AddAt(Page.Header.Controls.Count, new LiteralControl(poweredBy.ToString()));
        }
    }
}