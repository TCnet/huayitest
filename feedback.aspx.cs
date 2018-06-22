using System;
using System.Web;
using System.Web.UI;
using HuaYimo.Controls;
using TCSolutions.TCweb.BusinessLogic.Content.FeedBack;
using TCSolutions.TCweb.Common.Utils;
namespace HuaYimo
{
	public partial class feedback : BaseTCwebFrontendPage
    {
		protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Redirect("news_list.aspx?type=8");
			if(!IsPostBack)
			{
				this.lbWebName.Text = SettingManager.WebName;
				this.lbQQ.Text = SettingManager.QQ;
				this.lbFax.Text = SettingManager.Fax;
				this.lbWeiXin.Text = SettingManager.WeiXin;
				this.lbAddress.Text = SettingManager.Address;
				this.lbTelPhone.Text = SettingManager.TelPhone;
				this.lbMobilPhone.Text = SettingManager.MobilePhone;
                

			}
        }

        protected void btSub_Click(object sender, EventArgs e)
        {
            try
            {
				
                FeedBack m = new FeedBack();

				m.title = this.tbtitle.Value.Trim();
				m.company = this.tbcompany.Value.Trim();
				m.address= this.tbaddress.Value.Trim();
                // m["zip"] = this.tbzip.Value.Trim();
				m.username = this.tbusername.Value.Trim();
                // m["mobile"] = this.tbmobile.Value.Trim();
				m.phone= this.tbphone.Value.Trim();
                // m["fax"] = this.tbFax.Value.Trim();
				m.email= this.tbemail.Value.Trim();
				m.content = this.tbcontent.Value;
				m.addtime = DateTime.Now;
				m.flag = false;
				m.type = 1;
				FeedBackService.InsertFeedBack(m);
				ShowJs.ShowAndRedirect("感谢您的留言！", Request.Url.ToString() ,this.Page);
            }
            catch (Exception)
            {
				ShowJs.ShowAndBack("提交失败！", this.Page);
            }

        }
    }
}
