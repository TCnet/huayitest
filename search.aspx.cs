using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuaYimo.Controls;
using TCSolutions.TCweb.Common.Utils;
namespace HuaYimo
{
	public partial class search : BaseTCwebFrontendPage
    {
		protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Request["type"] == "9")
                //{
                //    Response.Redirect("message.aspx?type=91");
                //}
                getdata();
            }




        }
        public void getdata()
        {
            this.rpNewslist.DataSource = pds();
            this.rpNewslist.DataBind();
        }

        protected void rpNewslist_ItemDataBound(object sender, RepeaterItemEventArgs e)
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

                Label lbGid2 = (Label)e.Item.FindControl("lbGid2");
                HyperLink lpfirst2 = (HyperLink)e.Item.FindControl("lpfirst2");
                HyperLink lpprev2 = (HyperLink)e.Item.FindControl("lpprev2");
                HyperLink lpnext2 = (HyperLink)e.Item.FindControl("lpnext2");
                HyperLink lplast2 = (HyperLink)e.Item.FindControl("lplast2");
                GetPage(pds(), lbpagetotal, lbpagenow, lbnumber, lbnumbertotal, lbGid, lpfirst, lpprev, lpnext, lplast, getcanshu(), "news_list.aspx", "black_link");

                lbGid2.Text = lbGid.Text;
                lpfirst2.NavigateUrl = lpfirst.NavigateUrl;
                lpnext2.NavigateUrl = lpnext.NavigateUrl;
                lplast2.NavigateUrl = lplast.NavigateUrl;
                lpprev2.NavigateUrl = lpprev.NavigateUrl;
            }
        }
        protected PagedDataSource pds()
        {
            string key = Request["key"];
            this.uc_breadcrumb.Title = string.Format("搜索：{0} ", key);
            string sql2 = "where isdelete=false and flag=true and title like '%" + key + "%' or content like '%" + key + "%' order by istop desc, addtime desc";
            //string sql = string.Format("select * from vNews where type={0} and flag=1 order by addtime desc", type);
            //Response.Write(sql);
            //Response.End();
            PagedDataSource pds = new PagedDataSource();
			pds.DataSource =NewsService.GetTable(sql2);
            pds.AllowPaging = true;//允许分页
            pds.PageSize = 20;//分页数
            pds.CurrentPageIndex = Convert.ToInt32(Request.QueryString["page"]);//当前页CurrentPageIndex,通过获得传来的参数page来设置
            return pds;

        }

        public string getcanshu()
        {
            string v = "";
            if (Request["key"] != null)
            {
                v += "&key=" + Request["key"];
            }
            return v;
        }

        public string geturl(string id, string title)
        {
			string s = "<a href='news_view.aspx?id=" + id + "' class=\"black_link\"   >" + CommonHelper.GetSubString(title,30,"...") + "</a>";

            return s;



        }
		
    }
}
