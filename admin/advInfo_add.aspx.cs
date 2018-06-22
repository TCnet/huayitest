using System;
using System.Web;
using System.Web.UI;
using HuaYimo.Controls;
using TCSolutions.TCweb.BusinessLogic.Content.AdvInfo;
using TCSolutions.TCweb.Common.Utils;

namespace HuaYimo.admin
{

	public partial class advInfo_add : BaseTCwebAdministrationPage
    {
		protected void Page_Load(object sender, EventArgs e)
        {
            //if (!LJH.Rank.IsModuleRank(1407))
            //{
            //    Response.Write("<div style='width:100%;margin-top:200px;text-align:center;color:red;'>您没有本模块的操作权限！ 请与管理员联系！</div>");
            //    Response.End();
           // }

            if (Request["id"] != null)
            {
                sbEdit.Visible = true;
                Submit1.Visible = false;
                btBack.Visible = true;

            }
            else
            {
                sbEdit.Visible = false;
                Submit1.Visible = true;
                btBack.Visible = false;
            }
            if (!IsPostBack)
            {

                this.tbFlyImageHeight.Text = "100";
                this.tbFlyImageWidth.Text = "100";
                tbAddTime.Text = DateTime.Now.ToString();
                if (Request["id"] != null)
                {
                    hdUrl.Value = Request.UrlReferrer.ToString();
					AdvInfo ob = AdvInfoService.GetAdvInfoById(int.Parse(Request["id"]));
                  
					if (ob!=null)
                    {
						this.tbtitle.Text =ob.title;
						tbimgUrl.Text = ob.imgurl;
						tbimgLink.Text = ob.imglink;
						tbFlyImageHeight.Text = ob.flyimageheight.ToString();
						tbFlyImageWidth.Text = ob.flyimagewidth.ToString();
						tbAddTime.Text = ob.addtime.ToString("yyyy-MM-dd");
						rbFlag.SelectedValue = ob.flag==true?"1":"0";


                    }
                 
                }
            }
        }
        protected void Submit1_ServerClick(object sender, EventArgs e)
        {
			AdvInfo ob = new AdvInfo();
            ob.title = tbtitle.Text;
            ob.imgurl = tbimgUrl.Text;
			ob.imglink = tbimgLink.Text;
            ob.flyimagewidth = int.Parse(tbFlyImageWidth.Text);
            ob.flyimageheight = int.Parse(tbFlyImageHeight.Text);
            ob.addtime = Convert.ToDateTime(tbAddTime.Text);
            ob.flag = this.rbFlag.SelectedValue == "1" ? true : false;


            AdvInfoService.InsertAdvInfo(ob);

            try
            {
                
                string script = "<script>if(confirm('是否继续添加?')){location='" + Request.Url.ToString() + "';}else{location='advInfo_add.aspx';}</script>";
                Response.Write(script);
                Response.End();
            }
            catch
            {
                ShowJs.ShowAndRedirect("添加失败！", "advInfo_add.aspx", this.Page);

            }



        }
        protected void sbEdit_ServerClick(object sender, EventArgs e)
        {
            if (Request["id"] != null)
            {
                try
                {
					AdvInfo ob = AdvInfoService.GetAdvInfoById(int.Parse(Request["id"]));
                 
					if (ob!=null)
                    {
						ob.title = tbtitle.Text;
                        ob.imgurl = tbimgUrl.Text;
                        ob.imglink = tbimgLink.Text;
                        ob.flyimagewidth = int.Parse(tbFlyImageWidth.Text);
                        ob.flyimageheight = int.Parse(tbFlyImageHeight.Text);
                        ob.addtime = Convert.ToDateTime(tbAddTime.Text);
                        ob.flag = this.rbFlag.SelectedValue == "1" ? true : false;

						AdvInfoService.UpdateAdvInfo(ob);

                    }
                 
                }
                catch
                {
                    ShowJs.ShowAndRedirect("修改失败！", hdUrl.Value, this.Page);

                }

            }

            ShowJs.ShowAndRedirect("修改成功！", hdUrl.Value, this.Page);
        }


    }
}
