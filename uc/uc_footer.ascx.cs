using System;
using System.Web;
using System.Web.UI;
using HuaYimo.Controls;

namespace HuaYimo.uc
{

	public partial class uc_footer : BaseTCwebUserControl
    {
		public string WeiXin = "";
		public string QQ = "";
		protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        public void BindData()
        {
			this.rpLink.DataSource = LinkService.GetLink(5);
             this.rpLink.DataBind();

			lbWebName.Text = SettingManager.WebName;
			lbAddress.Text = SettingManager.GetSettingValue("Contact.Address");
			lbFax.Text = SettingManager.GetSettingValue("Contact.Fax");
			lbMobilePhone.Text = SettingManager.GetSettingValue("Contact.MobilePhone");
			lbTePhone.Text = SettingManager.GetSettingValue("Contact.TelPhone");
			 WeiXin = SettingManager.GetSettingValue("Contact.WeiXin");
			QQ = SettingManager.GetSettingValue("Contact.QQ");
            

			this.rpZD.DataSource = NewsTypeService.GetChildTypeByParentId(5);
             this.rpZD.DataBind();
        }
    }
}
