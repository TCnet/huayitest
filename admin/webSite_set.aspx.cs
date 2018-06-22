using System;
using System.Web;
using System.Web.UI;
using HuaYimo.Controls;
using TCSolutions.TCweb.Common.Utils;

namespace HuaYimo.admin
{

	public partial class webSite_set : BaseTCwebAdministrationPage
    {
		
		protected void Page_Load(object sender, EventArgs e)
        {
            //if (!LJH.Rank.IsModuleRank(1405))
           // {
            //    Response.Write("<div style='width:100%;margin-top:200px;text-align:center;color:red;'>您没有本模块的操作权限！ 请与管理员联系！</div>");
           //     Response.End();
           // }
            if (!IsPostBack)
            {
                getdata();
            }
            

        }

        public void getdata()
        {
			string defaulSEOTitle = this.SettingManager.GetSettingValue("SEO.DefaultTitle");
            string defaulSEODescription = this.SettingManager.GetSettingValue("SEO.DefaultMetaDescription");
            string defaulSEOKeywords = this.SettingManager.GetSettingValue("SEO.DefaultMetaKeywords");

          
			this.tsName.Text = SettingManager.WebName;
			//  this.tsSiteLogo.Text = dt.DefaultView[0]["sSiteLogo"].ToString();
			this.tsSiteUrl.Text = SettingManager.WebUrl;
			this.tsTitle.Text = defaulSEOTitle;
			this.tbContent.Text = SettingManager.Copyright;
			this.tsDescription.Text = defaulSEODescription;
			this.tsKeywords.Text = defaulSEOKeywords;
			// this.tbsCount.Text = dt.DefaultView[0]["sCount"].ToString();
			this.tsAddress.Text = SettingManager.Address;
			this.tsFax.Text = SettingManager.Fax;
			this.tsPhone.Text = SettingManager.MobilePhone;
			this.tsTel.Text = SettingManager.TelPhone;
			this.tsWeiXin.Text = SettingManager.WeiXin;
			this.tsQQ.Text = SettingManager.QQ;
          


        }

        protected void btSub_Click(object sender, EventArgs e)
        {
			
			SettingManager.WebName = this.tsName.Text;
			SettingManager.SetParam("SEO.DefaultTitle",this.tsTitle.Text);
			SettingManager.SetParam("SEO.DefaultMetaDescription", this.tsDescription.Text);
			SettingManager.SetParam("SEO.DefaultMetaKeywords", this.tsKeywords.Text);
			SettingManager.Copyright = this.tbContent.Text;
			SettingManager.WebUrl = this.tsSiteUrl.Text;
			SettingManager.Address = this.tsAddress.Text;
			SettingManager.Fax = this.tsFax.Text;
			SettingManager.MobilePhone = this.tsPhone.Text;
			SettingManager.TelPhone = this.tsTel.Text;
			SettingManager.WeiXin = this.tsWeiXin.Text;
			SettingManager.QQ = this.tsQQ.Text;

			
            
            ShowJs.ShowAndRedirect("设置成功！", Request.Url.ToString(), this.Page);
        }

    }
}
