using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuaYimo.Controls;
using TCSolutions.TCweb.BusinessLogic.Content.Admin;
using TCSolutions.TCweb.Common.Utils;
//using HuaYimo.Controls;

namespace HuaYimo.admin
{

	public partial class role_add : BaseTCwebAdministrationPage
    {
		protected void Page_Load(object sender, EventArgs e)
        {
            //if (!LJH.Rank.IsModuleRank(1503))
            //{
            //    Response.Write("<div style='width:100%;margin-top:200px;text-align:center;color:red;'>您没有本模块的操作权限！ 请与管理员联系！</div>");
            //    Response.End();
           // }
            if (!IsPostBack)
            {
                getdata();
                if (Request["edit"] != null)
                {
                    this.Submit1.Visible = false;
                    this.btEdit.Visible = true;
                    this.btReset.Visible = false;
                    this.btBack.Visible = true;
					Role ob = RoleService.GetRoleById(int.Parse(Request["edit"]));
                    
                   
					if (ob!=null)
                    {
						this.tbName.Text = ob.rolename;
                    }
                    

                }
                else if (Request["del"] != null)
                {
					RoleService.DeleteRole(int.Parse(Request["del"]));
                  
                    string backurl = BackPage(pds(), Request["reUrl"].Replace("|", "&"), "role_add.aspx?page=" + (pds().CurrentPageIndex - 1).ToString() + getcanshu());
                    Response.Redirect(backurl);
                    //Response.Redirect(Request["reUrl"].Replace("|", "&"));
                }
            }
        }

        public void getdata()
        {
            this.rpRole.DataSource = pds();
            this.rpRole.DataBind();

        }

        protected void Submit1_ServerClick(object sender, EventArgs e)
        {
			Role ob = new Role();
			ob.rolename = this.tbName.Text.Trim();
			ob.depth = 0;
			ob.pid= 0;
            ShowJs.ShowAndRedirect("添加成功！", "role_add.aspx", this.Page);

        }

        protected void btEdit_Click(object sender, EventArgs e)
        {
            if (Request["edit"] != null)
            {
				Role ob = RoleService.GetRoleById(int.Parse(Request["edit"])); 
				if (ob!=null)
                {
					ob.rolename = this.tbName.Text.Trim();
					RoleService.UpdateRole(ob);
                }
              ShowJs.ShowAndRedirect("修改成功！", "role_add.aspx", this.Page);

            }


        }

        protected void rpRole_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                Label lbpagetotal = (Label)e.Item.FindControl("lbpagetotal");

                Label lbpagenow = (Label)e.Item.FindControl("lbpagenow");

                Label lbnumber = (Label)e.Item.FindControl("lbnumber");
                Label lbnumbertotal = (Label)e.Item.FindControl("lbnumbertotal");
                Label lbGid = (Label)e.Item.FindControl("lbGid");
                HyperLink lpfirst = (HyperLink)e.Item.FindControl("lpfirst");
                HyperLink lpprev = (HyperLink)e.Item.FindControl("lpprev");
                HyperLink lpnext = (HyperLink)e.Item.FindControl("lpnext");
                HyperLink lplast = (HyperLink)e.Item.FindControl("lplast");
                GetPage(pds(), lbpagetotal, lbpagenow, lbnumber, lbnumbertotal, lbGid, lpfirst, lpprev, lpnext, lplast, getcanshu(), "role_add.aspx", "black_link");
            }
        }

        protected PagedDataSource pds()
        {
           // string sql = "select * from tRole";
            PagedDataSource pds = new PagedDataSource();
			pds.DataSource = RoleService.GetAllRole();
            pds.AllowPaging = true;//允许分页
            pds.PageSize = 20;//分页数
            pds.CurrentPageIndex = Convert.ToInt32(Request.QueryString["page"]);//当前页CurrentPageIndex,通过获得传来的参数page来设置
            return pds;

        }

        public string getcanshu()
        {
            string v = "";
            if (Request["type"] != null)
            {
                v += "&type=" + Request["type"];
            }
            return v;
        }

        protected void btDel_Click(object sender, EventArgs e)
        {
            if (Request["sel"] != null)
            {
                string[] a = Request["sel"].Split(',');

                for (int i = 0; i < a.Length; i++)
                {
					RoleService.DeleteRole(int.Parse(a[i]));

                }
                
            }
            string backurl = BackPage(pds(), Request.Url.ToString(), "role_add.aspx?page=" + (pds().CurrentPageIndex - 1).ToString() + getcanshu());
            Response.Redirect(backurl);
            //Response.Redirect(Request.Url.ToString());
        }

    }
}
