using System;
using System.Web;
using System.Web.UI;
using HuaYimo.Controls;
using TCSolutions.TCweb.BusinessLogic.Content.Link;
using TCSolutions.TCweb.Common.Utils;

namespace HuaYimo.admin
{

	public partial class link_add : BaseTCwebAdministrationPage
    {
		protected void Page_Load(object sender, EventArgs e)
        {
           // if (!LJH.Rank.IsModuleRank(1406))
            //{
            //    Response.Write("<div style='width:100%;margin-top:200px;text-align:center;color:red;'>您没有本模块的操作权限！ 请与管理员联系！</div>");
           //     Response.End();
           // }
            if (Request["edit"] != null)
            {
                this.Submit1.Visible = false;
                this.btEdit.Visible = true;
            }
            else
            {
                this.Submit1.Visible = true;
                this.btEdit.Visible = false;
            }
            if (!IsPostBack)
            {

                if (Request["edit"] != null)
                {
                    getdata();
                }
                
            }
        }

        public void getdata()
        {

			Link a = LinkService.GetLinkById(int.Parse(Request["edit"]));
          
			if (a!=null)
            {
				this.tbtitle.Text =a.title;
				this.tburl.Text = a.url;
				this.tbsort.Text = a.sort.ToString();
				this.ddltype.SelectedValue = a.type.ToString();
				this.rbFlag.SelectedValue = a.flag==true?"1":"0";


            }
          

        }

        protected void Submit1_ServerClick(object sender, EventArgs e)
        {
            if (tbtitle.Text.Trim() != "" && tburl.Text != "" && tbsort.Text != "")
            {

				Link ob = new Link();
				ob.title = this.tbtitle.Text.Trim();
				ob.url = this.tburl.Text;
				ob.sort = int.Parse(this.tbsort.Text);
				ob.flag = this.rbFlag.SelectedValue == "1" ? true : false;
				ob.type = int.Parse(this.ddltype.SelectedValue);
				LinkService.InsertLink(ob);
             
                ShowJs.ShowAndRedirect("添加成功！", "link_add.aspx", this.Page);

            }
            else
            {
                ShowJs.ShowAndBack("您的输入有误！", this.Page);
            }
        }

        protected void btEdit_Click(object sender, EventArgs e)
        {
            if (Request["edit"] != null)
            {
				Link ob = LinkService.GetLinkById(int.Parse(Request["edit"]));
         
				if (ob!=null)
                {
					ob.title =this.tbtitle.Text.Trim();
					ob.url = this.tburl.Text;
					ob.sort = int.Parse(this.tbsort.Text);
					ob.flag = this.rbFlag.SelectedValue == "1" ? true : false;
					ob.type = int.Parse(this.ddltype.SelectedValue);
					LinkService.UpdateLink(ob);

                   
                }
              
                ShowJs.ShowAndRedirect("修改成功！", "link_manage.aspx", this.Page);

            }


        }
    }
}
