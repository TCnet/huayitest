using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuaYimo.Controls;

namespace HuaYimo.admin
{

	public partial class link_manage : BaseTCwebAdministrationPage
    {
		protected void Page_Load(object sender, EventArgs e)
        {

           // if (!LJH.Rank.IsModuleRank(1406))
           /// {
            //    Response.Write("<div style='width:100%;margin-top:200px;text-align:center;color:red;'>您没有本模块的操作权限！ 请与管理员联系！</div>");
           //     Response.End();
          //  }
            if (!IsPostBack)
            {
                if (Request["del"] != null)
                {
					LinkService.DeleteLink(int.Parse(Request["del"]));
                    string backurl = BackPage(pds(), Request["reUrl"].Replace("|", "&"), "link_manage.aspx?page=" + (pds().CurrentPageIndex - 1).ToString() + getcanshu());
                    Response.Redirect(backurl);
                }
                else if (Request["flag"] != null && Request["id"] != null)
                {
					LinkService.SetFlag(Request["flag"]=="1"?true:false,int.Parse(Request["id"]));
                    Response.Redirect("link_manage.aspx");
                }
                else
                {
                    getdata();
                }
            }
        }



		protected string GetFlag(bool a, string b)
        {
            if (a)
            {
                return "<a href=link_manage.aspx?flag=0&id=" + b + ">显示</a>";
            }
            else
            {
                return "<a href=link_manage.aspx?flag=1&id=" + b + "><font color=red>不显示</font></a>";
            }
        }

        protected void btDel_Click(object sender, EventArgs e)
        {
            if (Request["sel"] != null)
            {
                string[] a = Request["sel"].Split(',');
                for (int i = 0; i < a.Length; i++)
                {
					LinkService.DeleteLink(int.Parse(a[i]));
                }
            }
            string backurl = BackPage(pds(), Request.Url.ToString(), "link_manage.aspx?page=" + (pds().CurrentPageIndex - 1).ToString() + getcanshu());
            Response.Redirect(backurl);


        }

        public void getdata()
        {

            this.rtAdmin.DataSource = pds();
            this.rtAdmin.DataBind();

        }

        public string gettype(string type)
        {
            switch (type)
            {

                case "1": return "各省";
                case "2": return "各市";
                case "3": return "各区";
                default: return "未知";
            }
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            string v = "";
            v += "?type=" + this.ddlType.SelectedValue;
            if (this.tbKey.Text.Trim() != "")
            {
                v += "&key=" + this.tbKey.Text.Trim();

            }


            Response.Redirect("link_manage.aspx" + v);
        }

        protected void rtAdmin_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
                GetPage(pds(), lbpagetotal, lbpagenow, lbnumber, lbnumbertotal, lbGid, lpfirst, lpprev, lpnext, lplast, getcanshu(), "link_manage.aspx", "black_link");
            }
        }

        protected PagedDataSource pds()
        {

            string sql = "";
            if (Request["type"] != null)
            {
                if (Request["type"] != "all")
                {
                    sql += " and type=" + int.Parse(Request["type"]);
                }
                this.ddlType.SelectedValue = Request["type"];
            }
            if (Request["key"] != null)
            {
                sql += "and title like '%" + Request["key"] + "%'";
                this.tbKey.Text = Request["key"];
            }

            
            PagedDataSource pds = new PagedDataSource();

			pds.DataSource = LinkService.GetTable(string.Format("where 1=1 {0} order by sort desc", sql));
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
                v += "&type=" + int.Parse(Request["type"]);
            }
            if (Request["key"] != null)
            {
                v += "&key=" + Request["key"];
            }

            return v;

        }

        public bool IsStrong(string type)
        {
            if (Request["type"] != null)
            {
                if (Request["type"] == type)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }


    }
}
